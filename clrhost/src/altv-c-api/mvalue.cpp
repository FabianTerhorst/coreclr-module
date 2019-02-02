#include "mvalue.h"

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

void MValue_CreateString(const char *val, alt::MValue &value) {
    value = alt::MValue(val);
}

void MValue_CreateEntity(const alt::MValue::Entity val, alt::MValue &mValue) {
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

void MValue_GetString(alt::MValue &mValue, const char *&value) {
    value = mValue.Get<alt::String>().CStr();
}

void MValue_GetList(alt::MValue &mValue,alt::MValue::List &value) {
    value = mValue.Get<alt::MValue::List>();
}

void MValue_GetDict(alt::MValue &mValue,alt::MValue::Dict &value) {
    value = mValue.Get<alt::MValue::Dict>();
}

void MValue_GetEntity(alt::MValue &mValue,alt::MValue::Entity &value) {
    value = mValue.Get<alt::MValue::Entity>();
}

void MValue_GetFunction(alt::MValue &mValue, alt::MValue* (*&value)(alt::MValueList)) {
    value = ((CustomInvoker*)mValue.Get<alt::MValue::Function>().invoker)->val;
}

void MValue_CreateList(alt::MValue val[], uint64_t size, alt::MValueList &valueList) {
    alt::MValueList value;
    for (int i = 0; i < size; i++) {
        value.Push(val[i]);
    }
    valueList = value;
}

void MValue_CreateDict(const alt::MValue *val, const char **keys, uint64_t size, alt::MValue &mValue) {
    alt::MValueDict value;
    for (int i = 0;i < size;i++) {
        value[alt::String(keys[i])] = &val[i];
    }
    mValue = value;
}

void MValue_CreateFunction(alt::MValue* (*val)(alt::MValueList), alt::MValue &mValue) {
    CustomInvoker invoker(val);
    mValue = alt::MValueFunction(&invoker);
}
