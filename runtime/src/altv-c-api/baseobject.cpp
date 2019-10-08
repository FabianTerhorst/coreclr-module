#include "baseobject.h"

uint8_t BaseObject_GetType(alt::IBaseObject* baseObject) {
    return (uint8_t) baseObject->GetType();
}
