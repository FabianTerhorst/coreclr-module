#pragma once
#include "altv-cpp-api/SDK.h"
#include "../types.h"

using namespace alt;

extern "C"
{
    EXPORT void FreeUIntArray(alt::Array<uint32_t> *array);
    EXPORT void FreeCharArray(char charArray[]);
    EXPORT void FreeString(const char* string);
}