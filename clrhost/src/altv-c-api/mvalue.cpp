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

void MValue_CreateString(const char *val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateList(const alt::MValue *val, uint64_t size, alt::MValue &mValue) {
    auto array = alt::Array<alt::MValue>();
    for (int i = 0; i < size; i++) {
        array.Push(&val[i]);
    }
    mValue = alt::MValue(array);
}

void MValue_CreateDict(const alt::MValue *val, const char **keys, uint64_t size, alt::MValue &mValue) {
    auto values = std::unordered_map<alt::String, alt::MValue>();
    for (int i = 0;i < size;i++) {
        values[keys[i]] = &val[i];
    }
    mValue = alt::MValue(values);
}

void MValue_CreateEntity(const alt::MValue::Entity *val, alt::MValue &mValue) {
    mValue = alt::MValue(val);
}

void MValue_CreateFunction(alt::MValue* (*val)(alt::MValueList), alt::MValue &mValue) {
    CustomInvoker invoker(val);
    mValue = alt::MValueFunction(&invoker);
}
