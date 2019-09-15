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
#include "../src/altv-c-api/position.h"

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

typedef void (* CreateVoiceChannelDelegate_t)(alt::IVoiceChannel* channel);

typedef void (* RemoveVoiceChannelDelegate_t)(alt::IVoiceChannel* channel);

typedef void (* CreateColShapeDelegate_t)(alt::IColShape* colShape);

typedef void (* RemoveColShapeDelegate_t)(alt::IColShape* colShape);

typedef void (* ConsoleCommandDelegate_t)(const char* name, alt::Array<alt::StringView>* args);

typedef void (* MetaChangeDelegate_t)(void* entity, alt::IBaseObject::Type type, alt::StringView key,
                                      alt::MValue* value);

typedef void (* ColShapeDelegate_t)(alt::IColShape* colShape, void* entity, alt::IBaseObject::Type baseObjectType,
                                    bool state);

typedef void (* WeaponDamageDelegate_t)(alt::IPlayer* source, void* target, alt::IBaseObject::Type targetBaseObjectType,
                                        uint32_t weaponHash, uint16_t damageValue, position_t shotOffset,
                                        alt::CWeaponDamageEvent::BodyPart bodyPart);

typedef void (* ExplosionDelegate_t)(alt::IPlayer* source, alt::CExplosionEvent::ExplosionType explosionType,
                                     position_t position, uint32_t explosionFX);

class CSharpResourceImpl : public alt::IResource::Impl {
    bool OnEvent(const alt::CEvent* ev) override;

    void OnTick() override;

    bool Start() override;

    bool Stop() override;

    void OnCreateBaseObject(alt::IBaseObject* object) override;

    void OnRemoveBaseObject(alt::IBaseObject* object) override;

    void* GetBaseObjectPointer(alt::IBaseObject* baseObject);

    void* GetEntityPointer(alt::IEntity* entity);

    void ResetDelegates();

public:
    CSharpResourceImpl(alt::ICore* server, CoreClr* coreClr, alt::IResource* resource);

    ~CSharpResourceImpl() override;

    bool MakeClient(alt::IResource::CreationInfo* info, alt::Array<alt::String> files) override;

    CheckpointDelegate_t OnCheckpointDelegate = nullptr;

    ClientEventDelegate_t OnClientEventDelegate = nullptr;

    PlayerConnectDelegate_t OnPlayerConnectDelegate = nullptr;

    PlayerDamageDelegate_t OnPlayerDamageDelegate = nullptr;

    PlayerDeathDelegate_t OnPlayerDeathDelegate = nullptr;

    ExplosionDelegate_t OnExplosionDelegate = nullptr;

    WeaponDamageDelegate_t OnWeaponDamageDelegate = nullptr;

    PlayerDisconnectDelegate_t OnPlayerDisconnectDelegate = nullptr;

    PlayerRemoveDelegate_t OnPlayerRemoveDelegate = nullptr;

    VehicleRemoveDelegate_t OnVehicleRemoveDelegate = nullptr;

    ServerEventDelegate_t OnServerEventDelegate = nullptr;

    PlayerChangeVehicleSeatDelegate_t OnPlayerChangeVehicleSeatDelegate = nullptr;

    PlayerEnterVehicleDelegate_t OnPlayerEnterVehicleDelegate = nullptr;

    PlayerLeaveVehicleDelegate_t OnPlayerLeaveVehicleDelegate = nullptr;

    StopDelegate_t OnStopDelegate = nullptr;

    MainDelegate_t MainDelegate = nullptr;

    TickDelegate_t OnTickDelegate = nullptr;

    CreatePlayerDelegate_t OnCreatePlayerDelegate = nullptr;

    RemovePlayerDelegate_t OnRemovePlayerDelegate = nullptr;

    CreateVehicleDelegate_t OnCreateVehicleDelegate = nullptr;

    RemoveVehicleDelegate_t OnRemoveVehicleDelegate = nullptr;

    CreateBlipDelegate_t OnCreateBlipDelegate = nullptr;

    RemoveBlipDelegate_t OnRemoveBlipDelegate = nullptr;

    CreateCheckpointDelegate_t OnCreateCheckpointDelegate = nullptr;

    RemoveCheckpointDelegate_t OnRemoveCheckpointDelegate = nullptr;

    CreateVoiceChannelDelegate_t OnCreateVoiceChannelDelegate = nullptr;

    RemoveVoiceChannelDelegate_t OnRemoveVoiceChannelDelegate = nullptr;

    ConsoleCommandDelegate_t OnConsoleCommandDelegate = nullptr;

    MetaChangeDelegate_t OnMetaChangeDelegate = nullptr;

    MetaChangeDelegate_t OnSyncedMetaChangeDelegate = nullptr;

    CreateColShapeDelegate_t OnCreateColShapeDelegate = nullptr;

    RemoveColShapeDelegate_t OnRemoveColShapeDelegate = nullptr;

    ColShapeDelegate_t OnColShapeDelegate = nullptr;

    alt::Array<CustomInvoker*>* invokers;
    CoreClr* coreClr;
    alt::ICore* server;
    alt::IResource* resource;
};

EXPORT void CSharpResourceImpl_Reload(CSharpResourceImpl* resource);

EXPORT void CSharpResourceImpl_Load(CSharpResourceImpl* resource);

EXPORT void CSharpResourceImpl_Unload(CSharpResourceImpl* resource);

EXPORT void CSharpResourceImpl_SetMainDelegate(CSharpResourceImpl* resource,
                                               MainDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetStopDelegate(CSharpResourceImpl* resource,
                                               StopDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetTickDelegate(CSharpResourceImpl* resource,
                                               TickDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetServerEventDelegate(CSharpResourceImpl* resource,
                                                      ServerEventDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCheckpointDelegate(CSharpResourceImpl* resource,
                                                     CheckpointDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetClientEventDelegate(CSharpResourceImpl* resource,
                                                      ClientEventDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerDamageDelegate(CSharpResourceImpl* resource,
                                                       PlayerDamageDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerConnectDelegate(CSharpResourceImpl* resource,
                                                        PlayerConnectDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerDeathDelegate(CSharpResourceImpl* resource,
                                                      PlayerDeathDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetExplosionDelegate(CSharpResourceImpl* resource,
                                                    ExplosionDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetWeaponDamageDelegate(CSharpResourceImpl* resource,
                                                       WeaponDamageDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerDisconnectDelegate(CSharpResourceImpl* resource,
                                                           PlayerDisconnectDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerRemoveDelegate(CSharpResourceImpl* resource,
                                                       PlayerRemoveDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetVehicleRemoveDelegate(CSharpResourceImpl* resource,
                                                        VehicleRemoveDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(CSharpResourceImpl* resource,
                                                                  PlayerChangeVehicleSeatDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerEnterVehicleDelegate(CSharpResourceImpl* resource,
                                                             PlayerEnterVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(CSharpResourceImpl* resource,
                                                             PlayerLeaveVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreatePlayerDelegate(CSharpResourceImpl* resource,
                                                       CreatePlayerDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemovePlayerDelegate(CSharpResourceImpl* resource,
                                                       RemovePlayerDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateVehicleDelegate(CSharpResourceImpl* resource,
                                                        CreateVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,
                                                        RemoveVehicleDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateBlipDelegate(CSharpResourceImpl* resource,
                                                     CreateBlipDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveBlipDelegate(CSharpResourceImpl* resource,
                                                     RemoveBlipDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateCheckpointDelegate(CSharpResourceImpl* resource,
                                                           CreateCheckpointDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveCheckpointDelegate(CSharpResourceImpl* resource,
                                                           RemoveCheckpointDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                             CreateVoiceChannelDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                             RemoveVoiceChannelDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetConsoleCommandDelegate(CSharpResourceImpl* resource,
                                                         ConsoleCommandDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetMetaChangeDelegate(CSharpResourceImpl* resource,
                                                     MetaChangeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetSyncedMetaChangeDelegate(CSharpResourceImpl* resource,
                                                           MetaChangeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetCreateColShapeDelegate(CSharpResourceImpl* resource,
                                                         CreateColShapeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetRemoveColShapeDelegate(CSharpResourceImpl* resource,
                                                         RemoveColShapeDelegate_t delegate);

EXPORT void CSharpResourceImpl_SetColShapeDelegate(CSharpResourceImpl* resource,
                                                   ColShapeDelegate_t delegate);