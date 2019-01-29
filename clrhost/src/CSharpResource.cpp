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
    const char *wd = getWD().CStr();
    const char *resources = "/resources/";
    const char *resourceName = name.CStr();
    fullPath = (char *) malloc(strlen(wd) + strlen(resources) + strlen(resourceName) + 1);
    strcpy(fullPath, wd);
    strcat(fullPath, resources);
    strcat(fullPath, resourceName);

    server->LogInfo(alt::StringView(fullPath));
    server->LogInfo(alt::StringView(GetFilePath(main.CStr())));

    void* runtimeHost = nullptr;
    unsigned int domainId;
    coreClr->CreateAppDomain(server, fullPath, "/usr/share/dotnet/shared/Microsoft.NETCore.App/2.2.1", &runtimeHost, &domainId);

    MainMethod mainMethod = nullptr;
    //TODO: remove extension from main.CStr()
    coreClr->GetDelegate(server, runtimeHost, domainId, /*main.CStr()*/"AltV.Net", "AltV.Net.Module", "Main", reinterpret_cast<void **>(&mainMethod));
    if (mainMethod == nullptr) {
        server->LogInfo(alt::String("[.NET] Unable to find Main method"));
        return;
    } else {
        server->LogInfo(alt::String("[.NET] Found main method"));
    }
    mainMethod();
}

bool CSharpResource::OnEvent(const alt::CEvent *ev) {
    switch (ev->GetType()) {
        case alt::CEvent::Type::PLAYER_CONNECT:
            OnPlayerConnect(((alt::CPlayerConnectEvent *) (ev))->GetTarget(),
                            ((alt::CPlayerConnectEvent *) (ev))->GetReason().CStr());
            break;
        case alt::CEvent::Type::PLAYER_DISCONNECT:
            OnPlayerDisconnect(((alt::CPlayerDisconnectEvent *) (ev))->GetTarget(),
                               ((alt::CPlayerDisconnectEvent *) (ev))->GetReason().CStr());
            break;
    }
    return false;
}

void CSharpResource::OnTick() {
}

alt::String CSharpResource::GetFilePath(const char *fileName) {
    return alt::String(fullPath) + "/" + fileName;
}
