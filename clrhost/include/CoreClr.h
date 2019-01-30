#pragma once

#include <dlfcn.h>
#include <altv-cpp-api/IServer.h>
#include <coreclr/coreclrhost.h>
#include <dirent.h>
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

    bool GetDelegate(alt::IServer *server, void *runtimeHost, unsigned int domainId, const char *moduleName,
                     const char *classPath, const char *methodName, void **callback);

    alt::Array<alt::String> getTrustedAssemblies(alt::IServer *server);

    void CreateAppDomain(alt::IServer *server, const char *appPath, const char *libraryPath, void **runtimeHost,
                         unsigned int *domainId);

    void Shutdown(alt::IServer *server, void *runtimeHost,
                           unsigned int domainId);

  private:
    void *_coreClrLib;
    coreclr_initialize_ptr _initializeCoreCLR;
    coreclr_shutdown_2_ptr _shutdownCoreCLR;
    coreclr_create_delegate_ptr _createDelegate;
};
