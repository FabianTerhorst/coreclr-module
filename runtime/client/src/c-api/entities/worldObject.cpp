#include "worldObject.h"
#include "../../../../cpp-sdk/SDK.h"
#include <Log.h>

using namespace alt;

alt::IBaseObject* WorldObject_GetBaseObject(alt::IWorldObject* worldObject) {
    return dynamic_cast<alt::IBaseObject*>(worldObject);
}

void WorldObject_GetPosition(alt::IWorldObject* worldObject, vector3_t& position) {
    auto pos = worldObject->GetPosition();
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
}