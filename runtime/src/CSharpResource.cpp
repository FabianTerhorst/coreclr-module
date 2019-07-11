#include "CSharpResource.h"
#include "altv-c-api/mvalue.h"

alt::IServer* currServer = nullptr;
auto resourcesCache = new alt::Array<CSharpResource*>;

CSharpResource::CSharpResource(alt::IServer* server, CoreClr* coreClr, alt::IResource::CreationInfo* info)
        : alt::IResource(info) {
    this->server = server;
    resourcesCache->Push(this);

    auto isDll = true;

    auto mainSize = main.GetSize();
    if (mainSize < 5 || memcmp(main.CStr() + mainSize - 4, ".dll", 4) != 0) {
        isDll = false;
    }

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

    currServer = server;

    if (isDll) {
        struct stat buf;
        char* assemblyPath = new char[this->GetPath().GetSize() + strlen(ASSEMBLY_PATH) + 1];
        memcpy(assemblyPath, this->GetPath().CStr(), this->GetPath().GetSize());
        memcpy(assemblyPath + this->GetPath().GetSize(), ASSEMBLY_PATH, strlen(ASSEMBLY_PATH));
        strcpy(assemblyPath + this->GetPath().GetSize() + strlen(ASSEMBLY_PATH), "\0");

        auto executable = (stat(assemblyPath, &buf) ==
                           0);//TODO: needs resource cfg "assembly"
        delete[] assemblyPath;

        coreClr->CreateAppDomain(server, this, this->GetPath().CStr(), &runtimeHost, &domainId, executable,
                                 resourcesCache->GetSize() - 1, this->name.CStr());

        if (!executable) {
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "Main",
                                 reinterpret_cast<void**>(&MainDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnCheckpoint", reinterpret_cast<void**>(&OnCheckpointDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnClientEvent", reinterpret_cast<void**>(&OnClientEventDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnPlayerConnect", reinterpret_cast<void**>(&OnPlayerConnectDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnPlayerDisconnect", reinterpret_cast<void**>(&OnPlayerDisconnectDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnPlayerDamage", reinterpret_cast<void**>(&OnPlayerDamageDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnPlayerDeath", reinterpret_cast<void**>(&OnPlayerDeathDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnPlayerRemove",
                                 reinterpret_cast<void**>(&OnPlayerRemoveDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnVehicleRemove",
                                 reinterpret_cast<void**>(&OnVehicleRemoveDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnServerEvent",
                                 reinterpret_cast<void**>(&OnServerEventDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnPlayerChangeVehicleSeat",
                                 reinterpret_cast<void**>(&OnPlayerChangeVehicleSeatDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnPlayerEnterVehicle",
                                 reinterpret_cast<void**>(&OnPlayerEnterVehicleDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnPlayerLeaveVehicle",
                                 reinterpret_cast<void**>(&OnPlayerLeaveVehicleDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnStop",
                                 reinterpret_cast<void**>(&OnStopDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnTick",
                                 reinterpret_cast<void**>(&OnTickDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnCreatePlayer",
                                 reinterpret_cast<void**>(&OnCreatePlayerDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnRemovePlayer",
                                 reinterpret_cast<void**>(&OnRemovePlayerDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnCreateVehicle",
                                 reinterpret_cast<void**>(&OnCreateVehicleDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnRemoveVehicle",
                                 reinterpret_cast<void**>(&OnRemoveVehicleDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnCreateBlip",
                                 reinterpret_cast<void**>(&OnCreateBlipDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnRemoveBlip",
                                 reinterpret_cast<void**>(&OnRemoveBlipDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnCreateCheckpoint",
                                 reinterpret_cast<void**>(&OnCreateCheckpointDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnRemoveCheckpoint",
                                 reinterpret_cast<void**>(&OnRemoveCheckpointDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnCreateVoiceChannel",
                                 reinterpret_cast<void**>(&OnCreateVoiceChannelDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnRemoveVoiceChannel",
                                 reinterpret_cast<void**>(&OnRemoveCheckpointDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnConsoleCommand",
                                 reinterpret_cast<void**>(&OnConsoleCommandDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnMetaDataChange",
                                 reinterpret_cast<void**>(&OnMetaChangeDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnSyncedMetaDataChange",
                                 reinterpret_cast<void**>(&OnSyncedMetaChangeDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnCreateColShape",
                                 reinterpret_cast<void**>(&OnCreateColShapeDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnRemoveColShape",
                                 reinterpret_cast<void**>(&OnRemoveColShapeDelegate));
            coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                                 "OnColShape",
                                 reinterpret_cast<void**>(&ColShapeDelegate));
        }
    } else {
#ifdef _WIN32
        server->LogInfo("Executable found, but not supported on windows");
#else
        server->LogInfo("Executable found, will fork");
        int status;
        pid_t pid = fork();
        if (pid == -1) {
            server->LogInfo("Can't fork, error occured");
        } else if (pid == 0) {
            auto index = resourcesCache->GetSize() - 1;

            char wd[PATH_MAX];
            if (!GetCurrentDir(wd, PATH_MAX)) {
                server->LogInfo(alt::String("coreclr-module: Unable to find the working directory"));
                return;
            }

            const char* currResourceName = name.CStr();
            auto currFullPath = new char[strlen(wd) + strlen(RESOURCES_PATH) + strlen(currResourceName) +
                                         strlen(main.CStr()) + 1 + 1];
            strcpy(currFullPath, wd);
            strcat(currFullPath, RESOURCES_PATH);
            strcat(currFullPath, currResourceName);
            strcat(currFullPath, "/");
            strcat(currFullPath, main.CStr());

            char resourceIndexChar = index + '0';
            char resourceIndexString[1];
            resourceIndexString[0] = resourceIndexChar;
            //TODO: fix / for windows
            /*char* argv[4];
            argv[0] = currFullPath;
            argv[1] = "start";
            argv[2] = resourceIndexString;
            argv[3] = NULL;

            printf("Executing resource with index %lld at path: %s\n", index, currFullPath);
            auto result = execvp(argv[0], &argv[1]);*/
            auto result = execl(currFullPath, main.CStr(), resourceIndexString, NULL);
            if (result == -1) {
                printf("execvp-error: %s\n", strerror(errno));
            } else {
                printf("%s\n", "Resource executed successfully");
            }
            free(currFullPath);
        } else {
            printf("Execute resource in pid: %d\n", pid);
            while (wait(&status) != pid);
            printf("Executed resource in pid: %d\n", pid);
        }
#endif
    }
}

bool CSharpResource::Start() {
    alt::IResource::Start();
    if (MainDelegate == nullptr) return false;
    MainDelegate(this->server, this, this->name.CStr(), main.CStr());
    return true;
}

bool CSharpResource::Stop() {
    alt::IResource::Stop();
    for (int i = 0; i < invokers.GetSize(); i++) {
        delete invokers[i];
    }
    if (OnStopDelegate == nullptr) return false;
    OnStopDelegate();
    return true;
}

CSharpResource::~CSharpResource() {
    int i = 0;
    for (auto resource : *resourcesCache) {
        if (resource == this) {
            auto newResourcesCache = new alt::Array<CSharpResource*>;
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
    }
}

//TODO: needs entity type enum value for undefined
bool CSharpResource::OnEvent(const alt::CEvent* ev) {
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
            OnCheckpointDelegate(((alt::CCheckpointEvent*) (ev))->GetTarget(),
                                 GetEntityPointer(entity),
                                 entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                 ((alt::CCheckpointEvent*) (ev))->GetState());
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
            OnPlayerDamageDelegate(((alt::CPlayerDamageEvent*) (ev))->GetTarget(),
                                   GetEntityPointer(entity),
                                   entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                   entity != nullptr ? entity->GetID() : (uint16_t) 0,
                                   ((alt::CPlayerDamageEvent*) (ev))->GetWeapon(),
                                   ((alt::CPlayerDamageEvent*) (ev))->GetDamage());
            break;
        }
        case alt::CEvent::Type::PLAYER_DEATH: {
            auto entity = ((alt::CPlayerDeathEvent*) (ev))->GetKiller();
            OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget(),
                                  GetEntityPointer(entity),
                                  entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                  ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
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
            alt::Array<alt::MValue> serverArgs = (((alt::CServerScriptEvent*) (ev))->GetArgs());
            OnServerEventDelegate(((alt::CServerScriptEvent*) (ev))->GetName().CStr(),
                                  &serverArgs);
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
            if (entity != nullptr) {
                switch (entity->GetType()) {
                    case alt::IBaseObject::Type::PLAYER:
                        ColShapeDelegate(((alt::CColShapeEvent*) (ev))->GetTarget(),
                                         dynamic_cast<alt::IPlayer*>(entity),
                                         entity->GetType(),
                                         ((alt::CColShapeEvent*) (ev))->GetState());
                        break;
                    case alt::IBaseObject::Type::VEHICLE:
                        ColShapeDelegate(((alt::CColShapeEvent*) (ev))->GetTarget(),
                                         dynamic_cast<alt::IVehicle*>(entity),
                                         entity->GetType(),
                                         ((alt::CColShapeEvent*) (ev))->GetState());
                        break;
                }
            }
            break;
        }
    }
    return true;
}

void CSharpResource::OnCreateBaseObject(alt::IBaseObject* object) {
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

void CSharpResource::OnRemoveBaseObject(alt::IBaseObject* object) {
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

void CSharpResource::OnTick() {
    OnTickDelegate();
}

void CSharpResource_SetExport(CSharpResource* resource, const char* key, const alt::MValue &val) {
    resource->SetExport(key, val);
}

void CSharpResource_SetMain(CSharpResource* resource, MainDelegate_t mainDelegate, TickDelegate_t tickDelegate,
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

alt::IServer* CSharpResource_GetServerPointer() {
    return currServer;
}

CSharpResource* CSharpResource_GetResourcePointer(int32_t resourceIndex) {
    return (*resourcesCache)[resourceIndex];
}

void CSharpResource::MakeClient(alt::IResource::CreationInfo* info, alt::Array<alt::String> files) {
    info->type = "js";
}

void* CSharpResource::GetBaseObjectPointer(alt::IBaseObject* baseObject) {
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

void* CSharpResource::GetEntityPointer(alt::IEntity* entity) {
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