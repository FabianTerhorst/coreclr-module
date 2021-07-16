#include "event.h"

void Event_Cancel(alt::CEvent* event) {
    event->Cancel();
}

uint8_t Event_WasCancelled(alt::CEvent* event) {
    return event->WasCancelled();
}