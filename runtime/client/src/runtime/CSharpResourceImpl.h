#pragma once
#include <objidlbase.h>
#include "../../../cpp-sdk/SDK.h"
#include "./CSharpScriptRuntime.h"
#include "eventDelegates.h"
#include "../../../c-api/data/invoker.h"
#include "../../cpp-sdk/events/CLocalMetaDataChangeEvent.h"
#include "../../cpp-sdk/events/CWindowFocusChangeEvent.h"
#include "../../cpp-sdk/events/CWindowResolutionChangeEvent.h"
#include "../../cpp-sdk/events/CRmlEvent.h"
#include "../../cpp-sdk/events/CWebSocketClientEvent.h"

class CSharpResourceImpl : public alt::IResource::Impl
{
    CSharpScriptRuntime* runtime;
    alt::IResource* resource;
    alt::ICore* core;

    void ResetDelegates();

public:
    CSharpResourceImpl(CSharpScriptRuntime* runtime, alt::IResource* resource, alt::ICore* core) : runtime(runtime), resource(resource), core(core) {
        invokers = new alt::Array<CustomInvoker*>();
    };

    ~CSharpResourceImpl() = default;

    bool Start() override;
    bool Stop() override;

    void* GetEntityPointer(alt::IEntity* entity);

    bool OnEvent(const alt::CEvent* event) override;
    void OnTick() override;

    void OnCreateBaseObject(alt::Ref<alt::IBaseObject> object) override;
    void OnRemoveBaseObject(alt::Ref<alt::IBaseObject> object) override;

    alt::Array<CustomInvoker*>* invokers;

    TickDelegate_t OnTickDelegate = nullptr;
    ServerEventDelegate_t OnServerEventDelegate = nullptr;
    ClientEventDelegate_t OnClientEventDelegate = nullptr;
    WebViewEventDelegate_t OnWebViewEventDelegate = nullptr;
    ConsoleCommandDelegate_t OnConsoleCommandDelegate = nullptr;
    WebSocketEventDelegate_t OnWebSocketEventDelegate = nullptr;
    RmlEventDelegate_t OnRmlEventDelegate = nullptr;

    CreatePlayerDelegate_t OnCreatePlayerDelegate = nullptr;
    RemovePlayerDelegate_t OnRemovePlayerDelegate = nullptr;

    CreateVehicleDelegate_t OnCreateVehicleDelegate = nullptr;
    RemoveVehicleDelegate_t OnRemoveVehicleDelegate = nullptr;

    PlayerSpawnDelegate_t OnPlayerSpawnDelegate = nullptr;
    PlayerDisconnectDelegate_t OnPlayerDisconnectDelegate = nullptr;
    PlayerEnterVehicleDelegate_t OnPlayerEnterVehicleDelegate = nullptr;
    PlayerLeaveVehicleDelegate_t OnPlayerLeaveVehicleDelegate = nullptr;

    GameEntityCreateDelegate_t OnGameEntityCreateDelegate = nullptr;
    GameEntityDestroyDelegate_t OnGameEntityDestroyDelegate = nullptr;

    AnyResourceErrorDelegate_t OnAnyResourceErrorDelegate = nullptr;
    AnyResourceStartDelegate_t OnAnyResourceStartDelegate = nullptr;
    AnyResourceStopDelegate_t OnAnyResourceStopDelegate = nullptr;

    KeyUpDelegate_t OnKeyUpDelegate = nullptr;
    KeyDownDelegate_t OnKeyDownDelegate = nullptr;

    PlayerChangeVehicleSeatDelegate_t OnPlayerChangeVehicleSeatDelegate = nullptr;

    ConnectionCompleteDelegate_t OnConnectionCompleteDelegate = nullptr;

    GlobalMetaChangeDelegate_t OnGlobalMetaChangeDelegate = nullptr;
    GlobalSyncedMetaChangeDelegate_t OnGlobalSyncedMetaChangeDelegate = nullptr;
    LocalMetaChangeDelegate_t OnLocalMetaChangeDelegate = nullptr;
    StreamSyncedMetaChangeDelegate_t OnStreamSyncedMetaChangeDelegate = nullptr;
    SyncedMetaChangeDelegate_t OnSyncedMetaChangeDelegate = nullptr;

    NetOwnerChangeDelegate_t OnNetOwnerChangeDelegate = nullptr;
    RemoveEntityDelegate_t OnRemoveEntityDelegate = nullptr;

    TaskChangeDelegate_t OnTaskChangeDelegate = nullptr;

    WindowFocusChangeDelegate_t OnWindowFocusChangeDelegate = nullptr;
    WindowResolutionChangeDelegate_t OnWindowResolutionChangeDelegate = nullptr;
    


    bool MakeClient(alt::IResource::CreationInfo* info, alt::Array<std::string> files)
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
    std::string ReadFile(std::string path);
};