#include "colshape.h"

// WorldObject

void ColShape_GetPosition(alt::IColShape* colShape, position_t &position) {
    auto vehiclePosition = colShape->GetPosition();
    position.x = vehiclePosition.x;
    position.y = vehiclePosition.y;
    position.z = vehiclePosition.z;
}

void ColShape_SetPosition(alt::IColShape* colShape, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    colShape->SetPosition(position);
}

int32_t ColShape_GetDimension(alt::IColShape* colShape) {
    return colShape->GetDimension();
}

void ColShape_SetDimension(alt::IColShape* colShape, int32_t dimension) {
    colShape->SetDimension(dimension);
}

alt::MValueConst* ColShape_GetMetaData(alt::IColShape* colShape, const char* key) {
    return new alt::MValueConst(colShape->GetMetaData(key));
}

void ColShape_SetMetaData(alt::IColShape* colShape, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    colShape->SetMetaData(key, val->Get()->Clone());
}

bool ColShape_HasMetaData(alt::IColShape* colShape, const char* key) {
    return colShape->HasMetaData(key);
}

void ColShape_DeleteMetaData(alt::IColShape* colShape, const char* key) {
    colShape->DeleteMetaData(key);
}

void ColShape_AddRef(alt::IColShape* colShape) {
    colShape->AddRef();
}

void ColShape_RemoveRef(alt::IColShape* colShape) {
    colShape->RemoveRef();
}

// ColShape

uint8_t ColShape_GetColShapeType(alt::IColShape* colShape) {
    return (uint8_t) colShape->GetColshapeType();
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