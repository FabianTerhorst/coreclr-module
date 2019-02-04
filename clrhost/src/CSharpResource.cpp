#include "CSharpResource.h"
#include "altv-c-api/mvalue.h"

alt::StringView getWD() {
#ifdef _WIN32
    char* cwd = _getcwd( nullptr, 0 ) ;
    auto str = alt::String(cwd);
    free(cwd);
    return str;
#else
    char temp[PATH_MAX];
    if (getcwd(temp, PATH_MAX) != 0)
        return alt::StringView(temp);
    return "";
#endif
}

CSharpResource::CSharpResource(alt::IServer *server, CoreClr *coreClr, alt::IResource::CreationInfo *info)
        : alt::IResource(info) {
    this->server = server;
    const char *wd = getWD().CStr();
    const char *resources;
    #ifdef _WIN32
    resources = "\\resources\\";
    #else
    resources = "/resources/";
    #endif
    const char *resourceName = name.CStr();
    fullPath = (char *) malloc(strlen(wd) + strlen(resources) + strlen(resourceName) + 1);
    strcpy(fullPath, wd);
    strcat(fullPath, resources);
    strcat(fullPath, resourceName);

    server->LogInfo(alt::StringView(fullPath));
    server->LogInfo(alt::StringView(GetFilePath(main.CStr())));

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
                         reinterpret_cast<void **>(&MainDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper",
                         "OnPlayerConnect", reinterpret_cast<void **>(&OnPlayerConnectDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnEntityRemove",
                         reinterpret_cast<void **>(&OnEntityRemoveDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnServerEvent",
                         reinterpret_cast<void **>(&OnServerEventDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, "AltV.Net", "AltV.Net.ModuleWrapper", "OnStop",
                         reinterpret_cast<void **>(&OnStopDelegate));
}

bool CSharpResource::Start() {
    alt::IResource::Start();
    if (MainDelegate == nullptr) return false;
    MainDelegate(this->server, this->name.CStr(), main.CStr());
    return true;
}

bool CSharpResource::Stop() {
    alt::IResource::Stop();
    for(int i = 0; i < invokers.GetSize();i++) {
        delete invokers[i];
    }
    if (OnStopDelegate == nullptr) return false;
    OnStopDelegate();
    return true;
}

CSharpResource::~CSharpResource() {
    delete fullPath;
}

bool CSharpResource::OnEvent(const alt::CEvent *ev) {
    switch (ev->GetType()) {
        case alt::CEvent::Type::PLAYER_CONNECT:
            OnPlayerConnectDelegate(((alt::CPlayerConnectEvent *) (ev))->GetTarget(),
                                    ((alt::CPlayerConnectEvent *) (ev))->GetReason().CStr());
            break;
        case alt::CEvent::Type::PLAYER_DISCONNECT:
            OnPlayerDisconnectDelegate(((alt::CPlayerDisconnectEvent *) (ev))->GetTarget(),
                                       ((alt::CPlayerDisconnectEvent *) (ev))->GetReason().CStr());
            break;
        case alt::CEvent::Type::REMOVE_ENTITY_EVENT:
            OnEntityRemoveDelegate(((alt::CRemoveEntityEvent *) (ev))->GetEntity());
            break;
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT:
            alt::MValueList args = (((alt::CServerScriptEvent *) (ev))->GetArgs());
            auto list = args.Get<alt::Array<alt::MValue>>();
            OnServerEventDelegate(((alt::CServerScriptEvent *) (ev))->GetName().CStr(), &list);
            break;
    }
    return false;
}

void CSharpResource::OnTick() {
}

alt::String CSharpResource::GetFilePath(const char *fileName) {
    return alt::String(fullPath) + "/" + fileName;
}
