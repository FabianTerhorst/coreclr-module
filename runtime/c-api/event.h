#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "data/types.h"
#include "utils/export.h"

#ifdef ALT_CLIENT_API
#include "../client/src/runtime/CSharpResourceImpl.h"
#include "../client/src/runtime/eventDelegates.h"
#endif

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
    
EXPORT_SERVER void Event_Cancel(alt::CEvent* event);
EXPORT_SERVER void Event_PlayerBeforeConnect_Cancel(alt::CEvent* event, const char* reason);
EXPORT_SERVER uint8_t Event_WasCancelled(alt::CEvent* event);

#ifdef ALT_CLIENT_API
EXPORT_CLIENT void Event_SetTickDelegate(CSharpResourceImpl* resource, /** ClientEvents.TickModuleDelegate */ TickDelegate_t delegate);
EXPORT_CLIENT void Event_SetServerEventDelegate(CSharpResourceImpl* resource,  /** ClientEvents.ServerEventModuleDelegate */ ServerEventDelegate_t delegate);
EXPORT_CLIENT void Event_SetClientEventDelegate(CSharpResourceImpl* resource,  /** ClientEvents.ClientEventModuleDelegate */ ClientEventDelegate_t delegate);
EXPORT_CLIENT void Event_SetConsoleCommandDelegate(CSharpResourceImpl* resource,  /** ClientEvents.ConsoleCommandModuleDelegate */ ConsoleCommandDelegate_t delegate);
EXPORT_CLIENT void Event_SetWebViewEventDelegate(CSharpResourceImpl* resource,  /** ClientEvents.WebViewEventModuleDelegate */ WebViewEventDelegate_t delegate);
EXPORT_CLIENT void Event_SetWebSocketEventDelegate(CSharpResourceImpl* resource,  /** ClientEvents.WebSocketEventModuleDelegate */ WebSocketEventDelegate_t delegate);
EXPORT_CLIENT void Event_SetRmlEventDelegate(CSharpResourceImpl* resource,  /** ClientEvents.RmlEventModuleDelegate */ RmlEventDelegate_t delegate);

EXPORT_CLIENT void Event_SetCreatePlayerDelegate(CSharpResourceImpl* resource, /** ClientEvents.CreatePlayerModuleDelegate */ CreatePlayerDelegate_t delegate);
EXPORT_CLIENT void Event_SetRemovePlayerDelegate(CSharpResourceImpl* resource,  /** ClientEvents.RemovePlayerModuleDelegate */ RemovePlayerDelegate_t delegate);

EXPORT_CLIENT void Event_SetCreateVehicleDelegate(CSharpResourceImpl* resource, /** ClientEvents.CreateVehicleModuleDelegate */ CreateVehicleDelegate_t delegate);
EXPORT_CLIENT void Event_SetRemoveVehicleDelegate(CSharpResourceImpl* resource,  /** ClientEvents.RemoveVehicleModuleDelegate */ RemoveVehicleDelegate_t delegate);

EXPORT_CLIENT void Event_SetPlayerSpawnDelegate(CSharpResourceImpl* resource, /** ClientEvents.PlayerSpawnModuleDelegate */ PlayerSpawnDelegate_t delegate);
EXPORT_CLIENT void Event_SetPlayerDisconnectDelegate(CSharpResourceImpl* resource, /** ClientEvents.PlayerDisconnectModuleDelegate */ PlayerDisconnectDelegate_t delegate);
EXPORT_CLIENT void Event_SetPlayerEnterVehicleDelegate(CSharpResourceImpl* resource, /** ClientEvents.PlayerEnterVehicleModuleDelegate */ PlayerEnterVehicleDelegate_t delegate);
EXPORT_CLIENT void Event_SetPlayerLeaveVehicleDelegate(CSharpResourceImpl* resource, /** ClientEvents.PlayerLeaveVehicleModuleDelegate */ PlayerLeaveVehicleDelegate_t delegate);

EXPORT_CLIENT void Event_SetGameEntityCreateDelegate(CSharpResourceImpl* resource, /** ClientEvents.GameEntityCreateModuleDelegate */ GameEntityCreateDelegate_t delegate);
EXPORT_CLIENT void Event_SetGameEntityDestroyDelegate(CSharpResourceImpl* resource, /** ClientEvents.GameEntityDestroyModuleDelegate */ GameEntityDestroyDelegate_t delegate);
EXPORT_CLIENT void Event_SetRemoveEntityDelegate(CSharpResourceImpl* resource, /** ClientEvents.RemoveEntityModuleDelegate */ RemoveEntityDelegate_t delegate);

EXPORT_CLIENT void Event_SetAnyResourceErrorDelegate(CSharpResourceImpl* resource, /** ClientEvents.AnyResourceErrorModuleDelegate */ AnyResourceErrorDelegate_t delegate);
EXPORT_CLIENT void Event_SetAnyResourceStartDelegate(CSharpResourceImpl* resource, /** ClientEvents.AnyResourceStartModuleDelegate */ AnyResourceStartDelegate_t delegate);
EXPORT_CLIENT void Event_SetAnyResourceStopDelegate(CSharpResourceImpl* resource, /** ClientEvents.AnyResourceStopModuleDelegate */ AnyResourceStopDelegate_t delegate);

EXPORT_CLIENT void Event_SetKeyUpDelegate(CSharpResourceImpl* resource, /** ClientEvents.KeyUpModuleDelegate */ KeyUpDelegate_t delegate);
EXPORT_CLIENT void Event_SetKeyDownDelegate(CSharpResourceImpl* resource, /** ClientEvents.KeyDownModuleDelegate */ KeyDownDelegate_t delegate);

EXPORT_CLIENT void Event_SetPlayerChangeVehicleSeatDelegate(CSharpResourceImpl* resource, /** ClientEvents.PlayerChangeVehicleSeatModuleDelegate */ PlayerChangeVehicleSeatDelegate_t delegate);

EXPORT_CLIENT void Event_SetConnectionCompleteDelegate(CSharpResourceImpl* resource, /** ClientEvents.ConnectionCompleteModuleDelegate */ ConnectionCompleteDelegate_t delegate);

EXPORT_CLIENT void Event_SetGlobalMetaChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.GlobalMetaChangeModuleDelegate */ GlobalMetaChangeDelegate_t delegate);
EXPORT_CLIENT void Event_SetGlobalSyncedMetaChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.GlobalSyncedMetaChangeModuleDelegate */ GlobalMetaChangeDelegate_t delegate);
EXPORT_CLIENT void Event_SetLocalMetaChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.LocalMetaChangeModuleDelegate */ LocalMetaChangeDelegate_t delegate);
EXPORT_CLIENT void Event_SetStreamSyncedMetaChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.StreamSyncedMetaChangeModuleDelegate */ StreamSyncedMetaChangeDelegate_t delegate);
EXPORT_CLIENT void Event_SetSyncedMetaChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.SyncedMetaChangeModuleDelegate */ SyncedMetaChangeDelegate_t delegate);

EXPORT_CLIENT void Event_SetNetOwnerChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.NetOwnerChangeModuleDelegate */ NetOwnerChangeDelegate_t delegate);

EXPORT_CLIENT void Event_SetTaskChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.TaskChangeModuleDelegate */ TaskChangeDelegate_t delegate);

EXPORT_CLIENT void Event_SetWindowFocusChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.WindowFocusChangeModuleDelegate */ WindowFocusChangeDelegate_t delegate);
EXPORT_CLIENT void Event_SetWindowResolutionChangeDelegate(CSharpResourceImpl* resource, /** ClientEvents.WindowResolutionChangeModuleDelegate */ WindowResolutionChangeDelegate_t delegate);

#endif

#ifdef __cplusplus
}
#endif
