#pragma once

#include <string>
#include <set>

#include <coreclr/coreclrhost.h>

#ifdef _WIN32
#include <windows.h>
#endif

typedef void (*MainMethod)();

class ClrHost
{
  private:
#ifdef _WIN32
    HMODULE _coreClrLib;
#else
    void *_coreClrLib;
#endif

    coreclr_initialize_ptr _initializeCoreCLR;
    coreclr_shutdown_2_ptr _shutdownCoreCLR;
    coreclr_create_delegate_ptr _createDelegate;

    void *_runtimeHost;
    unsigned int _domainId;

    MainMethod _mainCallback;

  public:
    ClrHost();
    virtual ~ClrHost();

    bool load();
    void unload();

    MainMethod mainCallback() const;

  private:
    bool loadCoreClr();
    bool createAppDomain();

    std::set<std::string> getTrustedAssemblies();
    bool getDelegate(std::string methodName, void **callback);

    std::string getAbsolutePath(std::string relativePath);
    std::string getFilenameWithoutExtension(std::string filename);
};