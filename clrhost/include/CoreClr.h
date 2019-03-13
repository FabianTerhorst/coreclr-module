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

#include <altv-cpp-api/SDK.h>
#include <coreclr/coreclrhost.h>
#include <sys/stat.h>
#include <string.h>

#ifdef _WIN32
#define LIST_SEPARATOR ";"
#define strtok_r strtok_s
#else
#define LIST_SEPARATOR ":"
#endif

#define TAIL_CMP_LT -1
#define TAIL_CMP_EQ  0
#define TAIL_CMP_GT +1
#define TAIL_CMP_KO  9

int tail_cmp(char* lhs, char* rhs);

int tail_lt(char* lhs, char* rhs);

int tail_eq(char* lhs, char* rhs);

int tail_gt(char* lhs, char* rhs);

class CoreClr {
public:
    CoreClr(alt::IServer* server);

    ~CoreClr();

    bool GetDelegate(alt::IServer* server, void* runtimeHost, unsigned int domainId, const char* moduleName,
                     const char* classPath, const char* methodName, void** callback);

    alt::Array<alt::String> getTrustedAssemblies(alt::IServer* server, const char* appPath);

    void CreateAppDomain(alt::IServer* server, const char* appPath, void** runtimeHost,
                         unsigned int* domainId);

    void Shutdown(alt::IServer* server, void* runtimeHost,
                  unsigned int domainId);

    void GetPath(alt::IServer* server, const char* defaultPath);

private:
#ifdef _WIN32
    HMODULE _coreClrLib;
#else
    void* _coreClrLib;
#endif
    char* runtimeDirectory;
    coreclr_initialize_ptr _initializeCoreCLR;
    coreclr_shutdown_2_ptr _shutdownCoreCLR;
    coreclr_create_delegate_ptr _createDelegate;
    coreclr_execute_assembly_ptr _executeAssembly;
};
