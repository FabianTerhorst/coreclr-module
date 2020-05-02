#include "event.h"

void Event_Cancel(alt::CEvent* event) {
    event->Cancel();
}

bool Event_WasCancelled(alt::CEvent* event) {
    return event->WasCancelled();
}