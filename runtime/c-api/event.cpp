#include "event.h"

#ifdef ALT_SERVER_API
void Event_Cancel(alt::CEvent* event) {
    event->Cancel();
}

void Event_PlayerBeforeConnect_Cancel(alt::CEvent* event, const char* reason) {
    ((alt::CPlayerBeforeConnectEvent*) event)->Cancel(reason);
}

uint8_t Event_WasCancelled(alt::CEvent* event) {
    return event->WasCancelled();
}
#endif

#ifdef ALT_CLIENT_API
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

SetDelegate(ResourceError);
SetDelegate(ResourceStart);
SetDelegate(ResourceStop);

SetDelegate(KeyUp);
SetDelegate(KeyDown);
#endif