// ReSharper disable CppClangTidyClangDiagnosticCastFunctionType
#include "CoreCLR.h"
#include <future>
#include "../../../cpp-sdk/SDK.h"
#include <string>
#include <sstream>
#include <filesystem>
#include <fstream>
#include <Log.h>
#include <zip_file.hpp>

#include "utils.h"

using namespace alt;
using namespace std;

CoreClrDelegate_t load_resource_delegate = nullptr;
CoreClrDelegate_t stop_resource_delegate = nullptr;
CoreClrDelegate_t stop_runtime_delegate = nullptr;

std::filesystem::path CoreClr::GetMainDirectoryPath() {
#ifdef DEBUG_CLIENT
    const auto debugDllPath = filesystem::path(utils::wstring_to_string(utils::get_current_dll_path()));
    return debugDllPath.parent_path().parent_path().parent_path().append("csharp-cache");
#else
    auto rootPath = filesystem::path(alt::ICore::Instance().GetClientPath());
    return rootPath.append("csharp-cache");
#endif
}

std::filesystem::path CoreClr::GetLibrariesDirectoryPath() {
    return GetMainDirectoryPath().append("libraries");
}

std::filesystem::path CoreClr::GetDataDirectoryPath() {
    return GetMainDirectoryPath().append("data");
}

std::filesystem::path CoreClr::GetRuntimeDirectoryPath() {
    return GetDataDirectoryPath().append("runtime");
}

std::filesystem::path CoreClr::GetCoreClrDllPath() {
    return GetRuntimeDirectoryPath().append("coreclr.dll");
}

void CoreClr::InitializeCoreclr() {
    const auto runtimePath = GetRuntimeDirectoryPath().string();
    const auto clrDirectoryPath = GetDataDirectoryPath().string();
    
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
        clrDirectoryPath.c_str(),
        clrDirectoryPath.c_str(),
        runtimePath.c_str(),
        "true",
        "true",
    };

    Log::Info << "Initializing CLR" << Log::Endl;
    const int rc = _initializeCoreClr(clrDirectoryPath.c_str(), "AltV Host", std::size(propertyKeys), propertyKeys, propertyValues, &_runtimeHost, &_domainId);
    
    if (rc != 0) {
        std::stringstream error;
        error << "Init failed: " << std::hex << std::showbase << rc << std::endl;
        throw std::runtime_error(error.str());
    }

    Log::Info << "CLR initialized successfully" << Log::Endl;
}

CoreClr::CoreClr(alt::ICore* core) {
    Log::Info << "Constructing CoreCLR" << Log::Endl;
    _core = core;
}

void CoreClr::Initialize() {
    if (initialized) return;
    Log::Info << "Initializing CoreCLR" << Log::Endl;

    const auto coreclrPath = GetCoreClrDllPath();
    Log::Info << "CoreCLR dll found: " << coreclrPath.string() << Log::Endl;

    _coreClrLib = LoadLibraryEx(coreclrPath.c_str(), nullptr, 0);
    Log::Info << "Loaded lib nice" << Log::Endl;

    _initializeCoreClr = (coreclr_initialize_ptr)GetProcAddress(_coreClrLib, "coreclr_initialize");
    _shutdownCoreClr = (coreclr_shutdown_2_ptr)GetProcAddress(_coreClrLib, "coreclr_shutdown_2");
    _createDelegate = (coreclr_create_delegate_ptr)GetProcAddress(_coreClrLib, "coreclr_create_delegate");
    _executeAssembly = (coreclr_execute_assembly_ptr)GetProcAddress(_coreClrLib, "coreclr_execute_assembly");
    Log::Info << "Loaded delegates nice" << Log::Endl;

    if (!_initializeCoreClr || !_shutdownCoreClr || !_createDelegate || !_executeAssembly)
        throw std::runtime_error("Unable to find CoreCLR dll methods");

    InitializeCoreclr();

    typedef void (* initialize_method)(alt::ICore* ptr, uint8_t sandbox);
    initialize_method hostInitDelegate = nullptr;

    const int rc = _createDelegate(_runtimeHost, _domainId, "AltV.Net.Client.Host", "AltV.Net.Client.Host.Host", "Initialize", (void **) &hostInitDelegate);
    if (rc != 0 || hostInitDelegate == nullptr) {
        std::stringstream error;
        error << "Cannot load Host dll. Return code: " << std::hex << std::showbase << rc << std::endl;
        throw std::runtime_error(error.str());
    }

    Log::Info << "Executing method from Host dll" << Log::Endl;

    hostInitDelegate(_core, sandbox);
    initialized = true;
}

void CoreClr::StartResource(alt::IResource *resource, alt::ICore* core) {
    const auto path = utils::string_to_wstring(resource->GetMain());

    struct start_args {
        const wchar_t *mainFilePath;
        const alt::IResource *resourcePtr;
        const alt::ICore *corePtr;
    };
    start_args startArgs{path.c_str(), resource, core};

    load_resource_delegate(&startArgs, sizeof(startArgs));
}

void CoreClr::StopResource(alt::IResource *resource) {
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

// ReSharper disable once CppInconsistentNaming
EXPORT bool GetCachedAssembly(const char* name, int* bufferSize, void** buffer) {
    auto strName = std::string(name);
    const auto path = CoreClr::GetLibrariesDirectoryPath().append(utils::to_lower(strName) + ".nupkg");
    if (!exists(path)) return false;
    auto stream = std::ifstream(path, std::ios::binary);
    miniz_cpp::zip_file zip(stream);
    std::stringstream contentStream;
    auto fileName = std::string("lib/net6.0/") + name + ".dll";
    if (!zip.has_file(fileName)) {
        Log::Warning << "Nupkg was found, but no dll was found in it" << Log::Endl;
        zip.printdir();
        return false;
    }
    contentStream << zip.open(fileName).rdbuf();
    auto content = contentStream.str();
    
    *bufferSize = static_cast<int>(content.size());
    *buffer = utils::get_clr_value(content.data(), content.size());
    return true;
}
