#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_CLIENT void MapData_SetFScrollSpeed(alt::IMapData* mapData, float value);
EXPORT_CLIENT float MapData_GetFScrollSpeed(alt::IMapData* mapData);
EXPORT_CLIENT void MapData_SetFZoomScale(alt::IMapData* mapData, float value);
EXPORT_CLIENT float MapData_GetFZoomScale(alt::IMapData* mapData);
EXPORT_CLIENT void MapData_SetFZoomSpeed(alt::IMapData* mapData, float value);
EXPORT_CLIENT float MapData_GetFZoomSpeed(alt::IMapData* mapData);
EXPORT_CLIENT void MapData_SetVTilesX(alt::IMapData* mapData, float value);
EXPORT_CLIENT float MapData_GetVTilesX(alt::IMapData* mapData);
EXPORT_CLIENT void MapData_SetVTilesY(alt::IMapData* mapData, float value);
EXPORT_CLIENT float MapData_GetVTilesY(alt::IMapData* mapData);
EXPORT_CLIENT float MapData_Destroy(alt::IMapData* mapData);

#ifdef __cplusplus
}
#endif
