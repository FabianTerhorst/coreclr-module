#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/API.h>
#include <altv-cpp-api/events/CRemoveEntityEvent.h>

#ifdef _WIN32
#define RESOURCES_PATH "\\resources\\"
#else
#define RESOURCES_PATH "/resources/"
#endif

#ifdef _WIN32
#include <direct.h>
#define GetCurrentDir _getcwd
#else

#include <unistd.h>

#define GetCurrentDir getcwd
#endif

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


#ifdef _WIN32
#include <iostream>
#include <stdio.h>
#include <direct.h>
#else

#include <unistd.h>

#endif

#include "CoreClr.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

class CSharpResource : public alt::IResource {
    bool OnEvent(const alt::CEvent* ev) override;

    void OnTick() override;

    bool Start() override;

    bool Stop() override;

    void OnCreateBaseObject(alt::IBaseObject* object) override;

    void OnRemoveBaseObject(alt::IBaseObject* object) override;

    void* GetBaseObjectPointer(alt::IBaseObject* baseObject);

    void* GetEntityPointer(alt::IEntity* entity);

private:
    alt::IServer* server;

public:
    CSharpResource(alt::IServer* server, CoreClr* coreClr, alt::IResource::CreationInfo* info);

    ~CSharpResource();

    void SetExport(const char* key, const alt::MValue &mValue) {
        this->exports[key] = mValue;
    }

    void (* OnCheckpointDelegate)(alt::ICheckpoint* checkpoint, void* entity, alt::IBaseObject::Type type,
                                  bool state);

    void (* OnClientEventDelegate)(alt::IPlayer* player, const char* name, alt::Array<alt::MValue>* args);

    void (* OnPlayerConnectDelegate)(alt::IPlayer* player, uint16_t playerId, const char* reason);

    void (* OnPlayerDamageDelegate)(alt::IPlayer* player, void* attacker,
                                    alt::IBaseObject::Type attackerType, uint16_t attackerId, uint32_t weapon,
                                    uint16_t damage);

    void (* OnPlayerDeathDelegate)(alt::IPlayer* player, void* killer, alt::IBaseObject::Type killerType,
                                   uint32_t weapon);

    void (* OnPlayerDisconnectDelegate)(alt::IPlayer* player, const char* reason);

    void (* OnPlayerRemoveDelegate)(alt::IPlayer* player);

    void (* OnVehicleRemoveDelegate)(alt::IVehicle* vehicle);

    void (* OnServerEventDelegate)(const char* name, alt::Array<alt::MValue>* args);

    void (* OnPlayerChangeVehicleSeatDelegate)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t oldSeat,
                                               uint8_t newSeat);

    void (* OnPlayerEnterVehicleDelegate)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t seat);

    void (* OnPlayerLeaveVehicleDelegate)(alt::IVehicle* vehicle, alt::IPlayer* player, uint8_t seat);

    void (* OnStopDelegate)();

    void (* OnTickDelegate)();

    void
    (* MainDelegate)(alt::IServer* server, alt::IResource* resource, const char* resourceName, const char* entryPoint);

    void (* OnCreatePlayerDelegate)(alt::IPlayer* player, uint16_t id);

    void (* OnRemovePlayerDelegate)(alt::IPlayer* player);

    void (* OnCreateVehicleDelegate)(alt::IVehicle* vehicle, uint16_t id);

    void (* OnRemoveVehicleDelegate)(alt::IVehicle* vehicle);

    void (* OnCreateBlipDelegate)(alt::IBlip* blip);

    void (* OnRemoveBlipDelegate)(alt::IBlip* blip);

    void (* OnCreateCheckpointDelegate)(alt::ICheckpoint* checkpoint);

    void (* OnRemoveCheckpointDelegate)(alt::ICheckpoint* checkpoint);

    void* runtimeHost;
    unsigned int domainId;
};

EXPORT void CSharpResource_SetExport(CSharpResource* resource, const char* key, const alt::MValue &val);