#pragma once
#include <objidlbase.h>
#include "../../thirdparty/altv-cpp-api/SDK.h"
#include "./CSharpScriptRuntime.h"
#include "eventDelegates.h"

class CSharpResourceImpl : public alt::IResource::Impl
{
    CSharpScriptRuntime* runtime;
    alt::IResource* resource;
    alt::ICore* core;

    void ResetDelegates();

public:
    CSharpResourceImpl(CSharpScriptRuntime* runtime, alt::IResource* resource, alt::ICore* core) : runtime(runtime), resource(resource), core(core) {};
    ~CSharpResourceImpl() = default;

    bool Start() override;
    bool Stop() override;

    bool OnEvent(const alt::CEvent* event) override;
    void OnTick() override;

    void OnCreateBaseObject(alt::Ref<alt::IBaseObject> object) override;
    void OnRemoveBaseObject(alt::Ref<alt::IBaseObject> object) override;

    TickDelegate_t OnTickDelegate = nullptr;
    ServerEventDelegate_t OnServerEventDelegate = nullptr;
    ClientEventDelegate_t OnClientEventDelegate = nullptr;
    ConsoleCommandDelegate_t OnConsoleCommandDelegate = nullptr;

    CreatePlayerDelegate_t OnCreatePlayerDelegate = nullptr;
    RemovePlayerDelegate_t OnRemovePlayerDelegate = nullptr;

    CreateVehicleDelegate_t OnCreateVehicleDelegate = nullptr;
    RemoveVehicleDelegate_t OnRemoveVehicleDelegate = nullptr;

    PlayerSpawnDelegate_t OnPlayerSpawnDelegate = nullptr;
    PlayerDisconnectDelegate_t OnPlayerDisconnectDelegate = nullptr;
    PlayerEnterVehicleDelegate_t OnPlayerEnterVehicleDelegate = nullptr;



    bool MakeClient(alt::IResource::CreationInfo* info, alt::Array<alt::String> files)
    {
        // When also having a client module that is inteded to be used with this module,
        // change uncomment the next line and change to your own module type
        // info->type = "bp";
        return true;
    }

    // Gets the alt:V IResource instance
    alt::IResource* GetIResource()
    {
        return resource;
    }
    // Gets the module runtime that instantiated this resource
    CSharpScriptRuntime* GetRuntime()
    {
        return runtime;
    }

    // Yoinked from v8 helpers
    int64_t GetTime()
    {
        return std::chrono::duration_cast<std::chrono::milliseconds>(std::chrono::steady_clock::now().time_since_epoch()).count();
    }

    // Reads a file using the alt:V API, so it works both on server- and clientside
    alt::String ReadFile(alt::String path);
};