#pragma once
#include "altv-cpp-api/SDK.h"
#include "../runtime/CSharpResourceImpl.h"

EXPORT void Event_Cancel(alt::CEvent* event);
EXPORT uint8_t Event_WasCancelled(alt::CEvent* event);

EXPORT void Event_SetTickDelegate(CSharpResourceImpl* resource, /** TickModuleDelegate */ TickDelegate_t delegate);
EXPORT void Event_SetServerEventDelegate(CSharpResourceImpl* resource,  /** ServerEventModuleDelegate */ ServerEventDelegate_t delegate);
EXPORT void Event_SetConsoleCommandDelegate(CSharpResourceImpl* resource,  /** ConsoleCommandModuleDelegate */ ConsoleCommandDelegate_t delegate);

EXPORT void Event_SetCreatePlayerDelegate(CSharpResourceImpl* resource, /** CreatePlayerModuleDelegate */ CreatePlayerDelegate_t delegate);
EXPORT void Event_SetRemovePlayerDelegate(CSharpResourceImpl* resource,  /** RemovePlayerModuleDelegate */ RemovePlayerDelegate_t delegate);

EXPORT void Event_SetCreateVehicleDelegate(CSharpResourceImpl* resource, /** CreateVehicleModuleDelegate */ CreateVehicleDelegate_t delegate);
EXPORT void Event_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,  /** RemoveVehicleModuleDelegate */ RemoveVehicleDelegate_t delegate);