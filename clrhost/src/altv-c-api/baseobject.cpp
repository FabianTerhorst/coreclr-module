#include "baseobject.h"

uint8_t BaseObject_GetType(alt::IBaseObject* baseObject) {
    switch (baseObject->GetType()) {
        case alt::IBaseObject::Type::PLAYER:
            return 0;
        case alt::IBaseObject::Type::VEHICLE:
            return 1;
        case alt::IBaseObject::Type::CHECKPOINT:
            return 2;
        case alt::IBaseObject::Type::BLIP:
            return 3;
        case alt::IBaseObject::Type::WEBVIEW:
            return 4;
    }
    return baseObject->GetType();
}
