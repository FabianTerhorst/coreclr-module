#pragma once
#define WIN32_LEAN_AND_MEAN
#define NOMINMAX
#include "utils.h"
#include "../../../cpp-sdk/ICore.h"
#include <coreclr.h>

typedef int (* CoreClrDelegate_t)(void* args, int argsLength);

class CoreCLR {
public:
    explicit CoreCLR(alt::ICore* core);

    bool initialized = false;
    void Initialize();
    void Update(alt::IResource* resource) const;
    static void StartResource(alt::IResource* resource, alt::ICore* core);
    static void StopResource(alt::IResource* resource);
    static std::string BuildTpaList(const std::string& runtimeDir);

private:
    alt::ICore* _core;
    HMODULE _coreClrLib = nullptr;
    coreclr_initialize_ptr _initializeCoreClr;
    coreclr_shutdown_2_ptr _shutdownCoreClr;
    coreclr_create_delegate_ptr _createDelegate;
    coreclr_execute_assembly_ptr _executeAssembly;
    
    void *_runtimeHost;
    unsigned int _domainId;

    [[nodiscard]] bool Validate(alt::Ref<alt::IHttpClient> httpClient) const;
    void Download(alt::Ref<alt::IHttpClient> httpClient) const;
    void InitializeCoreclr();
};