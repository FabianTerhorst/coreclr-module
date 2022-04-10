#pragma once
#include "../../../cpp-sdk/ICore.h"

typedef void (* TickDelegate_t)();
typedef void (* ClientEventDelegate_t)(const char* name, alt::MValueConst** args, uint64_t size);
typedef void (* ServerEventDelegate_t)(const char* name, alt::MValueConst** args, uint64_t size);
typedef void (* WebViewEventDelegate_t)(alt::IWebView*, const char* name, alt::MValueConst** args, uint64_t size);
typedef void (* ConsoleCommandDelegate_t)(const char* name, const char* args[], uint32_t size);

typedef void (* CreatePlayerDelegate_t)(alt::IPlayer*, uint16_t id);
typedef void (* RemovePlayerDelegate_t)(alt::IPlayer*);

typedef void (* CreateVehicleDelegate_t)(alt::IVehicle*, uint16_t id);
typedef void (* RemoveVehicleDelegate_t)(alt::IVehicle*);

typedef void (* PlayerSpawnDelegate_t)();
typedef void (* PlayerDisconnectDelegate_t)();
typedef void (* PlayerEnterVehicleDelegate_t)(alt::IVehicle*, uint8_t seat);

typedef void (* ResourceErrorDelegate_t)(const char* name);
typedef void (* ResourceStartDelegate_t)(const char* name);
typedef void (* ResourceStopDelegate_t)(const char* name);

typedef void (* KeyUpDelegate_t)(uint32_t key);
typedef void (* KeyDownDelegate_t)(uint32_t key);