#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif

#include <altv-cpp-api/types/MValue.h>
#include <altv-cpp-api/types/MValueFunction.h>
#include <altv-cpp-api/API.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

class CustomInvoker : public alt::MValueFunction::Invoker {
public:
    alt::MValue* (*val)(alt::MValueList);

    explicit CustomInvoker(alt::MValue* (*val)(alt::MValueList)) {
        this->val = val;
    }

    alt::MValue Invoke(alt::MValueList args) override {
        return *val(args);
    }
};

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT void MValue_CreateNil(alt::MValue &mValue);
EXPORT void MValue_CreateBool(bool val, alt::MValue &mValue);
EXPORT void MValue_CreateInt(int64_t val, alt::MValue &mValue);
EXPORT void MValue_CreateUInt(uint64_t val, alt::MValue &mValue);
EXPORT void MValue_CreateDouble(double val, alt::MValue &mValue);
EXPORT void MValue_CreateString(const char *val, alt::MValue &mValue);
EXPORT void MValue_CreateList(const alt::MValue *val, uint64_t size, alt::MValue &mValue);
EXPORT void MValue_CreateDict(const alt::MValue *val, const char **keys, uint64_t size, alt::MValue &mValue);
EXPORT void MValue_CreateEntity(const alt::IBaseObject *val, alt::MValue &mValue);
EXPORT void MValue_CreateFunction(alt::MValue* (*val)(alt::MValueList), alt::MValue &mValue);
#ifdef __cplusplus
}
#endif
