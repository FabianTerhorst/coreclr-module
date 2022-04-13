// ReSharper disable CppClangTidyClangDiagnosticCastFunctionType
#include "coreclr/nethost.h"
#include "CoreCLR.h"

#include <future>

#include "../../../cpp-sdk/SDK.h"
#include <windows.h>
#include "coreclr/hostfxr.h"
#include <string>
#include <sstream>
#include <filesystem>
#include "exceptions/LoadException.h"
#include "coreclr/coreclr_delegates.h"
#include "utils.h"
#include <Log.h>
#include <zip_file.hpp>
#include <json.hpp>
#include <sha1.hpp>

#include "runtime/eventDelegates.h"

using namespace alt;
using namespace std;
namespace fs = std::filesystem;

CoreClrDelegate_t load_resource_delegate = nullptr;
CoreClrDelegate_t stop_resource_delegate = nullptr;
CoreClrDelegate_t stop_runtime_delegate = nullptr;

namespace {
    std::string find_hostfxr() {
        char_t buffer[MAX_PATH];
        size_t bufferSize = sizeof(buffer) / sizeof(char_t);

        const int rc = get_hostfxr_path(buffer, &bufferSize, nullptr);
        if (rc != 0) throw LoadException("Failed to find hostfxr.dll");

        return {buffer, buffer + bufferSize};
    }

    std::wstring find_runtimeconfig() {
        const std::wstring runtimeconfigPath = utils::get_current_dll_path();
        const auto pos = runtimeconfigPath.find_last_of('\\');
        if (pos == std::wstring::npos) throw LoadException("Unable to find runtimeconfig.json");
        return runtimeconfigPath.substr(0, pos + 1) + L"AltV.Net.Client.runtimeconfig.json";
    }

    std::wstring find_host_dll() {
        const std::wstring debugDllPath = utils::get_current_dll_path();
        const auto pos = debugDllPath.find_last_of('\\');
        if (pos == std::wstring::npos) throw LoadException("Unable to find host dll");
        return debugDllPath.substr(0, pos + 1) + L"AltV.Net.Client.Host.dll";
    }
    
    std::string get_clr_folder_path() {
        return miniz_cpp::detail::join_path({ alt::ICore::Instance().GetClientPath(), "csharp-temp" });
    }
    
    alt::IHttpClient::HttpResponse download_file_sync(const Ref<alt::IHttpClient> httpClient, const std::string& url) {
        std::promise<alt::IHttpClient::HttpResponse> promise;
        std::future<alt::IHttpClient::HttpResponse> future = promise.get_future();
    
        httpClient->Get([](alt::IHttpClient::HttpResponse response, const void* data) {
            const auto innerPromise = (std::promise<alt::IHttpClient::HttpResponse>*) data;
            
            if (response.statusCode != 200) {
                innerPromise->set_exception(std::make_exception_ptr(LoadException("Failed to download file")));
                return;
            }
            
            innerPromise->set_value(response);
        }, url, &promise);

        try {
            return future.get();
        } catch(const LoadException&) {
            throw LoadException("Failed to download file " + url);
        }
    }
    
}  // namespace

void CoreCLR::InitializeCoreclr(const string_t &runtimeconfig_path) {
    void *load_assembly_and_get_function_pointer = nullptr;
    hostfxr_handle cxt = nullptr;
    int rc = _initializeFxr(runtimeconfig_path.c_str(), nullptr, &cxt);
    if (rc != 0 || cxt == nullptr) {
        _closeFxr(cxt);
        std::stringstream error;
        error << "Init failed: " << std::hex << std::showbase << rc << std::endl;
        throw LoadException(error.str());
    }

    rc = _getDelegate(cxt, hdt_load_assembly_and_get_function_pointer, &load_assembly_and_get_function_pointer);
    if (rc != 0 || load_assembly_and_get_function_pointer == nullptr) {
        std::stringstream error;
        error << "Get delegate failed: " << std::hex << std::showbase << rc << std::endl;
        throw LoadException(error.str());
    }

    _closeFxr(cxt);
    _loadAssembly = (load_assembly_and_get_function_pointer_fn) load_assembly_and_get_function_pointer;
}

CoreCLR::CoreCLR(alt::ICore* core) {
    Log::Info << "Constructing CoreCLR" << Log::Endl;
    _core = core;
}


bool CoreCLR::Validate(Ref<alt::IHttpClient> httpClient) const {
    auto const coreclrPath = get_clr_folder_path();
    fs::path coreclrStdPath(coreclrPath);
    if (!fs::exists(coreclrPath)) return false;
    
    // const auto updateFile = download_file_sync(httpClient, "https://cdn.altv.mp/coreclr-module/release/x64_linux/update.json");
    // auto updateJson = nlohmann::json::parse(updateFile.body);
    auto updateJson = nlohmann::json::parse(R"({"hashList":{"modules/coreclr-client-module/AltV.Net.Client.Host.dll":"3577aa14ae134aa0cc7758e004ba76b768f9b225"}})");
    const auto hashList = updateJson["hashList"];
    
    for (auto it = hashList.begin(); it != hashList.end(); ++it) {
        Log::Info << "Validating " << it.key() << Log::Endl;
        const auto path = miniz_cpp::detail::join_path({ coreclrPath, it.key() });
        if (!fs::exists(path)) {
            Log::Warning << "File " << path << " does not exist" << Log::Endl;
            return false;
        }
        SHA1 checksum;
        auto stream = std::ifstream(path, std::ios::binary);
        checksum.update(stream);
        const std::string hash = checksum.final();
        if (hash != it.value()) {
            Log::Warning << "File " << path << " has invalid hash" << Log::Endl;
            return false;
        }
    }

    for (auto& entry : fs::recursive_directory_iterator(coreclrPath)) {
        if (entry.is_directory() || !entry.is_regular_file()) continue;
        auto relativePath = fs::relative( entry.path(), coreclrStdPath ).generic_string();
        Log::Info << "Checking if " << relativePath << " is in the json" << Log::Endl;
        if (!hashList.contains(relativePath)) {
            Log::Warning << "File " << entry.path() << " is not in update.json" << Log::Endl;
            if (!fs::remove(entry.path())) {
                throw LoadException("Failed to remove file " + entry.path().string());
            }
        }
    }

    return true;
}

void CoreCLR::Download(Ref<alt::IHttpClient> httpClient) const {
    auto attempt = 0;

    while (true) {
        if (attempt++ >= 6) throw LoadException("Failed to download CoreCLR after " + std::to_string(attempt) + " attempts");
        
        Log::Info << "Downloading CoreCLR (attempt " << attempt << ")" << Log::Endl;
        
        const auto response = download_file_sync(httpClient, "https://github.com/FabianTerhorst/coreclr-module/releases/download/10.0.49-dev/csharp-module-client.zip");
        Log::Info << "Update finished" << Log::Endl;
            
        const auto folderPath = get_clr_folder_path();
        if (!fs::exists(folderPath)) fs::create_directory(folderPath);
            
        std::istringstream is(response.body, ios::binary);
        Log::Info << "Extracting zip" << Log::Endl;
            
        try {
            miniz_cpp::zip_file zip(is);
            zip.extractall(folderPath);
            Log::Info << "Extract finished" << Log::Endl;
            return;
        } catch (std::runtime_error& e) {
            Log::Error << "Failed to extract zip: " << e.what() << Log::Endl;
        }
    }
}

void CoreCLR::Update(alt::IResource* resource) const {
    const auto httpClient = _core->CreateHttpClient(resource);

    auto attempt = 0;
    while (!Validate(httpClient)) {
        if (attempt++ >= 3) throw LoadException("Failed to confirm CoreCLR download after " + std::to_string(attempt) + " attempts");
        Download(httpClient);
    }
}

void CoreCLR::Initialize() {
    if (initialized) return;
    Log::Info << "Initializing CoreCLR" << Log::Endl;

    const auto hostfxrPath = find_hostfxr();
    Log::Info << "Hostfxr found: " << hostfxrPath << Log::Endl;

    const auto runtimeconfigPath = find_runtimeconfig();
    Log::Info << "Runtimeconfig path found: " << utils::wstring_to_string(runtimeconfigPath) << Log::Endl;

    _coreClrLib = LoadLibraryA(hostfxrPath.c_str());

    _initializeFxr = (hostfxr_initialize_for_runtime_config_fn) GetProcAddress(_coreClrLib,
                                                                               "hostfxr_initialize_for_runtime_config");
    _getDelegate = (hostfxr_get_runtime_delegate_fn) GetProcAddress(_coreClrLib, "hostfxr_get_runtime_delegate");
    _runApp = (hostfxr_run_app_fn) GetProcAddress(_coreClrLib, "hostfxr_run_app");
    _initForCmd = (hostfxr_initialize_for_dotnet_command_line_fn) GetProcAddress(_coreClrLib,
                                                                                 "hostfxr_initialize_for_dotnet_command_line");
    _closeFxr = (hostfxr_close_fn) GetProcAddress(_coreClrLib, "hostfxr_close");

    if (!_initializeFxr || !_getDelegate || !_closeFxr || !_runApp || !_initForCmd)
        throw LoadException("Unable to find CoreCLR dll methods");

    InitializeCoreclr(utils::get_string_t(runtimeconfigPath));

    component_entry_point_fn hostInitDelegate = nullptr;

    const auto hostDllPath = find_host_dll();

    Log::Info << "Host dll path found: " << utils::wstring_to_string(hostDllPath) << Log::Endl;
    const string_t hostDllPathT = utils::get_string_t(hostDllPath);

    const int rc = _loadAssembly(hostDllPathT.c_str(), STR("AltV.Net.Client.Host.Host, AltV.Net.Client.Host"),
                                 STR("Initialize"), nullptr, nullptr, (void **) &hostInitDelegate);
    if (rc != 0 || hostInitDelegate == nullptr) {
        std::stringstream error;
        error << "Cannot load Host dll. Return code: " << std::hex << std::showbase << rc << std::endl;
        throw LoadException(error.str());
    }

    Log::Info << "Executing method from Host dll" << Log::Endl;

    struct init_args {
        const alt::ICore* corePtr;
    };
    init_args initArgs {_core};
    const auto t = hostInitDelegate(&initArgs, sizeof(initArgs));

    Log::Info << "Host init exit code: " << to_string(t) << Log::Endl;
    if (t != 0) abort(); // todo maybe somehow disconnect and show error

    initialized = true;
}

void CoreCLR::StartResource(alt::IResource *resource, alt::ICore* core) {
    const auto path = utils::string_to_wstring(resource->GetMain());

    struct start_args {
        const wchar_t *mainFilePath;
        const alt::IResource *resourcePtr;
        const alt::ICore *corePtr;
    };
    start_args startArgs{path.c_str(), resource, core};

    load_resource_delegate(&startArgs, sizeof(startArgs));
}

void CoreCLR::StopResource(alt::IResource *resource) {
    struct stop_args {
        const alt::IResource *resourcePtr;
    };
    stop_args stopArgs{resource};

    stop_resource_delegate(&stopArgs, sizeof(stopArgs));
}

// ReSharper disable once CppInconsistentNaming
EXPORT void SetResourceLoadDelegates(const CoreClrDelegate_t resourceExecute, const CoreClrDelegate_t resourceExecuteUnload,
                                     const CoreClrDelegate_t stopRuntime) {
    if (load_resource_delegate || stop_resource_delegate || stop_runtime_delegate) {
        abort(); // developer tried to call that method from resource XD
    }

    load_resource_delegate = resourceExecute;
    stop_resource_delegate = resourceExecuteUnload;
    stop_runtime_delegate = stopRuntime;
}
