#include "CSharpResourceImpl.h"

CSharpResourceImpl::CSharpResourceImpl(alt::ICore* server, CoreClr* coreClr, alt::IResource* resource)
        : alt::IResource::Impl() {
    this->resource = resource;
    this->server = server;
    this->invokers = new alt::Array<CustomInvoker*>();
    this->coreClr = coreClr;
}

void CSharpResourceImpl::ResetDelegates() {
    MainDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnCheckpointDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnClientEventDelegate = [](auto var, auto var2, auto var3) {};
    OnPlayerConnectDelegate = [](auto var, auto var2, auto var3) {};
    OnPlayerDamageDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6) {};
    OnPlayerDeathDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    ExplosionDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    WeaponDamageDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6, auto var7) {};;
    OnPlayerDisconnectDelegate = [](auto var, auto var2) {};
    OnPlayerRemoveDelegate = [](auto var) {};
    OnVehicleRemoveDelegate = [](auto var) {};
    OnServerEventDelegate = [](auto var, auto var2) {};
    OnPlayerChangeVehicleSeatDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnPlayerEnterVehicleDelegate = [](auto var, auto var2, auto var3) {};
    OnPlayerLeaveVehicleDelegate = [](auto var, auto var2, auto var3) {};
    OnStopDelegate = []() {};
    OnTickDelegate = []() {};
    OnCreatePlayerDelegate = [](auto var, auto var2) {};
    OnRemovePlayerDelegate = [](auto var) {};
    OnCreateVehicleDelegate = [](auto var, auto var2) {};
    OnRemoveVehicleDelegate = [](auto var) {};
    OnCreateBlipDelegate = [](auto var) {};
    OnRemoveBlipDelegate = [](auto var) {};
    OnCreateCheckpointDelegate = [](auto var) {};
    OnRemoveCheckpointDelegate = [](auto var) {};
    OnCreateVoiceChannelDelegate = [](auto var) {};
    OnRemoveVoiceChannelDelegate = [](auto var) {};
    OnConsoleCommandDelegate = [](auto var, auto var2) {};
    OnMetaChangeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnSyncedMetaChangeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnCreateColShapeDelegate = [](auto var) {};
    OnRemoveColShapeDelegate = [](auto var) {};
    ColShapeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
}

bool CSharpResourceImpl::Start() {
    ResetDelegates();
    if (!coreClr->ExecuteManagedResource(this->resource->GetPath().CStr(), this->resource->GetName().CStr(),
                                         this->resource->GetMain().CStr(),
                                         this->resource)) {
        return false;
    }
    if (MainDelegate == nullptr) return false;
    MainDelegate(this->server, this->resource, this->resource->GetName().CStr(), resource->GetMain().CStr());
    return true;
}

bool CSharpResourceImpl::Stop() {
    if (OnStopDelegate == nullptr) return false;
    OnStopDelegate();
    if (!coreClr->ExecuteManagedResourceUnload(this->resource->GetPath().CStr(), this->resource->GetMain().CStr())) {
        return false;
    }
    ResetDelegates();
    return true;
}

CSharpResourceImpl::~CSharpResourceImpl() {
    for (alt::Size i = 0, length = invokers->GetSize(); i < length; i++) {
        auto invoker = (*invokers)[i];
        delete invoker;
    }
    delete invokers;
}

bool CSharpResourceImpl::OnEvent(const alt::CEvent* ev) {
    if (ev == nullptr) return true;
    switch (ev->GetType()) {
        case alt::CEvent::Type::META_CHANGE: {
            auto event = ((alt::CMetaChangeEvent*) (ev));
            auto entity = event->GetTarget();
            if (entity == nullptr) return true;
            auto key = event->GetKey();
            auto value = event->GetVal();
            OnMetaChangeDelegate(GetEntityPointer(entity), entity->GetType(), key == nullptr ? "" : key.CStr(), &value);
            break;
        }
        case alt::CEvent::Type::SYNCED_META_CHANGE: {
            auto event = ((alt::CSyncedMetaDataChangeEvent*) (ev));
            auto entity = event->GetTarget();
            if (entity == nullptr) return true;
            auto key = event->GetKey();
            auto value = event->GetVal();
            OnSyncedMetaChangeDelegate(GetEntityPointer(entity), entity->GetType(), key == nullptr ? "" : key.CStr(),
                                       &value);
            break;
        }
        case alt::CEvent::Type::CHECKPOINT_EVENT: {
            auto entity = ((alt::CCheckpointEvent*) (ev))->GetEntity();
            auto entityPtr = GetEntityPointer(entity);
            if (entity != nullptr && entityPtr != nullptr) {
                OnCheckpointDelegate(((alt::CCheckpointEvent*) (ev))->GetTarget(),
                                     entityPtr,
                                     entity->GetType(),
                                     ((alt::CCheckpointEvent*) (ev))->GetState());
            }
            break;
        }
        case alt::CEvent::Type::CLIENT_SCRIPT_EVENT: {
            alt::Array<alt::MValue> clientArgs = (((alt::CClientScriptEvent*) (ev))->GetArgs());
            OnClientEventDelegate(((alt::CClientScriptEvent*) (ev))->GetTarget(),
                                  ((alt::CClientScriptEvent*) (ev))->GetName().CStr(),
                                  &clientArgs);
            break;
        }
        case alt::CEvent::Type::PLAYER_CONNECT: {
            auto connectPlayer = reinterpret_cast<const alt::CPlayerConnectEvent*>(ev)->GetTarget();
            OnPlayerConnectDelegate(connectPlayer, connectPlayer->GetID(),
                                    "");//TODO: maybe better solution
            break;
        }
        case alt::CEvent::Type::PLAYER_DAMAGE: {
            auto damageEvent = (alt::CPlayerDamageEvent*) ev;
            auto entity = damageEvent->GetAttacker();
            auto entityPtr = GetEntityPointer(entity);
            if (entity != nullptr && entityPtr != nullptr) {
                OnPlayerDamageDelegate(damageEvent->GetTarget(),
                                       entityPtr,
                                       entity->GetType(),
                                       entity->GetID(),
                                       damageEvent->GetWeapon(),
                                       damageEvent->GetDamage());
            }
            break;
        }
        case alt::CEvent::Type::PLAYER_DEATH: {
            auto entity = ((alt::CPlayerDeathEvent*) (ev))->GetKiller();
            auto entityPtr = GetEntityPointer(entity);
            if (entity != nullptr && entityPtr != nullptr) {
                OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget(),
                                      entityPtr,
                                      entity->GetType(),
                                      ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
            }
            break;
        }
        case alt::CEvent::Type::FIRE_EVENT: {
            //auto fireEvent = ((alt::CFireEvent*) (ev));
            //TODO: implement when implemented in cpp sdk
            break;
        }
        case alt::CEvent::Type::EXPLOSION_EVENT: {
            auto explosionEvent = ((alt::CExplosionEvent*) (ev));
            auto eventPosition = explosionEvent->GetPosition();
            position_t position = {};
            position.x = eventPosition.x;
            position.y = eventPosition.y;
            position.z = eventPosition.z;
            ExplosionDelegate(explosionEvent->GetSource(), explosionEvent->GetExplosionType(), position,
                              explosionEvent->GetExplosionFX());
            break;
        }
        case alt::CEvent::Type::WEAPON_DAMAGE_EVENT: {
            auto weaponDamageEvent = ((alt::CWeaponDamageEvent*) (ev));
            auto targetEntity = weaponDamageEvent->GetTarget();
            if (targetEntity == nullptr) return true;
            auto eventShotOffset = weaponDamageEvent->GetShotOffset();
            position_t shotOffset = {};
            shotOffset.x = eventShotOffset[0];
            shotOffset.y = eventShotOffset[1];
            shotOffset.z = eventShotOffset[2];
            WeaponDamageDelegate(weaponDamageEvent->GetSource(), GetEntityPointer(targetEntity),
                                 targetEntity->GetType(), weaponDamageEvent->GetWeaponHash(),
                                 weaponDamageEvent->GetDamageValue(), shotOffset, weaponDamageEvent->GetBodyPart());
            break;
        }
        case alt::CEvent::Type::PLAYER_DISCONNECT: {
            auto disconnectEvent = reinterpret_cast<const alt::CPlayerDisconnectEvent*>(ev);
            auto disconnectPlayer = disconnectEvent->GetTarget();
            /*auto reason = disconnectEvent->GetReason();
            if (reason != nullptr && reason.GetSize() > 0) {
                auto reasonCStr = reason.CStr();
                if (reasonCStr != nullptr) {
                    OnPlayerDisconnectDelegate(disconnectPlayer,
                                               reasonCStr);
                } else {
                    OnPlayerDisconnectDelegate(disconnectPlayer,
                                               "");
                }*/
            //} else {
            OnPlayerDisconnectDelegate(disconnectPlayer,
                                       "");
            //}
            break;
        }
        case alt::CEvent::Type::REMOVE_ENTITY_EVENT: {
            auto removeEntityEntity = ((alt::CRemoveEntityEvent*) (ev))->GetEntity();
            if (removeEntityEntity != nullptr) {
                switch (removeEntityEntity->GetType()) {
                    case alt::IBaseObject::Type::PLAYER:
                        OnPlayerRemoveDelegate(dynamic_cast<alt::IPlayer*>(removeEntityEntity));
                        break;
                    case alt::IBaseObject::Type::VEHICLE:
                        OnVehicleRemoveDelegate(dynamic_cast<alt::IVehicle*>(removeEntityEntity));
                        break;
                }
            }
            break;
        }
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT: {
            auto serverScriptEvent = (alt::CServerScriptEvent*) ev;
            alt::Array<alt::MValue> serverArgs = serverScriptEvent->GetArgs();
            server->LogInfo(serverScriptEvent->GetName());
            OnServerEventDelegate(serverScriptEvent->GetName().CStr(), &serverArgs);
            break;
        }
        case alt::CEvent::Type::PLAYER_CHANGE_VEHICLE_SEAT: {
            auto changeSeatEvent = (alt::CPlayerChangeVehicleSeatEvent*) ev;
            OnPlayerChangeVehicleSeatDelegate(changeSeatEvent->GetTarget(),
                                              changeSeatEvent->GetPlayer(),
                                              changeSeatEvent->GetOldSeat(),
                                              changeSeatEvent->GetNewSeat());
            break;
        }
        case alt::CEvent::Type::PLAYER_ENTER_VEHICLE: {
            auto enterEvent = (alt::CPlayerEnterVehicleEvent*) ev;
            OnPlayerEnterVehicleDelegate(enterEvent->GetTarget(),
                                         enterEvent->GetPlayer(),
                                         enterEvent->GetSeat());
            break;
        }
        case alt::CEvent::Type::PLAYER_LEAVE_VEHICLE: {
            auto leaveEvent = (alt::CPlayerLeaveVehicleEvent*) ev;
            OnPlayerLeaveVehicleDelegate(leaveEvent->GetTarget(),
                                         leaveEvent->GetPlayer(),
                                         leaveEvent->GetSeat());
            break;
        }
        case alt::CEvent::Type::CONSOLE_COMMAND_EVENT: {
            alt::Array<alt::StringView> args = ((alt::CConsoleCommandEvent*) (ev))->GetArgs();
            OnConsoleCommandDelegate(((alt::CConsoleCommandEvent*) (ev))->GetName().CStr(), &args);
            break;
        }
        case alt::CEvent::Type::COLSHAPE_EVENT: {
            auto entity = ((alt::CColShapeEvent*) (ev))->GetEntity();
            auto entityPointer = GetEntityPointer(entity);
            if (entity != nullptr && entityPointer != nullptr) {
                ColShapeDelegate(((alt::CColShapeEvent*) (ev))->GetTarget(),
                                 entityPointer,
                                 entity->GetType(),
                                 ((alt::CColShapeEvent*) (ev))->GetState());
            }
            break;
        }
    }
    return true;
}

void CSharpResourceImpl::OnCreateBaseObject(alt::IBaseObject* object) {
    if (object != nullptr) {
        switch (object->GetType()) {
            case alt::IBaseObject::Type::PLAYER: {
                auto player = dynamic_cast<alt::IPlayer*>(object);
                OnCreatePlayerDelegate(player, player->GetID());
                break;
            }
            case alt::IBaseObject::Type::VEHICLE: {
                auto vehicle = dynamic_cast<alt::IVehicle*>(object);
                OnCreateVehicleDelegate(vehicle, vehicle->GetID());
                break;
            }
            case alt::IBaseObject::Type::BLIP:
                OnCreateBlipDelegate(dynamic_cast<alt::IBlip*>(object));
                break;
            case alt::IBaseObject::Type::CHECKPOINT:
                OnCreateCheckpointDelegate(dynamic_cast<alt::ICheckpoint*>(object));
                break;
            case alt::IBaseObject::Type::VOICE_CHANNEL:
                OnCreateVoiceChannelDelegate(dynamic_cast<alt::IVoiceChannel*>(object));
                break;
            case alt::IBaseObject::Type::COLSHAPE:
                OnCreateColShapeDelegate(dynamic_cast<alt::IColShape*>(object));
                break;
        }
    }
}

void CSharpResourceImpl::OnRemoveBaseObject(alt::IBaseObject* object) {
    if (object != nullptr) {
        switch (object->GetType()) {
            case alt::IBaseObject::Type::PLAYER:
                OnRemovePlayerDelegate(dynamic_cast<alt::IPlayer*>(object));
                break;
            case alt::IBaseObject::Type::VEHICLE:
                OnRemoveVehicleDelegate(dynamic_cast<alt::IVehicle*>(object));
                break;
            case alt::IBaseObject::Type::BLIP:
                OnRemoveBlipDelegate(dynamic_cast<alt::IBlip*>(object));
                break;
            case alt::IBaseObject::Type::CHECKPOINT:
                OnRemoveCheckpointDelegate(dynamic_cast<alt::ICheckpoint*>(object));
                break;
            case alt::IBaseObject::Type::VOICE_CHANNEL:
                OnRemoveVoiceChannelDelegate(dynamic_cast<alt::IVoiceChannel*>(object));
                break;
            case alt::IBaseObject::Type::COLSHAPE:
                OnRemoveColShapeDelegate(dynamic_cast<alt::IColShape*>(object));
                break;
        }
    }
}

void CSharpResourceImpl::OnTick() {
    OnTickDelegate();
}

void CSharpResource_Reload(CSharpResourceImpl* resource) {
    resource->OnStopDelegate();
    resource->coreClr->ExecuteManagedResourceUnload(resource->resource->GetPath().CStr(),
                                                    resource->resource->GetMain().CStr());
    resource->coreClr->ExecuteManagedResource(resource->resource->GetPath().CStr(),
                                              resource->resource->GetName().CStr(),
                                              resource->resource->GetMain().CStr(), resource->resource);
    resource->MainDelegate(resource->server, resource->resource, resource->resource->GetName().CStr(),
                           resource->resource->GetMain().CStr());
}

void CSharpResource_Load(CSharpResourceImpl* resource) {
    resource->coreClr->ExecuteManagedResource(resource->resource->GetPath().CStr(),
                                              resource->resource->GetName().CStr(),
                                              resource->resource->GetMain().CStr(), resource->resource);
    resource->MainDelegate(resource->server, resource->resource, resource->resource->GetName().CStr(),
                           resource->resource->GetMain().CStr());
}

void CSharpResource_Unload(CSharpResourceImpl* resource) {
    resource->OnStopDelegate();
    resource->coreClr->ExecuteManagedResourceUnload(resource->resource->GetPath().CStr(),
                                                    resource->resource->GetMain().CStr());
}

void CSharpResource_SetMain(CSharpResourceImpl* resource,
                            MainDelegate_t mainDelegate,
                            StopDelegate_t stopDelegate,
                            TickDelegate_t tickDelegate,
                            ServerEventDelegate_t serverEventDelegate,
                            CheckpointDelegate_t checkpointDelegate,
                            ClientEventDelegate_t clientEventDelegate,
                            PlayerDamageDelegate_t playerDamageDelegate,
                            PlayerConnectDelegate_t playerConnectDelegate,
                            PlayerDeathDelegate_t playerDeathDelegate,
                            ExplosionDelegate_t explosionDelegate,
                            WeaponDamageDelegate_t weaponDamageDelegate,
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
                            ColShapeDelegate_t colShapeDelegate) {
    resource->MainDelegate = mainDelegate;
    resource->OnStopDelegate = stopDelegate;
    resource->OnTickDelegate = tickDelegate;
    resource->OnServerEventDelegate = serverEventDelegate;
    resource->OnCheckpointDelegate = checkpointDelegate;
    resource->OnClientEventDelegate = clientEventDelegate;
    resource->OnPlayerDamageDelegate = playerDamageDelegate;
    resource->OnPlayerConnectDelegate = playerConnectDelegate;
    resource->OnPlayerDeathDelegate = playerDeathDelegate;
    resource->ExplosionDelegate = explosionDelegate;
    resource->WeaponDamageDelegate = weaponDamageDelegate;
    resource->OnPlayerDisconnectDelegate = playerDisconnectDelegate;
    resource->OnPlayerRemoveDelegate = playerRemoveDelegate;
    resource->OnVehicleRemoveDelegate = vehicleRemoveDelegate;
    resource->OnPlayerChangeVehicleSeatDelegate = playerChangeVehicleSeatDelegate;
    resource->OnPlayerEnterVehicleDelegate = playerEnterVehicleDelegate;
    resource->OnPlayerLeaveVehicleDelegate = playerLeaveVehicleDelegate;
    resource->OnCreatePlayerDelegate = createPlayerDelegate;
    resource->OnRemovePlayerDelegate = removePlayerDelegate;
    resource->OnCreateVehicleDelegate = createVehicleDelegate;
    resource->OnRemoveVehicleDelegate = removeVehicleDelegate;
    resource->OnCreateBlipDelegate = createBlipDelegate;
    resource->OnRemoveBlipDelegate = removeBlipDelegate;
    resource->OnCreateCheckpointDelegate = createCheckpointDelegate;
    resource->OnRemoveCheckpointDelegate = removeCheckpointDelegate;
    resource->OnCreateVoiceChannelDelegate = createVoiceChannelDelegate;
    resource->OnRemoveVoiceChannelDelegate = removeVoiceChannelDelegate;
    resource->OnConsoleCommandDelegate = consoleCommandDelegate;
    resource->OnMetaChangeDelegate = metaChangeDelegate;
    resource->OnSyncedMetaChangeDelegate = syncedMetaChangeDelegate;
    resource->OnCreateColShapeDelegate = createColShapeDelegate;
    resource->OnRemoveColShapeDelegate = removeColShapeDelegate;
    resource->ColShapeDelegate = colShapeDelegate;
}

bool CSharpResourceImpl::MakeClient(alt::IResource::CreationInfo* info, alt::Array<alt::String> files) {
    info->type = "js";
    return true;
}

void* CSharpResourceImpl::GetBaseObjectPointer(alt::IBaseObject* baseObject) {
    if (baseObject != nullptr) {
        switch (baseObject->GetType()) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(baseObject);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(baseObject);
            case alt::IBaseObject::Type::BLIP:
                return dynamic_cast<alt::IBlip*>(baseObject);
            case alt::IBaseObject::Type::CHECKPOINT:
                return dynamic_cast<alt::ICheckpoint*>(baseObject);
            case alt::IBaseObject::Type::COLSHAPE:
                return dynamic_cast<alt::IColShape*>(baseObject);
            default:
                return nullptr;
        }
    }
    return nullptr;
}

void* CSharpResourceImpl::GetEntityPointer(alt::IEntity* entity) {
    if (entity != nullptr) {
        switch (entity->GetType()) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(entity);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(entity);
            default:
                return nullptr;
        }
    }
    return nullptr;
}