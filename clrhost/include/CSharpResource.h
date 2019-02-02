#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/IResource.h>
#include <altv-cpp-api/IServer.h>
#include <altv-cpp-api/events/CPlayerConnectEvent.h>
#include <altv-cpp-api/events/CPlayerDisconnectEvent.h>
#include <altv-cpp-api/events/CRemoveEntityEvent.h>
#include <altv-cpp-api/events/CServerScriptEvent.h>
//#include "clrHost.h"

/*#include <iostream>

#ifdef _WIN32
#include <windows.h>
#else
#include <stdlib.h>
#include <dlfcn.h>
#include <dirent.h>
#include <sys/stat.h>
#endif*/

#include <unistd.h>
#include "CoreClr.h"
#ifdef __clang__
#pragma clang diagnostic pop
#endif

class CSharpResource : public alt::IResource
{
    bool OnEvent(const alt::CEvent *ev) override;
    void OnTick() override;
    bool Start() override;
    bool Stop() override;
    alt::String GetFilePath(const char *fileName);

  private:
    char *fullPath;
    alt::IServer *server;

  public:
    CSharpResource(alt::IServer *server, CoreClr *coreClr, alt::IResource::CreationInfo *info);
    ~CSharpResource();
    void (*OnPlayerConnectDelegate)(alt::IPlayer *player, const char *reason);
    void (*OnPlayerDisconnectDelegate)(alt::IPlayer *player, const char *reason);
    void (*OnEntityRemoveDelegate)(alt::IEntity *entity);
    void (*OnServerEventDelegate)(const char *name, alt::Array<alt::MValue> *args);
    void (*MainDelegate)(alt::IServer *server);
    void *runtimeHost;
    unsigned int domainId;
};
