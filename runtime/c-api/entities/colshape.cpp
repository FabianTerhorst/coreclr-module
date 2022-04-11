#include "colshape.h"

alt::IWorldObject* ColShape_GetWorldObject(alt::IColShape* colShape) {
    return dynamic_cast<alt::IWorldObject*>(colShape);
}

uint8_t ColShape_IsEntityIn(alt::IColShape* colShape, alt::IEntity* entity) {
    return colShape->IsEntityIn(entity);
}

uint8_t ColShape_IsPointIn(alt::IColShape* colShape, vector3_t point) {
    return colShape->IsPointIn({ point.x, point.y, point.z });
}

#ifdef ALT_SERVER_API
uint8_t ColShape_GetColShapeType(alt::IColShape* colShape) {
    return (uint8_t) colShape->GetColshapeType();
}

void ColShape_SetPlayersOnly(alt::IColShape* colShape, uint8_t state) {
    colShape->SetPlayersOnly(state);
}

uint8_t ColShape_IsPlayersOnly(alt::IColShape* colShape) {
    return colShape->IsPlayersOnly();
}
#endif