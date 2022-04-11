#include "./map_data.h"
#include "./utils/strings.h"

#ifdef ALT_CLIENT_API
void MapData_SetFScrollSpeed(alt::IMapData* mapData, float value) {
    mapData->SetScrollSpeed(value);
}

float MapData_GetFScrollSpeed(alt::IMapData* mapData) {
    return mapData->GetScrollSpeed();
}

void MapData_SetFZoomScale(alt::IMapData* mapData, float value) {
    mapData->SetZoomScale(value);
}

float MapData_GetFZoomScale(alt::IMapData* mapData) {
    return mapData->GetZoomScale();
}

void MapData_SetFZoomSpeed(alt::IMapData* mapData, float value) {
    mapData->SetZoomSpeed(value);
}

float MapData_GetFZoomSpeed(alt::IMapData* mapData) {
    return mapData->GetZoomSpeed();
}

void MapData_SetVTilesX(alt::IMapData* mapData, float value) {
    mapData->SetTilesCountX(value);
}

float MapData_GetVTilesX(alt::IMapData* mapData) {
    return mapData->GetTilesCountX();
}

void MapData_SetVTilesY(alt::IMapData* mapData, float value) {
    mapData->SetTilesCountY(value);
}

float MapData_GetVTilesY(alt::IMapData* mapData) {
    return mapData->GetTilesCountY();
}

void MapData_Destroy(alt::IMapData* mapData) {
    mapData->RemoveRef();
}
#endif