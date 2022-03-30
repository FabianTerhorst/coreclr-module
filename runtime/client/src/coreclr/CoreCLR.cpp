#include "coreclr/nethost.h"
#include "CoreCLR.h"
#include "../../../cpp-sdk/SDK.h"
#include <windows.h>
#include "coreclr/hostfxr.h"
#include <string>
#include <sstream>
#include "exceptions/LoadException.h"
#include "coreclr/coreclr_delegates.h"
#include "utils.h"
#include "Log.h"

using namespace alt;
using namespace std;

CoreClrDelegate_t loadResourceDelegate = nullptr;
CoreClrDelegate_t stopResourceDelegate = nullptr;
CoreClrDelegate_t stopRuntimeDelegate = nullptr;

namespace {
    std::string find_hostfxr() {
        char_t buffer[MAX_PATH];
        size_t buffer_size = sizeof(buffer) / sizeof(char_t);

        int rc = get_hostfxr_path(buffer, &buffer_size, nullptr);
        if (rc != 0) throw LoadException("Failed to find hostfxr.dll");

        return {buffer, buffer + buffer_size};
    }

    std::wstring find_runtimeconfig() {
        std::wstring runtimeconfig_path = utils::get_current_dll_path();
        auto pos = runtimeconfig_path.find_last_of('\\');
        if (pos == std::wstring::npos) throw LoadException("Unable to find runtimeconfig.json");
        return runtimeconfig_path.substr(0, pos + 1) + L"AltV.Net.Client.runtimeconfig.json";
    }

    std::wstring find_host_dll() {
        std::wstring debug_dll_path = utils::get_current_dll_path();
        auto pos = debug_dll_path.find_last_of('\\');
        if (pos == std::wstring::npos) throw LoadException("Unable to find host dll");
        return debug_dll_path.substr(0, pos + 1) + L"AltV.Net.Client.Host.dll";
    }
}  // namespace

void CoreCLR::initialize_coreclr(const string_t &runtimeconfig_path) {
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
    Log::Info << "Initializing CoreCLR" << Log::Endl;

    auto hostfxr_path = find_hostfxr();
    Log::Info << "Hostfxr found: " << hostfxr_path << Log::Endl;

    auto runtimeconfig_path = find_runtimeconfig();
    Log::Info << "Runtimeconfig path found: " << utils::wstring_to_string(runtimeconfig_path) << Log::Endl;

    _coreClrLib = LoadLibraryA(hostfxr_path.c_str());

    _initializeFxr = (hostfxr_initialize_for_runtime_config_fn) GetProcAddress(_coreClrLib,
                                                                               "hostfxr_initialize_for_runtime_config");
    _getDelegate = (hostfxr_get_runtime_delegate_fn) GetProcAddress(_coreClrLib, "hostfxr_get_runtime_delegate");
    _runApp = (hostfxr_run_app_fn) GetProcAddress(_coreClrLib, "hostfxr_run_app");
    _initForCmd = (hostfxr_initialize_for_dotnet_command_line_fn) GetProcAddress(_coreClrLib,
                                                                                 "hostfxr_initialize_for_dotnet_command_line");
    _closeFxr = (hostfxr_close_fn) GetProcAddress(_coreClrLib, "hostfxr_close");

    if (!_initializeFxr || !_getDelegate || !_closeFxr || !_runApp || !_initForCmd)
        throw LoadException("Unable to find CoreCLR dll methods");

    initialize_coreclr(utils::get_string_t(runtimeconfig_path));

    component_entry_point_fn hostInitDelegate = nullptr;

    auto host_dll_path = find_host_dll();

    Log::Info << "Host dll path found: " << utils::wstring_to_string(host_dll_path) << Log::Endl;
    string_t host_dll_path_t = utils::get_string_t(host_dll_path);

    int rc = _loadAssembly(host_dll_path_t.c_str(), STR("AltV.Net.Client.Host.Host, AltV.Net.Client.Host"),
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
    init_args initArgs {core};
    auto t = hostInitDelegate(&initArgs, sizeof(initArgs));

    cout << "Exit code: " << to_string(t) << endl;
}

void CoreCLR::start_resource(alt::IResource *resource, alt::ICore* core) {
    Log::Info << "Starting resource inner" << Log::Endl;
    auto path = utils::string_to_wstring(resource->GetMain().ToString());

    struct start_args {
        const wchar_t *mainFilePath;
        const alt::IResource *resourcePtr;
        const alt::ICore *corePtr;
    };
    start_args startArgs{path.c_str(), resource, core};

    Log::Info << "Is delegate null " << (loadResourceDelegate == nullptr) << Log::Endl;
    loadResourceDelegate(&startArgs, sizeof(startArgs));
}

void CoreCLR::stop_resource(alt::IResource *resource) {
    struct stop_args {
        const alt::IResource *resourcePtr;
    };
    stop_args stopArgs{resource};

    stopResourceDelegate(&stopArgs, sizeof(stopArgs));
}

EXPORT void SetResourceLoadDelegates(CoreClrDelegate_t resourceExecute, CoreClrDelegate_t resourceExecuteUnload,
                                     CoreClrDelegate_t stopRuntime) {
    Log::Info << "Set delegates!! YAY!" << Log::Endl;
    if (loadResourceDelegate || stopResourceDelegate || stopRuntimeDelegate) {
        abort(); // developer tried to call that method from resource XD
    }

    loadResourceDelegate = resourceExecute;
    stopResourceDelegate = resourceExecuteUnload;
    stopRuntimeDelegate = stopRuntime;
}
