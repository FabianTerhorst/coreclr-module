#include "CSharpResourceImpl.h"

CSharpResourceImpl::CSharpResourceImpl(alt::ICore* server, CoreClr* coreClr, alt::IResource* resource)
        : alt::IResource::Impl() {
    this->resource = resource;
    this->server = server;
    this->invokers = new alt::Array<CustomInvoker*>();
    this->coreClr = coreClr;

    runtimeHost = nullptr;
    domainId = 0;
    MainDelegate = nullptr;
    OnCheckpointDelegate = nullptr;
    OnClientEventDelegate = nullptr;
    OnPlayerConnectDelegate = nullptr;
    OnPlayerDamageDelegate = nullptr;
    OnPlayerDeathDelegate = nullptr;
    OnPlayerDisconnectDelegate = nullptr;
    OnPlayerRemoveDelegate = nullptr;
    OnVehicleRemoveDelegate = nullptr;
    OnServerEventDelegate = nullptr;
    OnPlayerChangeVehicleSeatDelegate = nullptr;
    OnPlayerEnterVehicleDelegate = nullptr;
    OnPlayerLeaveVehicleDelegate = nullptr;
    OnStopDelegate = nullptr;
    OnTickDelegate = nullptr;
    OnCreatePlayerDelegate = nullptr;
    OnRemovePlayerDelegate = nullptr;
    OnCreateVehicleDelegate = nullptr;
    OnRemoveVehicleDelegate = nullptr;
    OnCreateBlipDelegate = nullptr;
    OnRemoveBlipDelegate = nullptr;
    OnCreateCheckpointDelegate = nullptr;
    OnRemoveCheckpointDelegate = nullptr;
    OnCreateVoiceChannelDelegate = nullptr;
    OnRemoveVoiceChannelDelegate = nullptr;
    OnConsoleCommandDelegate = nullptr;
    OnMetaChangeDelegate = nullptr;
    OnSyncedMetaChangeDelegate = nullptr;
    OnCreateColShapeDelegate = nullptr;
    OnRemoveColShapeDelegate = nullptr;
    ColShapeDelegate = nullptr;
}

bool CSharpResourceImpl::Start() {
    coreClr->ExecuteManagedResource(this->resource->GetPath().CStr(), this->resource->GetName().CStr(), this->resource->GetMain().CStr(),
                                    this->resource);
    if (MainDelegate == nullptr) return false;
    MainDelegate(this->server, this->resource, this->resource->GetName().CStr(), resource->GetMain().CStr());
    return true;
}

bool CSharpResourceImpl::Stop() {
    for (alt::Size i = 0, length = invokers->GetSize(); i < length; i++) {
        auto invoker = (*invokers)[i];
        delete invoker;
    }
    delete invokers;
    if (OnStopDelegate == nullptr) return false;
    OnStopDelegate();
    coreClr->ExecuteManagedResourceUnload(this->resource->GetPath().CStr(), this->resource->GetMain().CStr());
    return true;
}

CSharpResourceImpl::~CSharpResourceImpl() {
    /*int i = 0;
    for (auto resource : *resourcesCache) {
        if (resource == this) {
            auto newResourcesCache = new alt::Array<CSharpResourceImpl*>;
            for (auto cloneResource : *resourcesCache) {
                if (cloneResource != this) {
                    newResourcesCache->Push(cloneResource);
                }
            }
            free(resourcesCache);
            resourcesCache = newResourcesCache;
            break;
        }
        i++;
    }*/
}

//TODO: needs entity type enum value for undefined
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
            auto entity = ((alt::CPlayerDamageEvent*) (ev))->GetAttacker();
            auto entityPtr = GetEntityPointer(entity);
            if (entity != nullptr && entityPtr != nullptr) {
                OnPlayerDamageDelegate(((alt::CPlayerDamageEvent*) (ev))->GetTarget(),
                                       entityPtr,
                                       entity->GetType(),
                                       entity->GetID(),
                                       ((alt::CPlayerDamageEvent*) (ev))->GetWeapon(),
                                       ((alt::CPlayerDamageEvent*) (ev))->GetDamage());
            } else {
                OnPlayerDamageDelegate(((alt::CPlayerDamageEvent*) (ev))->GetTarget(),
                                       nullptr,
                                       alt::IBaseObject::Type::BLIP,// These are placeholders for none ptr type and are ignored on c# side
                                       0,
                                       ((alt::CPlayerDamageEvent*) (ev))->GetWeapon(),
                                       ((alt::CPlayerDamageEvent*) (ev))->GetDamage());
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
            } else {
                OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget(),
                                      nullptr,
                                      alt::IBaseObject::Type::BLIP,
                                      ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
            }
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
        case alt::CEvent::Type::PLAYER_CHANGE_VEHICLE_SEAT:
            OnPlayerChangeVehicleSeatDelegate(((alt::CPlayerChangeVehicleSeatEvent*) (ev))->GetTarget(),
                                              ((alt::CPlayerChangeVehicleSeatEvent*) (ev))->GetPlayer(),
                                              ((alt::CPlayerChangeVehicleSeatEvent*) (ev))->GetOldSeat(),
                                              ((alt::CPlayerChangeVehicleSeatEvent*) (ev))->GetNewSeat());
            break;
        case alt::CEvent::Type::PLAYER_ENTER_VEHICLE:
            OnPlayerEnterVehicleDelegate(((alt::CPlayerEnterVehicleEvent*) (ev))->GetTarget(),
                                         ((alt::CPlayerEnterVehicleEvent*) (ev))->GetPlayer(),
                                         ((alt::CPlayerEnterVehicleEvent*) (ev))->GetSeat());
            break;
        case alt::CEvent::Type::PLAYER_LEAVE_VEHICLE:
            OnPlayerLeaveVehicleDelegate(((alt::CPlayerLeaveVehicleEvent*) (ev))->GetTarget(),
                                         ((alt::CPlayerLeaveVehicleEvent*) (ev))->GetPlayer(),
                                         ((alt::CPlayerLeaveVehicleEvent*) (ev))->GetSeat());
            break;
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
            case alt::IBaseObject::Type::PLAYER:
                OnCreatePlayerDelegate(dynamic_cast<alt::IPlayer*>(object),
                                       dynamic_cast<alt::IPlayer*>(object)->GetID());
                break;
            case alt::IBaseObject::Type::VEHICLE:
                OnCreateVehicleDelegate(dynamic_cast<alt::IVehicle*>(object),
                                        dynamic_cast<alt::IVehicle*>(object)->GetID());
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
    //TODO: call here libuv uv_run(loop, UV_RUN_ONCE)
    //TODO: generate via a macro async function for each exported function that gets executed on main thread via uv_async_send
    //TODO: but we need to verify somehow that the entity didn't got deleted in the time, maybe create a set where we add valid entity pointers
    //TODO: and remove the pointers when entity got removed
    //TODO: and check in execute if the entity is still in set
    //TODO: set doesnt needs to be threadsafe, but needs to be a hashset for O(1)
}

void CSharpResource_Reload(CSharpResourceImpl* resource) {
    resource->OnStopDelegate();
    resource->coreClr->ExecuteManagedResourceUnload(resource->resource->GetPath().CStr(),
                                                    resource->resource->GetMain().CStr());
    resource->coreClr->ExecuteManagedResource(resource->resource->GetPath().CStr(), resource->resource->GetName().CStr(),
                                              resource->resource->GetMain().CStr(), resource->resource);
    resource->MainDelegate(resource->server, resource->resource, resource->resource->GetName().CStr(), resource->resource->GetMain().CStr());
}

void CSharpResource_Load(CSharpResourceImpl* resource) {
    resource->coreClr->ExecuteManagedResource(resource->resource->GetPath().CStr(), resource->resource->GetName().CStr(),
                                              resource->resource->GetMain().CStr(), resource->resource);
    resource->MainDelegate(resource->server, resource->resource, resource->resource->GetName().CStr(), resource->resource->GetMain().CStr());
}

void CSharpResource_Unload(CSharpResourceImpl* resource) {
    resource->OnStopDelegate();
    resource->coreClr->ExecuteManagedResourceUnload(resource->resource->GetPath().CStr(),
                                                    resource->resource->GetMain().CStr());
}

void Server_GetCSharpResource(alt::ICore* server, const char* resourceName, CSharpResourceImpl*&resource) {
    resource = (CSharpResourceImpl*) server->GetResource(resourceName);
}

void CSharpResource_SetMain(CSharpResourceImpl* resource, MainDelegate_t mainDelegate, StopDelegate_t stopDelegate,
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