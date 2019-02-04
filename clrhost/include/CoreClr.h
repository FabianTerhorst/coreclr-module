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

#include <altv-cpp-api/IServer.h>
#include <coreclr/coreclrhost.h>
#include <sys/stat.h>
#include <string.h>

#ifdef _WIN32
#define LIST_SEPARATOR ";"
#else
#define LIST_SEPARATOR ":"
#endif

class CoreClr
{
  public:
    CoreClr(alt::IServer *server);
    ~CoreClr();

    bool GetDelegate(alt::IServer *server, void *runtimeHost, unsigned int domainId, const char *moduleName,
                     const char *classPath, const char *methodName, void **callback);

    alt::Array<alt::String> getTrustedAssemblies(alt::IServer *server, const char *appPath);

    void CreateAppDomain(alt::IServer *server, const char *appPath, const char *libraryPath, void **runtimeHost,
                         unsigned int *domainId);

    void Shutdown(alt::IServer *server, void *runtimeHost,
                           unsigned int domainId);

  private:
#ifdef _WIN32
    HMODULE _coreClrLib;
#else
    void *_coreClrLib;
#endif
    char* runtimeDirectory;
    coreclr_initialize_ptr _initializeCoreCLR;
    coreclr_shutdown_2_ptr _shutdownCoreCLR;
    coreclr_create_delegate_ptr _createDelegate;
};
