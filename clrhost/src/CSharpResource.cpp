#include "CSharpResource.h"

alt::StringView getWD() {
#ifdef _WIN32
    char absolutePath[MAX_PATH];
    GetFullPathName(relativePath.c_str(), MAX_PATH, absolutePath, NULL);
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
    const char *resources = "/resources/";
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

    coreClr->CreateAppDomain(server, fullPath, "/usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.1", &runtimeHost,
                             &domainId);

    coreClr->GetDelegate(server, runtimeHost, domainId, main.CStr(), "AltV.Net.Module", "Main",
                         reinterpret_cast<void **>(&MainDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, main.CStr(), "AltV.Net.Module",
                         "OnPlayerConnect", reinterpret_cast<void **>(&OnPlayerConnectDelegate));
    coreClr->GetDelegate(server, runtimeHost, domainId, main.CStr(), "AltV.Net.Module", "OnEntityRemove",
                         reinterpret_cast<void **>(&OnEntityRemoveDelegate));
}

bool CSharpResource::Start() {
    alt::IResource::Start();
    MainDelegate(this->server);
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
    }
    return false;
}

void CSharpResource::OnTick() {
}

alt::String CSharpResource::GetFilePath(const char *fileName) {
    return alt::String(fullPath) + "/" + fileName;
}
