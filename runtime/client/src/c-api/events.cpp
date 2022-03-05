#include "events.h"

void Event_Cancel(alt::CEvent* event) {
    event->Cancel();
}

uint8_t Event_WasCancelled(alt::CEvent* event) {
    return event->WasCancelled();
}

#define SetDelegate(name) void Event_Set##name##Delegate(CSharpResourceImpl* resource, name##Delegate_t delegate) {\
    resource->On##name##Delegate = delegate;\
}

SetDelegate(Tick);
SetDelegate(ClientEvent);
SetDelegate(ServerEvent);
SetDelegate(ConsoleCommand);

SetDelegate(CreatePlayer);
SetDelegate(RemovePlayer);

SetDelegate(CreateVehicle);
SetDelegate(RemoveVehicle);

SetDelegate(PlayerSpawn);
SetDelegate(PlayerDisconnect);
SetDelegate(PlayerEnterVehicle);
