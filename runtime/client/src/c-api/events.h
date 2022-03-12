#pragma once
#include "altv-cpp-api/SDK.h"
#include "../runtime/CSharpResourceImpl.h"

EXPORT void Event_Cancel(alt::CEvent* event);
EXPORT uint8_t Event_WasCancelled(alt::CEvent* event);

EXPORT void Event_SetTickDelegate(CSharpResourceImpl* resource, /** TickModuleDelegate */ TickDelegate_t delegate);
EXPORT void Event_SetServerEventDelegate(CSharpResourceImpl* resource,  /** ServerEventModuleDelegate */ ServerEventDelegate_t delegate);
EXPORT void Event_SetClientEventDelegate(CSharpResourceImpl* resource,  /** ClientEventModuleDelegate */ ClientEventDelegate_t delegate);
EXPORT void Event_SetConsoleCommandDelegate(CSharpResourceImpl* resource,  /** ConsoleCommandModuleDelegate */ ConsoleCommandDelegate_t delegate);

EXPORT void Event_SetCreatePlayerDelegate(CSharpResourceImpl* resource, /** CreatePlayerModuleDelegate */ CreatePlayerDelegate_t delegate);
EXPORT void Event_SetRemovePlayerDelegate(CSharpResourceImpl* resource,  /** RemovePlayerModuleDelegate */ RemovePlayerDelegate_t delegate);

EXPORT void Event_SetCreateVehicleDelegate(CSharpResourceImpl* resource, /** CreateVehicleModuleDelegate */ CreateVehicleDelegate_t delegate);
EXPORT void Event_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,  /** RemoveVehicleModuleDelegate */ RemoveVehicleDelegate_t delegate);

EXPORT void Event_SetPlayerSpawnDelegate(CSharpResourceImpl* resource, /** PlayerSpawnModuleDelegate */ PlayerSpawnDelegate_t delegate);
EXPORT void Event_SetPlayerDisconnectDelegate(CSharpResourceImpl* resource, /** PlayerDisconnectModuleDelegate */ PlayerDisconnectDelegate_t delegate);
EXPORT void Event_SetPlayerEnterVehicleDelegate(CSharpResourceImpl* resource, /** PlayerEnterVehicleModuleDelegate */ PlayerEnterVehicleDelegate_t delegate);

EXPORT void Event_SetResourceErrorDelegate(CSharpResourceImpl* resource, /** ResourceErrorModuleDelegate */ ResourceErrorDelegate_t delegate);
EXPORT void Event_SetResourceStartDelegate(CSharpResourceImpl* resource, /** ResourceStartModuleDelegate */ ResourceStartDelegate_t delegate);
EXPORT void Event_SetResourceStopDelegate(CSharpResourceImpl* resource, /** ResourceStopModuleDelegate */ ResourceStopDelegate_t delegate);

EXPORT void Event_SetKeyUpDelegate(CSharpResourceImpl* resource, /** KeyUpModuleDelegate */ KeyUpDelegate_t delegate);
EXPORT void Event_SetKeyDownDelegate(CSharpResourceImpl* resource, /** KeyDownModuleDelegate */ KeyDownDelegate_t delegate);

