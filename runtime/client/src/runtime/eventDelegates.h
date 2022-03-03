#pragma once
#include "altv-cpp-api/ICore.h"

typedef void (* TickDelegate_t)();
typedef void (* ServerEventDelegate_t)(const char* name, alt::MValueConst** args, uint64_t size);
typedef void (* ConsoleCommandDelegate_t)(const char* name, const char* args[], uint32_t size);

typedef void (* CreatePlayerDelegate_t)(alt::IPlayer*, uint16_t id);
typedef void (* RemovePlayerDelegate_t)(uint16_t);

typedef void (* CreateVehicleDelegate_t)(alt::IVehicle*, uint16_t id);
typedef void (* RemoveVehicleDelegate_t)(uint16_t);