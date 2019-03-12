#include "CSharpResource.h"
#include "altv-c-api/mvalue.h"

CSharpResource::CSharpResource(alt::IServer* server, CoreClr* coreClr, alt::IResource::CreationInfo* info)
        : alt::IResource(info) {
    this->server = server;
    char wd[PATH_MAX];
    if (!GetCurrentDir(wd, PATH_MAX)) {
        server->LogInfo(alt::String("coreclr-module: Unable to find the working directory"));
        return;
    }
    const char* resourceName = name.CStr();
    auto fullPath = new char[strlen(wd) + strlen(RESOURCES_PATH) + strlen(resourceName) + 1];
    strcpy(fullPath, wd);
    strcat(fullPath, RESOURCES_PATH);
    strcat(fullPath, resourceName);

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
    OnConsoleCommandDelegate = nullptr;

    coreClr->CreateAppDomain(server, fullPath, &runtimeHost, &domainId);
    delete[] fullPath;

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
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnPlayerEnterVehicle",
                         reinterpret_cast<void**>(&OnPlayerEnterVehicleDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnPlayerLeaveVehicle",
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
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnCreateCheckpoint",
                         reinterpret_cast<void**>(&OnCreateCheckpointDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnRemoveCheckpoint",
                         reinterpret_cast<void**>(&OnRemoveCheckpointDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnConsoleCommand",
                         reinterpret_cast<void**>(&OnConsoleCommandDelegate));
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

CSharpResource::~CSharpResource() = default;

//TODO: needs entity type enum value for undefined
bool CSharpResource::OnEvent(const alt::CEvent* ev) {
    alt::Array<alt::MValue> list;
    alt::StringView reason;
    alt::IEntity* entity;
    server->LogInfo(alt::String("event: ") + ((int) ev->GetType() + '0'));
    const alt::CPlayerDisconnectEvent* disconnectEvent;
    alt::IPlayer* player;
    switch (ev->GetType()) {
        case alt::CEvent::Type::CHECKPOINT_EVENT:
            entity = ((alt::CCheckpointEvent*) (ev))->GetEntity();
            OnCheckpointDelegate(((alt::CCheckpointEvent*) (ev))->GetTarget(),
                                 GetEntityPointer(entity),
                                 entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                 ((alt::CCheckpointEvent*) (ev))->GetState());
            break;
        case alt::CEvent::Type::CLIENT_SCRIPT_EVENT:
            list = (((alt::CClientScriptEvent*) (ev))->GetArgs()).Get<alt::Array<alt::MValue>>();
            OnClientEventDelegate(((alt::CClientScriptEvent*) (ev))->GetTarget(),
                                  ((alt::CClientScriptEvent*) (ev))->GetName().CStr(), &list);
            break;
        case alt::CEvent::Type::PLAYER_CONNECT:
            player = reinterpret_cast<const alt::CPlayerConnectEvent*>(ev)->GetTarget();
            OnPlayerConnectDelegate(player, player->GetID(),
                                    "");//TODO: maybe better solution
            break;
        case alt::CEvent::Type::PLAYER_DAMAGE:
            entity = ((alt::CPlayerDamageEvent*) (ev))->GetAttacker();
            OnPlayerDamageDelegate(((alt::CPlayerDamageEvent*) (ev))->GetTarget(),
                                   GetEntityPointer(entity),
                                   entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                   entity != nullptr ? entity->GetID() : (uint16_t) 0,
                                   ((alt::CPlayerDamageEvent*) (ev))->GetWeapon(),
                                   ((alt::CPlayerDamageEvent*) (ev))->GetDamage());
            break;
        case alt::CEvent::Type::PLAYER_DEATH:
            entity = ((alt::CPlayerDeathEvent*) (ev))->GetKiller();
            OnPlayerDeathDelegate(((alt::CPlayerDeathEvent*) (ev))->GetTarget(),
                                  GetEntityPointer(entity),
                                  entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                  ((alt::CPlayerDeathEvent*) (ev))->GetWeapon());
            break;
        case alt::CEvent::Type::PLAYER_DISCONNECT:
            disconnectEvent = reinterpret_cast<const alt::CPlayerDisconnectEvent*>(ev);
            player = disconnectEvent->GetTarget();
            OnPlayerDisconnectDelegate(player,
                    /*((alt::CPlayerDisconnectEvent*) (ev))->GetReason().CStr()*/"");
            break;
        case alt::CEvent::Type::REMOVE_ENTITY_EVENT:
            entity = ((alt::CRemoveEntityEvent*) (ev))->GetEntity();
            if (entity != nullptr) {
                switch(entity->GetType()) {
                    case alt::IBaseObject::Type::PLAYER:
                        OnPlayerRemoveDelegate(dynamic_cast<alt::IPlayer*>(entity));
                        break;
                    case alt::IBaseObject::Type::VEHICLE:
                        OnVehicleRemoveDelegate(dynamic_cast<alt::IVehicle*>(entity));
                        break;
                }
            }
            break;
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT:
            list = (((alt::CServerScriptEvent*) (ev))->GetArgs()).Get<alt::Array<alt::MValue>>();
            OnServerEventDelegate(((alt::CServerScriptEvent*) (ev))->GetName().CStr(), &list);
            break;
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
        case alt::CEvent::Type::CONSOLE_COMMAND_EVENT:
            OnConsoleCommandDelegate(((alt::CConsoleCommandEvent*)(ev))->GetName().CStr(),
                                     ((alt::CConsoleCommandEvent*)(ev))->GetArgs());
            break;
    }
    return true;
}

void CSharpResource::OnCreateBaseObject(alt::IBaseObject* object) {
    switch (object->GetType()) {
        case alt::IBaseObject::Type::PLAYER:
            OnCreatePlayerDelegate(dynamic_cast<alt::IPlayer*>(object), dynamic_cast<alt::IPlayer*>(object)->GetID());
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
    }
}

void CSharpResource::OnRemoveBaseObject(alt::IBaseObject* object) {
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
    }
}

void CSharpResource::OnTick() {
    OnTickDelegate();
}

void CSharpResource_SetExport(CSharpResource* resource, const char* key, const alt::MValue &val) {
    resource->SetExport(key, val);
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