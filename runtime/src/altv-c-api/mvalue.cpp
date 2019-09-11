#include "mvalue.h"

CustomInvoker* Invoker_Create(CSharpResourceImpl* resource, MValueFunctionCallback val) {
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

void MValue_GetString(alt::MValue &mValue, const char*&value, uint64_t &size) {
    value = mValue.Get<alt::String>().CStr();
    size = mValue.Get<alt::String>().GetSize();
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
    //TODO: find better way, this only works for c# module invokers
    return ((CustomInvoker*) mValue.GetInvoker())->mValueFunctionCallback;
}

/*alt::MValueFunction::Invoker* MValue_GetInvoker(alt::MValueFunction &mValue) {
    return mValue.GetInvoker();
}*/

/*typedef union {
    alt::IEntity* entityPointerValue;
    const char* stringValue;
    long intValue;
    unsigned long uintValue;
    double doubleValue;
    alt::MValue::Dict dictValue;
    alt::MValue::List listValue;
    alt::MValue::Function functionValue;
    bool boolValue;
} mvalue_data;

struct _Storage {
    uint64_t refCount = 1;
};

struct Storage : _Storage {
    mvalue_data value;
};

typedef struct {
    uint8_t type;
    Storage* storage;
} alt_mvalue_t;

void MValue_GetData(alt::MValue* mValue, mvalue_data*&data) {
    data = &((alt_mvalue_t*) mValue)->storage->value;
}*/

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

void MValue_CallFunction(alt::MValue* mValue, alt::MValue* args, int32_t size, alt::MValue &result) {
    alt::MValueList value;
    for (int i = 0; i < size; i++) {
        value.Push(args[i]);
    }
    result = ((alt::MValueFunction*) mValue)->GetInvoker()->Invoke(value);
}

void MValue_CallFunctionValue(alt::MValueFunction &mValue, alt::MValueList &value, alt::MValue &result) {
    result = mValue.GetInvoker()->Invoke(value);
}

void MValue_Dispose(alt::MValue* mValue) {
    mValue->~MValue();
}