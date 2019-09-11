#pragma once

#ifdef _WIN32
#include <Windows.h>
#include <direct.h>
//#include <shlobj_core.h>
#include <shlobj.h>
//#include <libloaderapi.h>
#include "dirent_win.h"
#else

#include <dirent.h>
#include <dlfcn.h>

#endif

#ifdef _WIN32

#define EXPORT EXTERN __declspec(dllexport)
#define IMPORT EXTERN __declspec(dllimport)

#else

#define EXPORT EXTERN __attribute__ ((visibility ("default")))
#define IMPORT

#endif // _WIN32

#include <coreclr/hostfxr.h>
#include <coreclr/coreclr_delegates.h>

// Host name
#ifdef _WIN32
#define HostDll "\\AltV.Net.Host.dll"
#define HostCfg "\\AltV.Net.Host.runtimeconfig.json"
#define HostExe "\\altv-server.exe"
#else
#define HostDll "/AltV.Net.Host.dll"
#define HostCfg "/AltV.Net.Host.runtimeconfig.json"
#define HostExe "/altv-server"
#endif

#ifdef _WIN32
#include <Windows.h>

#define STR(s) L ## s
#define CH(c) L ## c
#define DIR_SEPARATOR L'\\'

#else

#include <limits.h>

#define STR(s) s
#define CH(c) c
#define DIR_SEPARATOR '/'
#define MAX_PATH PATH_MAX

#endif

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#include <coreclr/coreclrhost.h>
#include <sys/stat.h>
#include <string.h>

#ifdef _WIN32
#define LIST_SEPARATOR ";"
#define strtok_r strtok_s
#define PATH_SEPARATOR "\\"
#else
#define LIST_SEPARATOR ":"
#define PATH_SEPARATOR "/"
#endif

#define TAIL_CMP_LT -1
#define TAIL_CMP_EQ  0
#define TAIL_CMP_GT +1
#define TAIL_CMP_KO  9

int tail_cmp(char* lhs, char* rhs);

int tail_lt(char* lhs, char* rhs);

int tail_eq(char* lhs, char* rhs);

int tail_gt(char* lhs, char* rhs);

typedef void (* ExecuteResourceDelegate_t)(const char* resourcePath, const char* resourceName, const char* resourceMain,
                                           int resourceIndex);

typedef int (* CoreClrDelegate_t)(void* args, int argsLength);

#include <thread>

class CoreClr {
public:
    CoreClr(alt::ICore* server);

    ~CoreClr();

    /*bool GetDelegate(alt::ICore* server, void* runtimeHost, unsigned int domainId, const char* moduleName,
                     const char* classPath, const char* methodName, void** callback);*/

    alt::Array<alt::String> getTrustedAssemblies(alt::ICore* server, const char* appPath);

    /*void CreateAppDomain(alt::ICore* server, alt::IResource* resource, const char* appPath, void** runtimeHost,
                         unsigned int* domainId, bool executable, uint64_t resourceIndex, const char* domainName);*/

    int Execute(alt::ICore* server, alt::IResource* resource, const char* appPath, uint64_t resourceIndex,
                void** runtimeHost,
                const unsigned int* domainId);

    void Shutdown(alt::ICore* server, void* runtimeHost,
                  unsigned int domainId);

    void GetPath(alt::ICore* server, const char* defaultPath);

    /**
     * prints out error when error code in known
     * @param server
     * @param errorCode
     * @return true when error code is known
     */
    bool PrintError(alt::ICore* server, int errorCode);

    void CreateManagedHost();

    void ExecuteManagedResource(alt::ICore* server, const char* resourcePath, const char* resourceName,
                                const char* resourceMain, alt::IResource* resource);

    void ExecuteManagedResourceUnload(alt::ICore* server, const char* resourcePath, const char* resourceMain);

private:
#ifdef _WIN32
    HMODULE _coreClrLib;
#else
    void* _coreClrLib;
#endif
    char* runtimeDirectory;
    char* dotnetDirectory;
    coreclr_initialize_ptr _initializeCoreCLR;
    coreclr_shutdown_2_ptr _shutdownCoreCLR;
    coreclr_create_delegate_ptr _createDelegate;
    coreclr_execute_assembly_ptr _executeAssembly;
    void* managedRuntimeHost;
    unsigned int managedDomainId;
    component_entry_point_fn ExecuteResourceDelegate;
    component_entry_point_fn ExecuteResourceUnloadDelegate;

    hostfxr_initialize_for_runtime_config_fn _initializeFxr;
    hostfxr_get_runtime_delegate_fn _getDelegate;
    hostfxr_run_app_fn _runApp;
    hostfxr_initialize_for_dotnet_command_line_fn _initForCmd;
    hostfxr_close_fn _closeFxr;
    hostfxr_handle cxt;
    std::thread thread;
};

EXPORT void CoreClr_SetResourceLoadDelegates(CoreClrDelegate_t resourceExecute, CoreClrDelegate_t resourceExecuteUnload);