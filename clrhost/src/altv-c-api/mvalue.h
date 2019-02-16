#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/types/MValueFunction.h>
#include <altv-cpp-api/API.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef void (* MValueFunctionCallback)(alt::MValueList*, alt::MValue*);

class CustomInvoker : public alt::MValueFunction::Invoker {
public:
    MValueFunctionCallback mValueFunctionCallback;

    explicit CustomInvoker(MValueFunctionCallback mValueFunctionCallback) {
        this->mValueFunctionCallback = mValueFunctionCallback;
    }

    alt::MValue Invoke(alt::MValueList args) override {
        //auto list = args.Get<alt::MValue::List>();
        alt::MValue result;
        mValueFunctionCallback(&args, &result);
        return result;
    }
};

extern alt::Array<CustomInvoker*> invokers;

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT void String_Create(const char* value, alt::String &string);

EXPORT CustomInvoker* Invoker_Create(MValueFunctionCallback val);
EXPORT void Invoker_Destroy(CustomInvoker* val);

EXPORT void MValue_CreateNil(alt::MValue &mValue);
EXPORT void MValue_CreateBool(bool val, alt::MValue &mValue);
EXPORT void MValue_CreateInt(int64_t val, alt::MValue &mValue);
EXPORT void MValue_CreateUInt(uint64_t val, alt::MValue &mValue);
EXPORT void MValue_CreateDouble(double val, alt::MValue &mValue);
EXPORT void MValue_CreateString(const char* val, alt::MValue &value);
EXPORT void MValue_CreateList(alt::MValue val[], uint64_t size, alt::MValueList &valueList);
EXPORT void MValue_CreateDict(alt::MValue* val, const char** keys, uint64_t size, alt::MValueDict &mValue);
EXPORT void MValue_CreateEntity(alt::MValue::Entity val, alt::MValue &mValue);
EXPORT void MValue_CreateFunction(CustomInvoker* val, alt::MValue &mValue);

EXPORT bool MValue_GetBool(alt::MValue &mValue);
EXPORT int64_t MValue_GetInt(alt::MValue &mValue);
EXPORT uint64_t MValue_GetUInt(alt::MValue &mValue);
EXPORT double MValue_GetDouble(alt::MValue &mValue);
EXPORT void MValue_GetString(alt::MValue &mValue, const char*&value);
EXPORT void MValue_GetList(alt::MValue &mValue, alt::MValue::List &value);
EXPORT void MValue_GetDict(alt::MValue &mValue, alt::Array<alt::String> &keys, alt::MValue::List &values);
EXPORT void MValue_GetEntity(alt::MValue &mValue, alt::MValue::Entity &value, alt::IBaseObject::Type &type);
EXPORT MValueFunctionCallback MValue_GetFunction(alt::MValueFunction &mValue);

EXPORT void MValue_CallFunction(alt::MValueFunction &mValue, alt::MValue* args, uint64_t size, alt::MValue &result);
#ifdef __cplusplus
}
#endif
