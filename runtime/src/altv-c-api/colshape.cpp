#include "colshape.h"

// WorldObject

void ColShape_GetPosition(alt::IColShape* colShape, position_t &position) {
    auto vehiclePosition = colShape->GetPosition();
    position.x = vehiclePosition.x;
    position.y = vehiclePosition.y;
    position.z = vehiclePosition.z;
}

void ColShape_SetPosition(alt::IColShape* colShape, alt::Position pos) {
    colShape->SetPosition(pos);
}

int16_t ColShape_GetDimension(alt::IColShape* colShape) {
    return colShape->GetDimension();
}

void ColShape_SetDimension(alt::IColShape* colShape, int16_t dimension) {
    colShape->SetDimension(dimension);
}

void ColShape_GetMetaData(alt::IColShape* colShape, const char* key, alt::MValue &val) {
    val = colShape->GetMetaData(key);
}

void ColShape_SetMetaData(alt::IColShape* colShape, const char* key, alt::MValue* val) {
    colShape->SetMetaData(key, *val);
}

// ColShape

alt::ColShapeType ColShape_GetColShapeType(alt::IColShape* colShape) {
    return colShape->GetColshapeType();
}

/*bool ColShape_IsEntityIn(alt::IColShape* colShape, alt::IEntity* entity) {
    return colShape->IsEntityIn(entity);
}*/

bool ColShape_IsPlayerIn(alt::IColShape* colShape, alt::IPlayer* player) {
    return colShape->IsEntityIn(player);
}

bool ColShape_IsVehicleIn(alt::IColShape* colShape, alt::IVehicle* vehicle) {
    return colShape->IsEntityIn(vehicle);
}