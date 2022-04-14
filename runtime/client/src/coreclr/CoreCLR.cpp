// ReSharper disable CppClangTidyClangDiagnosticCastFunctionType
#include "CoreCLR.h"

#include <future>

#include "../../../cpp-sdk/SDK.h"
#include <windows.h>
#include <string>
#include <sstream>
#include <filesystem>
#include "exceptions/LoadException.h"
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

#ifdef _WIN32
#define LIST_SEPARATOR ";"
#else
#define LIST_SEPARATOR ":"
#endif

namespace {
    fs::path get_main_directory_path() {
#ifdef DEBUG_CLIENT
        const auto debugDllPath = filesystem::path(utils::wstring_to_string(utils::get_current_dll_path()));
        return debugDllPath.parent_path().parent_path().parent_path().append("csharp-cache");
#else
        auto rootPath = filesystem::path(alt::ICore::Instance().GetClientPath());
        return rootPath.append("csharp-cache");
#endif
    }
    
    fs::path get_runtime_folder_path() {
        return get_main_directory_path().append("runtime");
    }

    fs::path get_coreclr_dll_path() {
        return get_runtime_folder_path().append("coreclr.dll");
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


std::string getTrustedAssemblies(const std::string runtimeFolder) {
    std::string assemblies;

    for (auto& entry : fs::recursive_directory_iterator(runtimeFolder)) {
        if (!entry.is_regular_file() || entry.is_directory()) continue;
        auto ext = entry.path().extension().string();
        if (ext != ".dll" && ext != ".exe" && ext != ".winmd") continue;
        assemblies += entry.path().generic_string();
        assemblies += LIST_SEPARATOR;
    }
    
    return assemblies;
}

void CoreCLR::InitializeCoreclr() {
    const auto runtimePath = get_runtime_folder_path().string();
    const auto mainDirectoryPath = get_main_directory_path().string();
    
    const auto tpaList = BuildTpaList(runtimePath);
    
    const char *propertyKeys[] = {
        "TRUSTED_PLATFORM_ASSEMBLIES",
        "APP_PATHS",
        "APP_NI_PATHS",
        "NATIVE_DLL_SEARCH_DIRECTORIES",
        "System.GC.Server",
        "System.Globalization.Invariant",
    };
    
    const char *propertyValues[] = {
        tpaList.c_str(),
        mainDirectoryPath.c_str(),
        mainDirectoryPath.c_str(),
        runtimePath.c_str(),
        "true",
        "true",
    };

    Log::Info << "Initializing CLR" << Log::Endl;
    const int rc = _initializeCoreClr(mainDirectoryPath.c_str(), "AltV Host", std::size(propertyKeys), propertyKeys, propertyValues, &_runtimeHost, &_domainId);
    
    if (rc != 0) {
        std::stringstream error;
        error << "Init failed: " << std::hex << std::showbase << rc << std::endl;
        throw LoadException(error.str());
    }

    Log::Info << "CLR initialized successfully" << Log::Endl;
}

CoreCLR::CoreCLR(alt::ICore* core) {
    Log::Info << "Constructing CoreCLR" << Log::Endl;
    _core = core;
}


bool CoreCLR::Validate(Ref<alt::IHttpClient> httpClient) const {
    auto const mainDirectoryPath = get_main_directory_path();
    if (!fs::exists(mainDirectoryPath)) return false;
    
    const auto updateFile = download_file_sync(httpClient, "https://cdn.block2play.com/coreclr/update.json");
    auto updateJson = nlohmann::json::parse(updateFile.body);
    // auto updateJson = nlohmann::json::parse(R"({"hashList":{"modules/coreclr-client-module/AltV.Net.Client.Host.dll":"3577aa14ae134aa0cc7758e004ba76b768f9b225"}})");
    const auto hashList = updateJson["hashList"];
    
    for (auto it = hashList.begin(); it != hashList.end(); ++it) {
        Log::Info << "Validating " << it.key() << Log::Endl;
        auto path = mainDirectoryPath;
        path.append(it.key());
        if (!fs::exists(path)) {
            Log::Warning << "File " << path.string() << " does not exist" << Log::Endl;
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

    for (auto& entry : fs::recursive_directory_iterator(mainDirectoryPath)) {
        if (entry.is_directory() || !entry.is_regular_file()) continue;
        auto relativePath = fs::relative( entry.path(), mainDirectoryPath ).generic_string();
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
        
        const auto response = download_file_sync(httpClient, "https://cdn.block2play.com/coreclr/csharp-cache.zip");
        Log::Info << "Update finished" << Log::Endl;
            
        const auto mainDirectoryPath = get_main_directory_path();
        if (!fs::exists(mainDirectoryPath)) fs::create_directory(mainDirectoryPath);
            
        std::istringstream is(response.body, ios::binary);
        Log::Info << "Extracting zip" << Log::Endl;
            
        try {
            miniz_cpp::zip_file zip(is);
            zip.extractall(mainDirectoryPath.string());
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

    const auto coreclrPath = get_coreclr_dll_path();
    Log::Info << "CoreCLR dll found: " << coreclrPath.string() << Log::Endl;

    _coreClrLib = LoadLibraryEx(coreclrPath.c_str(), nullptr, 0);
    Log::Info << "Loaded lib nice" << Log::Endl;

    _initializeCoreClr = (coreclr_initialize_ptr)GetProcAddress(_coreClrLib, "coreclr_initialize");
    _shutdownCoreClr = (coreclr_shutdown_2_ptr)GetProcAddress(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr)GetProcAddress(_coreClrLib, "coreclr_create_delegate");
    _executeAssembly = (coreclr_execute_assembly_ptr)GetProcAddress(_coreClrLib, "coreclr_execute_assembly");
    Log::Info << "Loaded delegates nice" << Log::Endl;

    if (!_initializeCoreClr || !_shutdownCoreClr || !_createDelegate || !_executeAssembly)
        throw LoadException("Unable to find CoreCLR dll methods");

    InitializeCoreclr();

    typedef void (* initialize_method)(alt::ICore* ptr);
    initialize_method hostInitDelegate = nullptr;

    const int rc = _createDelegate(_runtimeHost, _domainId, "AltV.Net.Client.Host", "AltV.Net.Client.Host.Host", "Initialize", (void **) &hostInitDelegate);
    if (rc != 0 || hostInitDelegate == nullptr) {
        std::stringstream error;
        error << "Cannot load Host dll. Return code: " << std::hex << std::showbase << rc << std::endl;
        throw LoadException(error.str());
    }

    Log::Info << "Executing method from Host dll" << Log::Endl;

    hostInitDelegate(_core);
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
