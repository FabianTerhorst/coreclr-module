#pragma once
#include "../../../cpp-sdk/SDK.h"

extern "C"
{
    EXPORT void LogInfo(const char* str);
    EXPORT void LogDebug(const char* str);
    EXPORT void LogWarning(const char* str);
    EXPORT void LogError(const char* str);
    EXPORT void LogColored(const char* str);
}