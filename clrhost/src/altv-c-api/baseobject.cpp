#include "baseobject.h"

alt::IBaseObject::Type BaseObject_GetType(alt::IBaseObject *baseObject)
{
    return baseObject->GetType();
}
