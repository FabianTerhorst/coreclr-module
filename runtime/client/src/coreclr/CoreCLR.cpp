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
#include <Log.h>

using namespace alt;
using namespace std;

CoreClrDelegate_t loadResourceDelegate = nullptr;
CoreClrDelegate_t stopResourceDelegate = nullptr;
CoreClrDelegate_t stopRuntimeDelegate = nullptr;

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

    cout << "Exit code: " << to_string(t) << endl;
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

    loadResourceDelegate(&startArgs, sizeof(startArgs));
}

void CoreCLR::StopResource(alt::IResource *resource) {
    struct stop_args {
        const alt::IResource *resourcePtr;
    };
    stop_args stopArgs{resource};

    stopResourceDelegate(&stopArgs, sizeof(stopArgs));
}

// ReSharper disable once CppInconsistentNaming
EXPORT void SetResourceLoadDelegates(const CoreClrDelegate_t resourceExecute, const CoreClrDelegate_t resourceExecuteUnload,
                                     const CoreClrDelegate_t stopRuntime) {
    if (loadResourceDelegate || stopResourceDelegate || stopRuntimeDelegate) {
        abort(); // developer tried to call that method from resource XD
    }

    loadResourceDelegate = resourceExecute;
    stopResourceDelegate = resourceExecuteUnload;
    stopRuntimeDelegate = stopRuntime;
}
