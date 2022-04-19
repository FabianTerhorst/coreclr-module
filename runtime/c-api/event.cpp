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
SetDelegate(WebViewEvent);
SetDelegate(ConsoleCommand);
SetDelegate(RmlEvent);
SetDelegate(WebSocketEvent);

SetDelegate(CreatePlayer);
SetDelegate(RemovePlayer);

SetDelegate(CreateVehicle);
SetDelegate(RemoveVehicle);

SetDelegate(PlayerSpawn);
SetDelegate(PlayerDisconnect);
SetDelegate(PlayerEnterVehicle);
SetDelegate(PlayerLeaveVehicle);

SetDelegate(GameEntityCreate);
SetDelegate(GameEntityDestroy);
SetDelegate(RemoveEntity);

SetDelegate(AnyResourceError);
SetDelegate(AnyResourceStart);
SetDelegate(AnyResourceStop);

SetDelegate(KeyUp);
SetDelegate(KeyDown);

SetDelegate(PlayerChangeVehicleSeat);

SetDelegate(ConnectionComplete);

SetDelegate(GlobalMetaChange);
SetDelegate(GlobalSyncedMetaChange);
SetDelegate(LocalMetaChange);
SetDelegate(StreamSyncedMetaChange);
SetDelegate(SyncedMetaChange);

SetDelegate(NetOwnerChange);

SetDelegate(TaskChange);

SetDelegate(WindowFocusChange);
SetDelegate(WindowResolutionChange);
#endif