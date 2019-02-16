#include "CSharpResource.h"
#include "altv-c-api/mvalue.h"

CSharpResource::CSharpResource(alt::IServer* server, CoreClr* coreClr, alt::IResource::CreationInfo* info)
        : alt::IResource(info) {
    this->server = server;
    char wd[PATH_MAX];
    if (!GetCurrentDir(wd, PATH_MAX)) {
        server->LogInfo(alt::String("[.NET] Unable to find the working directory"));
        return;
    }
    const char* resourceName = name.CStr();
    char fullPath[strlen(wd) + strlen(RESOURCES_PATH) + strlen(resourceName) + 1];
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
    OnPlayerDeadDelegate = nullptr;
    OnPlayerDisconnectDelegate = nullptr;
    OnEntityRemoveDelegate = nullptr;
    OnServerEventDelegate = nullptr;
    OnVehicleChangeSeatDelegate = nullptr;
    OnVehicleEnterDelegate = nullptr;
    OnVehicleLeaveDelegate = nullptr;
    OnStopDelegate = nullptr;
    OnTickDelegate = nullptr;

    coreClr->CreateAppDomain(server, fullPath, &runtimeHost, &domainId);

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
                         "OnPlayerDead", reinterpret_cast<void**>(&OnPlayerDeadDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnEntityRemove",
                         reinterpret_cast<void**>(&OnEntityRemoveDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnServerEvent",
                         reinterpret_cast<void**>(&OnServerEventDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnVehicleChangeSeat",
                         reinterpret_cast<void**>(&OnVehicleChangeSeatDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnVehicleEnter",
                         reinterpret_cast<void**>(&OnVehicleEnterDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnVehicleLeave",
                         reinterpret_cast<void**>(&OnVehicleLeaveDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnStop",
                         reinterpret_cast<void**>(&OnStopDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnTick",
                         reinterpret_cast<void**>(&OnTickDelegate));
}

bool CSharpResource::Start() {
    alt::IResource::Start();
    if (MainDelegate == nullptr) return false;
    MainDelegate(this->server, this->name.CStr(), main.CStr());
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

bool CSharpResource::OnEvent(const alt::CEvent* ev) {
    alt::Array<alt::MValue> list;
    alt::IEntity* entity;
    const alt::CPlayerDisconnectEvent* disconnectEvent;
    alt::IPlayer* player;
    switch (ev->GetType()) {
        case alt::CEvent::Type::CHECKPOINT_EVENT:
            OnCheckpointDelegate(((alt::CCheckpointEvent*) (ev))->GetTarget(),
                                 ((alt::CCheckpointEvent*) (ev))->GetEntity(),
                                 ((alt::CCheckpointEvent*) (ev))->GetEntity()->GetType(),
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
                                   entity,
                                   entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                   entity != nullptr ? entity->GetID() : (uint16_t) 0,
                                   ((alt::CPlayerDamageEvent*) (ev))->GetWeapon(),
                                   ((alt::CPlayerDamageEvent*) (ev))->GetDamage());
            break;
        case alt::CEvent::Type::PLAYER_DEAD:
            entity = ((alt::CPlayerDeadEvent*) (ev))->GetKiller();
            OnPlayerDeadDelegate(((alt::CPlayerDeadEvent*) (ev))->GetTarget(),
                                 entity,
                                 entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT,
                                 ((alt::CPlayerDeadEvent*) (ev))->GetWeapon());
            break;
        case alt::CEvent::Type::PLAYER_DISCONNECT:
            disconnectEvent = reinterpret_cast<const alt::CPlayerDisconnectEvent*>(ev);
            player = disconnectEvent->GetTarget();
            OnPlayerDisconnectDelegate(player,
                    /*((alt::CPlayerDisconnectEvent*) (ev))->GetReason().CStr()*/"");
            break;
        case alt::CEvent::Type::REMOVE_ENTITY_EVENT:
            entity = ((alt::CRemoveEntityEvent*) (ev))->GetEntity();
            OnEntityRemoveDelegate(entity, entity != nullptr ? entity->GetType() : alt::IBaseObject::Type::CHECKPOINT);
            break;
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT:
            list = (((alt::CServerScriptEvent*) (ev))->GetArgs()).Get<alt::Array<alt::MValue>>();
            OnServerEventDelegate(((alt::CServerScriptEvent*) (ev))->GetName().CStr(), &list);
            break;
        case alt::CEvent::Type::VEHICLE_CHANGE_SEAT_EVENT:
            OnVehicleChangeSeatDelegate(((alt::CVehicleChangeSeatEvent*) (ev))->GetTarget(),
                                        ((alt::CVehicleChangeSeatEvent*) (ev))->GetPlayer(),
                                        ((alt::CVehicleChangeSeatEvent*) (ev))->GetOldSeat(),
                                        ((alt::CVehicleChangeSeatEvent*) (ev))->GetNewSeat());
            break;
        case alt::CEvent::Type::VEHICLE_ENTER_EVENT:
            OnVehicleEnterDelegate(((alt::CVehicleEnterEvent*) (ev))->GetTarget(),
                                   ((alt::CVehicleEnterEvent*) (ev))->GetPlayer(),
                                   ((alt::CVehicleEnterEvent*) (ev))->GetSeat());
            break;
        case alt::CEvent::Type::VEHICLE_LEAVE_EVENT:
            OnVehicleLeaveDelegate(((alt::CVehicleLeaveEvent*) (ev))->GetTarget(),
                                   ((alt::CVehicleLeaveEvent*) (ev))->GetPlayer(),
                                   ((alt::CVehicleLeaveEvent*) (ev))->GetSeat());
            break;
    }
    return true;
}

void CSharpResource::OnTick() {
    OnTickDelegate();
}
