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
    OnResourceStartDelegate = [](auto var) {};
    OnResourceStopDelegate = [](auto var) {};
    OnResourceErrorDelegate = [](auto var) {};
    OnPlayerDamageDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6) {};
    OnPlayerDeathDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnExplosionDelegate = [](auto var, auto var2, auto var3, auto var4) {};
    OnWeaponDamageDelegate = [](auto var, auto var2, auto var3, auto var4, auto var5, auto var6, auto var7) {};;
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
    OnColShapeDelegate = [](auto var, auto var2, auto var3, auto var4) {};
}

bool CSharpResourceImpl::Start() {
    ResetDelegates();
    if (!coreClr->ExecuteManagedResource(/*this->resource->GetPath().CStr()*/(alt::String(this->server->GetRootDirectory()) + "/resources/" + alt::String(this->resource->GetName().CStr())).CStr(), this->resource->GetName().CStr(),
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
    ResetDelegates();
    return coreClr->ExecuteManagedResourceUnload(this->resource->GetPath().CStr(), this->resource->GetMain().CStr());
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
        }
            break;
        case alt::CEvent::Type::SYNCED_META_CHANGE: {
            auto event = ((alt::CSyncedMetaDataChangeEvent*) (ev));
            auto entity = event->GetTarget();
            if (entity == nullptr) return true;
            auto key = event->GetKey();
            auto value = event->GetVal();
            OnSyncedMetaChangeDelegate(GetEntityPointer(entity), entity->GetType(), key == nullptr ? "" : key.CStr(),
                                       &value);
        }
            break;
        case alt::CEvent::Type::CHECKPOINT_EVENT: {
            auto entity = ((alt::CCheckpointEvent*) (ev))->GetEntity();
            auto entityPtr = GetEntityPointer(entity);
            if (entity != nullptr && entityPtr != nullptr) {
                OnCheckpointDelegate(((alt::CCheckpointEvent*) (ev))->GetTarget(),
                                     entityPtr,
                                     entity->GetType(),
                                     ((alt::CCheckpointEvent*) (ev))->GetState());
            }
        }
            break;
        case alt::CEvent::Type::CLIENT_SCRIPT_EVENT: {
            alt::Array<alt::MValue> clientArgs = (((alt::CClientScriptEvent*) (ev))->GetArgs());
            OnClientEventDelegate(((alt::CClientScriptEvent*) (ev))->GetTarget(),
                                  ((alt::CClientScriptEvent*) (ev))->GetName().CStr(),
                                  &clientArgs);
        }
            break;
        case alt::CEvent::Type::PLAYER_CONNECT: {
            auto connectPlayer = reinterpret_cast<const alt::CPlayerConnectEvent*>(ev)->GetTarget();
            OnPlayerConnectDelegate(connectPlayer, connectPlayer->GetID(),
                                    "");//TODO: maybe better solution
        }
            break;
        case alt::CEvent::Type::RESOURCE_START: {
            OnResourceStartDelegate(reinterpret_cast<const alt::CResourceStartEvent*>(ev)->GetResource());
            break;
        }
        case alt::CEvent::Type::RESOURCE_STOP: {
            OnResourceStopDelegate(reinterpret_cast<const alt::CResourceStopEvent*>(ev)->GetResource());
            break;
        }
        case alt::CEvent::Type::RESOURCE_ERROR: {
            OnResourceErrorDelegate(reinterpret_cast<const alt::CResourceErrorEvent*>(ev)->GetResource());
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
        }
            break;
        case alt::CEvent::Type::PLAYER_DEATH: {
            auto entity = ((alt::CPlayerDeathEvent*) (ev))->GetKiller();
            if (entity != nullptr) {
                auto entityPtr = GetEntityPointer(entity);
                OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget(),
                                      entityPtr,
                                      entity->GetType(),
                                      ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
            } else {
                OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget(),
                                      nullptr,
                                      (alt::IBaseObject::Type) 0,
                                      ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
            }
        }
            break;
        case alt::CEvent::Type::FIRE_EVENT: {
            //auto fireEvent = ((alt::CFireEvent*) (ev));
            //TODO: implement when implemented in cpp sdk
        }
            break;
        case alt::CEvent::Type::EXPLOSION_EVENT: {
            auto explosionEvent = ((alt::CExplosionEvent*) (ev));
            auto eventPosition = explosionEvent->GetPosition();
            position_t position = {};
            position.x = eventPosition.x;
            position.y = eventPosition.y;
            position.z = eventPosition.z;
            OnExplosionDelegate(explosionEvent->GetSource(), explosionEvent->GetExplosionType(), position,
                                explosionEvent->GetExplosionFX());
        }
            break;
        case alt::CEvent::Type::WEAPON_DAMAGE_EVENT: {
            auto weaponDamageEvent = ((alt::CWeaponDamageEvent*) (ev));
            auto targetEntity = weaponDamageEvent->GetTarget();
            if (targetEntity == nullptr) return true;
            auto eventShotOffset = weaponDamageEvent->GetShotOffset();
            position_t shotOffset = {};
            shotOffset.x = eventShotOffset[0];
            shotOffset.y = eventShotOffset[1];
            shotOffset.z = eventShotOffset[2];
            OnWeaponDamageDelegate(weaponDamageEvent->GetSource(), GetEntityPointer(targetEntity),
                                   targetEntity->GetType(), weaponDamageEvent->GetWeaponHash(),
                                   weaponDamageEvent->GetDamageValue(), shotOffset, weaponDamageEvent->GetBodyPart());
        }
            break;
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
        }
            break;
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
        }
            break;
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT: {
            auto serverScriptEvent = (alt::CServerScriptEvent*) ev;
            alt::Array<alt::MValue> serverArgs = serverScriptEvent->GetArgs();
            OnServerEventDelegate(serverScriptEvent->GetName().CStr(), &serverArgs);
        }
            break;
        case alt::CEvent::Type::PLAYER_CHANGE_VEHICLE_SEAT: {
            auto changeSeatEvent = (alt::CPlayerChangeVehicleSeatEvent*) ev;
            OnPlayerChangeVehicleSeatDelegate(changeSeatEvent->GetTarget(),
                                              changeSeatEvent->GetPlayer(),
                                              changeSeatEvent->GetOldSeat(),
                                              changeSeatEvent->GetNewSeat());
        }
            break;
        case alt::CEvent::Type::PLAYER_ENTER_VEHICLE: {
            auto enterEvent = (alt::CPlayerEnterVehicleEvent*) ev;
            OnPlayerEnterVehicleDelegate(enterEvent->GetTarget(),
                                         enterEvent->GetPlayer(),
                                         enterEvent->GetSeat());
        }
            break;
        case alt::CEvent::Type::PLAYER_LEAVE_VEHICLE: {
            auto leaveEvent = (alt::CPlayerLeaveVehicleEvent*) ev;
            OnPlayerLeaveVehicleDelegate(leaveEvent->GetTarget(),
                                         leaveEvent->GetPlayer(),
                                         leaveEvent->GetSeat());
        }
            break;
        case alt::CEvent::Type::CONSOLE_COMMAND_EVENT: {
            alt::Array<alt::StringView> args = ((alt::CConsoleCommandEvent*) (ev))->GetArgs();
            OnConsoleCommandDelegate(((alt::CConsoleCommandEvent*) (ev))->GetName().CStr(), &args);
        }
            break;
        case alt::CEvent::Type::COLSHAPE_EVENT: {
            auto entity = ((alt::CColShapeEvent*) (ev))->GetEntity();
            auto entityPointer = GetEntityPointer(entity);
            if (entity != nullptr && entityPointer != nullptr) {
                OnColShapeDelegate(((alt::CColShapeEvent*) (ev))->GetTarget(),
                                   entityPointer,
                                   entity->GetType(),
                                   ((alt::CColShapeEvent*) (ev))->GetState());
            }
        }
            break;
    }
    return true;
}

void CSharpResourceImpl::OnCreateBaseObject(alt::IBaseObject* object) {
    if (object != nullptr) {
        switch (object->GetType()) {
            case alt::IBaseObject::Type::PLAYER: {
                auto player = dynamic_cast<alt::IPlayer*>(object);
                OnCreatePlayerDelegate(player, player->GetID());
            }
                break;
            case alt::IBaseObject::Type::VEHICLE: {
                auto vehicle = dynamic_cast<alt::IVehicle*>(object);
                OnCreateVehicleDelegate(vehicle, vehicle->GetID());
            }
                break;
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

void CSharpResourceImpl_SetMainDelegate(CSharpResourceImpl* resource,
                                        MainDelegate_t delegate) {
    resource->MainDelegate = delegate;
}

void CSharpResourceImpl_SetStopDelegate(CSharpResourceImpl* resource,
                                        StopDelegate_t delegate) {
    resource->OnStopDelegate = delegate;
}

void CSharpResourceImpl_SetTickDelegate(CSharpResourceImpl* resource,
                                        TickDelegate_t delegate) {
    resource->OnTickDelegate = delegate;
}

void CSharpResourceImpl_SetServerEventDelegate(CSharpResourceImpl* resource,
                                               ServerEventDelegate_t delegate) {
    resource->OnServerEventDelegate = delegate;
}

void CSharpResourceImpl_SetCheckpointDelegate(CSharpResourceImpl* resource,
                                              CheckpointDelegate_t delegate) {
    resource->OnCheckpointDelegate = delegate;
}

void CSharpResourceImpl_SetClientEventDelegate(CSharpResourceImpl* resource,
                                               ClientEventDelegate_t delegate) {
    resource->OnClientEventDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerDamageDelegate(CSharpResourceImpl* resource,
                                                PlayerDamageDelegate_t delegate) {
    resource->OnPlayerDamageDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerConnectDelegate(CSharpResourceImpl* resource,
                                                 PlayerConnectDelegate_t delegate) {
    resource->OnPlayerConnectDelegate = delegate;
}

void CSharpResourceImpl_SetResourceStartDelegate(CSharpResourceImpl* resource, ResourceEventDelegate_t delegate) {
    resource->OnResourceStartDelegate = delegate;
}

void CSharpResourceImpl_SetResourceStopDelegate(CSharpResourceImpl* resource, ResourceEventDelegate_t delegate) {
    resource->OnResourceStopDelegate = delegate;
}

void CSharpResourceImpl_SetResourceErrorDelegate(CSharpResourceImpl* resource, ResourceEventDelegate_t delegate) {
    resource->OnResourceErrorDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerDeathDelegate(CSharpResourceImpl* resource,
                                               PlayerDeathDelegate_t delegate) {
    resource->OnPlayerDeathDelegate = delegate;
}

void CSharpResourceImpl_SetExplosionDelegate(CSharpResourceImpl* resource,
                                             ExplosionDelegate_t delegate) {
    resource->OnExplosionDelegate = delegate;
}

void CSharpResourceImpl_SetWeaponDamageDelegate(CSharpResourceImpl* resource,
                                                WeaponDamageDelegate_t delegate) {
    resource->OnWeaponDamageDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerDisconnectDelegate(CSharpResourceImpl* resource,
                                                    PlayerDisconnectDelegate_t delegate) {
    resource->OnPlayerDisconnectDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerRemoveDelegate(CSharpResourceImpl* resource,
                                                PlayerRemoveDelegate_t delegate) {
    resource->OnPlayerRemoveDelegate = delegate;
}

void CSharpResourceImpl_SetVehicleRemoveDelegate(CSharpResourceImpl* resource,
                                                 VehicleRemoveDelegate_t delegate) {
    resource->OnVehicleRemoveDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerChangeVehicleSeatDelegate(CSharpResourceImpl* resource,
                                                           PlayerChangeVehicleSeatDelegate_t delegate) {
    resource->OnPlayerChangeVehicleSeatDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerEnterVehicleDelegate(CSharpResourceImpl* resource,
                                                      PlayerEnterVehicleDelegate_t delegate) {
    resource->OnPlayerEnterVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetPlayerLeaveVehicleDelegate(CSharpResourceImpl* resource,
                                                      PlayerLeaveVehicleDelegate_t delegate) {
    resource->OnPlayerLeaveVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetCreatePlayerDelegate(CSharpResourceImpl* resource,
                                                CreatePlayerDelegate_t delegate) {
    resource->OnCreatePlayerDelegate = delegate;
}

void CSharpResourceImpl_SetRemovePlayerDelegate(CSharpResourceImpl* resource,
                                                RemovePlayerDelegate_t delegate) {
    resource->OnRemovePlayerDelegate = delegate;
}

void CSharpResourceImpl_SetCreateVehicleDelegate(CSharpResourceImpl* resource,
                                                 CreateVehicleDelegate_t delegate) {
    resource->OnCreateVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,
                                                 RemoveVehicleDelegate_t delegate) {
    resource->OnRemoveVehicleDelegate = delegate;
}

void CSharpResourceImpl_SetCreateBlipDelegate(CSharpResourceImpl* resource,
                                              CreateBlipDelegate_t delegate) {
    resource->OnCreateBlipDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveBlipDelegate(CSharpResourceImpl* resource,
                                              RemoveBlipDelegate_t delegate) {
    resource->OnRemoveBlipDelegate = delegate;
}

void CSharpResourceImpl_SetCreateCheckpointDelegate(CSharpResourceImpl* resource,
                                                    CreateCheckpointDelegate_t delegate) {
    resource->OnCreateCheckpointDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveCheckpointDelegate(CSharpResourceImpl* resource,
                                                    RemoveCheckpointDelegate_t delegate) {
    resource->OnRemoveCheckpointDelegate = delegate;
}

void CSharpResourceImpl_SetCreateVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                      CreateVoiceChannelDelegate_t delegate) {
    resource->OnCreateVoiceChannelDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveVoiceChannelDelegate(CSharpResourceImpl* resource,
                                                      RemoveVoiceChannelDelegate_t delegate) {
    resource->OnRemoveVoiceChannelDelegate = delegate;
}

void CSharpResourceImpl_SetConsoleCommandDelegate(CSharpResourceImpl* resource,
                                                  ConsoleCommandDelegate_t delegate) {
    resource->OnConsoleCommandDelegate = delegate;
}

void CSharpResourceImpl_SetMetaChangeDelegate(CSharpResourceImpl* resource,
                                              MetaChangeDelegate_t delegate) {
    resource->OnMetaChangeDelegate = delegate;
}

void CSharpResourceImpl_SetSyncedMetaChangeDelegate(CSharpResourceImpl* resource,
                                                    MetaChangeDelegate_t delegate) {
    resource->OnSyncedMetaChangeDelegate = delegate;
}

void CSharpResourceImpl_SetCreateColShapeDelegate(CSharpResourceImpl* resource,
                                                  CreateColShapeDelegate_t delegate) {
    resource->OnCreateColShapeDelegate = delegate;
}

void CSharpResourceImpl_SetRemoveColShapeDelegate(CSharpResourceImpl* resource,
                                                  RemoveColShapeDelegate_t delegate) {
    resource->OnRemoveColShapeDelegate = delegate;
}

void CSharpResourceImpl_SetColShapeDelegate(CSharpResourceImpl* resource,
                                            ColShapeDelegate_t delegate) {
    resource->OnColShapeDelegate = delegate;
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