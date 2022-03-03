#pragma once
#include "altv-cpp-api/SDK.h"
#include "../runtime/CSharpResourceImpl.h"

EXPORT void Event_Cancel(alt::CEvent* event);
EXPORT uint8_t Event_WasCancelled(alt::CEvent* event);

EXPORT void Event_SetTickDelegate(CSharpResourceImpl* resource, /** TickDelegate */ TickDelegate_t delegate);
EXPORT void Event_SetServerEventDelegate(CSharpResourceImpl* resource,  /** ServerEventDelegate */ ServerEventDelegate_t delegate);

EXPORT void Event_SetCreatePlayerDelegate(CSharpResourceImpl* resource, /** CreatePlayerDelegate */ CreatePlayerDelegate_t delegate);
EXPORT void Event_SetRemovePlayerDelegate(CSharpResourceImpl* resource,  /** RemovePlayerDelegate */ RemovePlayerDelegate_t delegate);

EXPORT void Event_SetCreateVehicleDelegate(CSharpResourceImpl* resource, /** CreateVehicleDelegate */ CreateVehicleDelegate_t delegate);
EXPORT void Event_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,  /** RemoveVehicleDelegate */ RemoveVehicleDelegate_t delegate);