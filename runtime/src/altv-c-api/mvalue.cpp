#include "mvalue.h"

alt::IMValueFunction::Impl* Invoker_Create(CSharpResourceImpl* resource, MValueFunctionCallback val) {
    auto invoker = new CustomInvoker(val);
    resource->invokers->Push(invoker);
    return invoker;
}

void Invoker_Destroy(CSharpResourceImpl* resource, CustomInvoker* val) {
    auto newInvokers = new alt::Array<CustomInvoker*>();
    for (alt::Size i = 0, length = resource->invokers->GetSize(); i < length; i++) {
        auto invoker = (*resource->invokers)[i];
        if (invoker != val) {
            newInvokers->Push(invoker);
        }
    }
    delete val;
    delete resource->invokers;
    resource->invokers = newInvokers;
}

bool MValue_GetBool(alt::MValueBool &mValue) {
    return mValue.Get()->Value();
}

int64_t MValue_GetInt(alt::MValueInt &mValue) {
    return mValue.Get()->Value();
}

uint64_t MValue_GetUInt(alt::MValueUInt &mValue) {
    return mValue.Get()->Value();
}

double MValue_GetDouble(alt::MValueDouble &mValue) {
    return mValue.Get()->Value();
}

void MValue_GetString(alt::MValueString &mValue, const char*&value, uint64_t &size) {
    auto stringView = mValue.Get()->Value();
    value = stringView.CStr();
    size = stringView.GetSize();
}

void MValue_GetList(alt::MValueList &mValue, alt::Array<alt::MValue> &value) {
    auto list = mValue.Get();
    auto size = list->GetSize();
    value = alt::Array<alt::MValue>(size);
    for (int i = 0;i < size;i++) {
        value.Push(list->Get(i));
    }
}

void MValue_GetDict(alt::MValueDict &mValue, alt::Array<alt::String> &keys, alt::Array<alt::MValueConst> &values) {
    auto dict = mValue.Get();
    auto next = dict->Begin();
    keys = alt::Array<alt::String>(dict->GetSize());
    values = alt::Array<alt::MValueConst>(dict->GetSize());
    do {
        keys.Push(next->GetKey());
        values.Push(next->GetValue());
    } while((next = dict->Next()) != nullptr);
}

void* MValue_GetEntity(alt::MValueBaseObject &mValue, alt::IBaseObject::Type &type) {
    auto entityPointer = mValue.Get()->Value().Get();
    if (entityPointer != nullptr) {
        type = entityPointer->GetType();
        switch (type) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(entityPointer);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(entityPointer);
            case alt::IBaseObject::Type::BLIP:
                return dynamic_cast<alt::IBlip*>(entityPointer);
            case alt::IBaseObject::Type::CHECKPOINT:
                return dynamic_cast<alt::ICheckpoint*>(entityPointer);
            default:
                return nullptr;
        }
    }
    return nullptr;
}

void MValue_CallFunction(alt::MValueFunction& mValue, alt::MValue val[], int32_t size, alt::MValue &result) {
    alt::MValueArgs value = alt::Array<alt::MValueConst>(size);
    for (int i = 0; i < size; i++) {
        value.Push(val[i]);
    }
    mValue.Get()->Call(value);
}

void MValue_Dispose(alt::MValue* mValue) {
    mValue->Free();
}