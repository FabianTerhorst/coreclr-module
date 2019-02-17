#include "mvalue.h"

alt::Array<CustomInvoker*> invokers;

CustomInvoker* Invoker_Create(MValueFunctionCallback val) {
    auto invoker = new CustomInvoker(val);
    invokers.Push(invoker);
    return invoker;
}

void Invoker_Destroy(CustomInvoker* val) {
    delete val;
}

void MValue_CreateNil(alt::MValue &mValue) {
    mValue = alt::MValue();
}

void MValue_CreateBool(bool val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateInt(int64_t val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateUInt(uint64_t val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateDouble(double val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateString(const char* val, alt::MValue &value) {
    value = alt::MValue(val);
}

void MValue_CreatePlayer(alt::IPlayer* val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateVehicle(alt::IVehicle* val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateBlip(alt::IVehicle* val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateCheckpoint(alt::ICheckpoint* val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

bool MValue_GetBool(alt::MValue &mValue) {
    return mValue.Get<bool>();
}

int64_t MValue_GetInt(alt::MValue &mValue) {
    return mValue.Get<int64_t>();
}

uint64_t MValue_GetUInt(alt::MValue &mValue) {
    return mValue.Get<uint64_t>();
}

double MValue_GetDouble(alt::MValue &mValue) {
    return mValue.Get<double>();
}

void MValue_GetString(alt::MValue &mValue, const char*&value) {
    value = mValue.Get<alt::String>().CStr();
}

void MValue_GetList(alt::MValue &mValue, alt::MValue::List &value) {
    value = mValue.Get<alt::MValue::List>();
}

void MValue_GetDict(alt::MValue &mValue, alt::Array<alt::String> &keys, alt::MValue::List &values) {
    auto dict = mValue.Get<alt::MValue::Dict>();
    alt::Array<alt::String> mapKeys;
    alt::MValue::List mapValues;
    for (auto &it : dict) {
        mapKeys.Push(it.first);
        mapValues.Push(it.second);
    }
    keys = mapKeys;
    values = mapValues;
}

void* MValue_GetEntity(alt::MValue &mValue, alt::IBaseObject::Type &type) {
    auto entityPointer = mValue.Get<alt::MValue::Entity>();
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

MValueFunctionCallback MValue_GetFunction(alt::MValueFunction &mValue) {
    return ((CustomInvoker *) mValue.GetInvoker())->mValueFunctionCallback;
}

void MValue_CreateList(alt::MValue val[], uint64_t size, alt::MValueList &valueList) {
    alt::MValueList value;
    for (int i = 0; i < size; i++) {
        value.Push(val[i]);
    }
    valueList = value;
}

void MValue_CreateDict(alt::MValue* val, const char** keys, uint64_t size, alt::MValueDict &mValue) {
    alt::MValueDict dict;
    for (int i = 0; i < size; i++) {
        dict[keys[i]] = val[i];
    }
    mValue = dict;
}

void MValue_CreateFunction(CustomInvoker* val, alt::MValue &mValue) {
    mValue = alt::MValueFunction(val);
}

void MValue_CallFunction(alt::MValueFunction &mValue, alt::MValue* args, uint64_t size, alt::MValue &result) {
    alt::MValueList value;
    for (int i = 0; i < size; i++) {
        value.Push(args[i]);
    }
    result = mValue.GetInvoker()->Invoke(value);
}
