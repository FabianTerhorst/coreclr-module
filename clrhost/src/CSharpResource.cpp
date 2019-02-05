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
    OnPlayerConnectDelegate = nullptr;
    OnPlayerDisconnectDelegate = nullptr;
    OnEntityRemoveDelegate = nullptr;
    OnServerEventDelegate = nullptr;
    OnStopDelegate = nullptr;

    coreClr->CreateAppDomain(server, fullPath, "/usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.1", &runtimeHost,
                             &domainId);

    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "Main",
                         reinterpret_cast<void**>(&MainDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                         "OnPlayerConnect", reinterpret_cast<void**>(&OnPlayerConnectDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnEntityRemove",
                         reinterpret_cast<void**>(&OnEntityRemoveDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnServerEvent",
                         reinterpret_cast<void**>(&OnServerEventDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnStop",
                         reinterpret_cast<void**>(&OnStopDelegate));
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
    switch (ev->GetType()) {
        case alt::CEvent::Type::PLAYER_CONNECT:
            OnPlayerConnectDelegate(((alt::CPlayerConnectEvent*) (ev))->GetTarget(),
                                    ((alt::CPlayerConnectEvent*) (ev))->GetReason().CStr());
            break;
        case alt::CEvent::Type::PLAYER_DISCONNECT:
            OnPlayerDisconnectDelegate(((alt::CPlayerDisconnectEvent*) (ev))->GetTarget(),
                                       ((alt::CPlayerDisconnectEvent*) (ev))->GetReason().CStr());
            break;
        case alt::CEvent::Type::REMOVE_ENTITY_EVENT:
            OnEntityRemoveDelegate(((alt::CRemoveEntityEvent*) (ev))->GetEntity());
            break;
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT:
            alt::MValueList args = (((alt::CServerScriptEvent*) (ev))->GetArgs());
            auto list = args.Get<alt::Array<alt::MValue>>();
            OnServerEventDelegate(((alt::CServerScriptEvent*) (ev))->GetName().CStr(), &list);
            break;
    }
    return false;
}

void CSharpResource::OnTick() {
}
