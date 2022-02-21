#include "events.h"

void Event_Cancel(alt::CEvent* event) {
    event->Cancel();
}

uint8_t Event_WasCancelled(alt::CEvent* event) {
    return event->WasCancelled();
}

void Event_SetTickDelegate(CSharpResourceImpl* resource, TickDelegate_t delegate) {
    resource->OnTickDelegate = delegate;
}

void Event_SetServerEventDelegate(CSharpResourceImpl* resource, ServerEventDelegate_t delegate) {
    resource->OnServerEventDelegate = delegate;
}
