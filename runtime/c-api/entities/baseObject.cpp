#include "baseObject.h"

using namespace alt;

void BaseObject_AddRef(alt::IBaseObject* baseObject) {
    baseObject->AddRef();
}

void BaseObject_RemoveRef(alt::IBaseObject* baseObject) {
    baseObject->RemoveRef();
}

void BaseObject_AddWeakRef(alt::IBaseObject* baseObject) {
    WeakRef<IBaseObject> weakRef(baseObject);
}

void BaseObject_SetMetaData(alt::IBaseObject* baseObject, const char* key, alt::MValueConst* value) {
    baseObject->SetMetaData(key, value->Get()->Clone());
}

uint8_t BaseObject_HasMetaData(alt::IBaseObject* baseObject, const char* key) {
    return baseObject->HasMetaData(key);
}

void BaseObject_DeleteMetaData(alt::IBaseObject* baseObject, const char* key) {
    baseObject->DeleteMetaData(key);
}

alt::MValueConst* BaseObject_GetMetaData(alt::IBaseObject* baseObject, const char* key) {
    return new MValueConst(baseObject->GetMetaData(key));
}

uint8_t BaseObject_GetType(alt::IBaseObject* baseObject)
{
    return (uint8_t) baseObject->GetType();
}
