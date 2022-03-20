#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

typedef alt::MValueConst* (* MValueFunctionCallback)(alt::MValueConst* [], long size);

class CustomInvoker : public alt::IMValueFunction::Impl {
public:
    MValueFunctionCallback mValueFunctionCallback;

    explicit CustomInvoker(MValueFunctionCallback mValueFunctionCallback) {
        this->mValueFunctionCallback = mValueFunctionCallback;
    }

    alt::MValue Call(alt::MValueArgs args) const override {
        uint64_t size = args.GetSize();
        if (size == 0) {
            alt::MValueConst* resultConstPtr = mValueFunctionCallback(nullptr, 0);
            alt::MValue result = *((alt::MValue*) resultConstPtr);
            return result;
        } else {
#ifdef _WIN32
            auto constArgs = new alt::MValueConst* [size];
#else
            alt::MValueConst* constArgs[size];
#endif
            for (uint64_t i = 0; i < size; i++) {
                constArgs[i] = &args[i];
            }
            alt::MValueConst* resultConstPtr = mValueFunctionCallback(constArgs, size);
#ifdef _WIN32
            delete[] constArgs;
#endif
            alt::MValue result = *((alt::MValue*) resultConstPtr);
            return result;
        }
    }
};
