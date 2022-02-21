#pragma once
#include "altv-cpp-api/SDK.h"
#include "../runtime/CSharpResourceImpl.h"

EXPORT void Event_Cancel(alt::CEvent* event);
EXPORT uint8_t Event_WasCancelled(alt::CEvent* event);
EXPORT void Event_SetTickDelegate(CSharpResourceImpl* resource, /** TickDelegate */ TickDelegate_t delegate);
EXPORT void Event_SetServerEventDelegate(CSharpResourceImpl* resource,  /** ServerEventDelegate */ ServerEventDelegate_t delegate);