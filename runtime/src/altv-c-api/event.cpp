#include "event.h"

void Event_Cancel(alt::CEvent* event) {
    event->Cancel();
}

void Event_PlayerBeforeConnect_Cancel(alt::CEvent* event, const char* reason) {
    ((alt::CPlayerBeforeConnectEvent*) event)->Cancel(reason);
}

uint8_t Event_WasCancelled(alt::CEvent* event) {
    return event->WasCancelled();
}