#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include <altv-cpp-api/events/CMetaDataChangeEvent.h>
#include <altv-cpp-api/events/CSyncedMetaDataChangeEvent.h>

#ifdef _WIN32
#define RESOURCES_PATH "\\resources\\"
#define ASSEMBLY_PATH "\\assembly.cfg"
#else
#define RESOURCES_PATH "/resources/"
#define ASSEMBLY_PATH "/assembly.cfg"
#endif

#ifdef _WIN32
#include <iostream>
#include <stdio.h>
#include <direct.h>
#else

#include <unistd.h>

#endif

#include "CoreClr.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef void (* MValueFunctionCallback)(alt::MValueList*, alt::MValue*);

class CustomInvoker : public alt::MValueFunction::Invoker {
public:
    MValueFunctionCallback mValueFunctionCallback;

    explicit CustomInvoker(MValueFunctionCallback mValueFunctionCallback) {
        this->mValueFunctionCallback = mValueFunctionCallback;
    }

    alt::MValue Invoke(alt::MValueList args) override {
        //auto list = args.Get<alt::MValue::List>();
        alt::MValue result;
        mValueFunctionCallback(&args, &result);
        return result;
    }
};

typedef void (* MainDelegate_t)(alt::ICore* server, alt::IResource* resource, const char* resourceName,
                                const char* entryPoint);

typedef void (* TickDelegate_t)();

typedef void (* ServerEventDelegate_t)(const char* name, alt::Array<alt::MValue>* args);

typedef void (* CheckpointDelegate_t)(alt::ICheckpoint* checkpoint, void* entity, alt::IBaseObject::Type type,
                                      bool state);

typedef void (* ClientEventDelegate_t)(alt::IPlayer* player, const char* name, alt::Array<alt::MValue>* args);

typedef void (* PlayerConnectDelegate_t)(alt::IPlayer* player, uint16_t playerId, const char* reason);

typedef void (* PlayerDamageDelegate_t)(alt::IPlayer* player, void* attacker,
                                        alt::IBaseObject::Type attackerType, uint16_t attackerId, uint32_t weapon,
                                        uint16_t damage);

typedef void (* PlayerDeathDelegate_t)(alt::IPlayer* player, void* killer, alt::IBaseObject::Type killerType,
                                       uint32_t weapon);

typedef void (* PlayerDisconnectDelegate_t)(alt::IPlayer* player, const char* reason);

typedef void (* PlayerRemoveDelegate_t)(alt::IPlayer* player);

typedef void (* VehicleRemoveDelegate_t)(alt::IVehicle* vehicle);

typedef void (* PlayerChangeVehicleSeatDelegate_t)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t oldSeat,
                                                   uint8_t newSeat);

typedef void (* PlayerEnterVehicleDelegate_t)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t seat);

typedef void (* PlayerLeaveVehicleDelegate_t)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t seat);

typedef void (* StopDelegate_t)();

typedef void (* CreatePlayerDelegate_t)(alt::IPlayer* player, uint16_t id);

typedef void (* RemovePlayerDelegate_t)(alt::IPlayer* player);

typedef void (* CreateVehicleDelegate_t)(alt::IVehicle* vehicle, uint16_t id);

typedef void (* RemoveVehicleDelegate_t)(alt::IVehicle* vehicle);

typedef void (* CreateBlipDelegate_t)(alt::IBlip* blip);

typedef void (* RemoveBlipDelegate_t)(alt::IBlip* blip);

typedef void (* CreateCheckpointDelegate_t)(alt::ICheckpoint* checkpoint);

typedef void (* RemoveCheckpointDelegate_t)(alt::ICheckpoint* checkpoint);

typedef void (* OnCreateVoiceChannelDelegate_t)(alt::IVoiceChannel* channel);

typedef void (* OnRemoveVoiceChannelDelegate_t)(alt::IVoiceChannel* channel);

typedef void (* OnCreateColShapeDelegate_t)(alt::IColShape* colShape);

typedef void (* OnRemoveColShapeDelegate_t)(alt::IColShape* colShape);

typedef void (* OnConsoleCommandDelegate_t)(const char* name, alt::Array<alt::StringView>* args);

typedef void (* MetaChangeDelegate_t)(void* entity, alt::IBaseObject::Type type, alt::StringView key,
                                      alt::MValue* value);

typedef void (* ColShapeDelegate_t)(alt::IColShape* colShape, void* entity, alt::IBaseObject::Type baseObjectType,
                                    bool state);

class CSharpResourceImpl : public alt::IResource::Impl {
    bool OnEvent(const alt::CEvent* ev) override;

    void OnTick() override;

    bool Start() override;

    bool Stop() override;

    void OnCreateBaseObject(alt::IBaseObject* object) override;

    void OnRemoveBaseObject(alt::IBaseObject* object) override;

    void* GetBaseObjectPointer(alt::IBaseObject* baseObject);

    void* GetEntityPointer(alt::IEntity* entity);

public:
    CSharpResourceImpl(alt::ICore* server, CoreClr* coreClr, alt::IResource* resource);

    ~CSharpResourceImpl() override;

    bool MakeClient(alt::IResource::CreationInfo* info, alt::Array<alt::String> files) override;

    CheckpointDelegate_t OnCheckpointDelegate;

    ClientEventDelegate_t OnClientEventDelegate;

    PlayerConnectDelegate_t OnPlayerConnectDelegate;

    PlayerDamageDelegate_t OnPlayerDamageDelegate;

    PlayerDeathDelegate_t OnPlayerDeathDelegate;

    PlayerDisconnectDelegate_t OnPlayerDisconnectDelegate;

    PlayerRemoveDelegate_t OnPlayerRemoveDelegate;

    VehicleRemoveDelegate_t OnVehicleRemoveDelegate;

    ServerEventDelegate_t OnServerEventDelegate;

    PlayerChangeVehicleSeatDelegate_t OnPlayerChangeVehicleSeatDelegate;

    PlayerEnterVehicleDelegate_t OnPlayerEnterVehicleDelegate;

    PlayerLeaveVehicleDelegate_t OnPlayerLeaveVehicleDelegate;

    StopDelegate_t OnStopDelegate;

    MainDelegate_t MainDelegate;

    TickDelegate_t OnTickDelegate;

    CreatePlayerDelegate_t OnCreatePlayerDelegate;

    RemovePlayerDelegate_t OnRemovePlayerDelegate;

    CreateVehicleDelegate_t OnCreateVehicleDelegate;

    RemoveVehicleDelegate_t OnRemoveVehicleDelegate;

    CreateBlipDelegate_t OnCreateBlipDelegate;

    RemoveBlipDelegate_t OnRemoveBlipDelegate;

    CreateCheckpointDelegate_t OnCreateCheckpointDelegate;

    RemoveCheckpointDelegate_t OnRemoveCheckpointDelegate;

    OnCreateVoiceChannelDelegate_t OnCreateVoiceChannelDelegate;

    OnRemoveVoiceChannelDelegate_t OnRemoveVoiceChannelDelegate;

    OnConsoleCommandDelegate_t OnConsoleCommandDelegate;

    MetaChangeDelegate_t OnMetaChangeDelegate;

    MetaChangeDelegate_t OnSyncedMetaChangeDelegate;

    OnCreateColShapeDelegate_t OnCreateColShapeDelegate;

    OnRemoveColShapeDelegate_t OnRemoveColShapeDelegate;

    ColShapeDelegate_t ColShapeDelegate;

    void* runtimeHost;
    unsigned int domainId;

    alt::Array<CustomInvoker*>* invokers;
    CoreClr* coreClr;
    alt::ICore* server;
    alt::IResource* resource;
};

EXPORT void Server_GetCSharpResource(alt::ICore* server, const char* resourceName, CSharpResourceImpl*&resource);
EXPORT void CSharpResource_Reload(CSharpResourceImpl* resource);

EXPORT void CSharpResource_Load(CSharpResourceImpl* resource);

EXPORT void CSharpResource_Unload(CSharpResourceImpl* resource);

EXPORT void CSharpResource_SetMain(CSharpResourceImpl* resource,
                                   MainDelegate_t mainDelegate,
                                   StopDelegate_t stopDelegate,
                                   TickDelegate_t tickDelegate,
                                   ServerEventDelegate_t serverEventDelegate,
                                   CheckpointDelegate_t checkpointDelegate,
                                   ClientEventDelegate_t clientEventDelegate,
                                   PlayerDamageDelegate_t playerDamageDelegate,
                                   PlayerConnectDelegate_t playerConnectDelegate,
                                   PlayerDeathDelegate_t playerDeathDelegate,
                                   PlayerDisconnectDelegate_t playerDisconnectDelegate,
                                   PlayerRemoveDelegate_t playerRemoveDelegate,
                                   VehicleRemoveDelegate_t vehicleRemoveDelegate,
                                   PlayerChangeVehicleSeatDelegate_t playerChangeVehicleSeatDelegate,
                                   PlayerEnterVehicleDelegate_t playerEnterVehicleDelegate,
                                   PlayerLeaveVehicleDelegate_t playerLeaveVehicleDelegate,
                                   CreatePlayerDelegate_t createPlayerDelegate,
                                   RemovePlayerDelegate_t removePlayerDelegate,
                                   CreateVehicleDelegate_t createVehicleDelegate,
                                   RemoveVehicleDelegate_t removeVehicleDelegate,
                                   CreateBlipDelegate_t createBlipDelegate,
                                   RemoveBlipDelegate_t removeBlipDelegate,
                                   CreateCheckpointDelegate_t createCheckpointDelegate,
                                   RemoveCheckpointDelegate_t removeCheckpointDelegate,
                                   OnCreateVoiceChannelDelegate_t createVoiceChannelDelegate,
                                   OnRemoveVoiceChannelDelegate_t removeVoiceChannelDelegate,
                                   OnConsoleCommandDelegate_t consoleCommandDelegate,
                                   MetaChangeDelegate_t metaChangeDelegate,
                                   MetaChangeDelegate_t syncedMetaChangeDelegate,
                                   OnCreateColShapeDelegate_t createColShapeDelegate,
                                   OnRemoveColShapeDelegate_t removeColShapeDelegate,
                                   ColShapeDelegate_t colShapeDelegate);