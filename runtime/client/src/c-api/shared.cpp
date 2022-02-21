#include "shared.h"
#include "altv-cpp-api/SDK.h"
#include <Log.h>

using namespace alt;

void LogInfo(const char* str) {
    Log::Info << str << Log::Endl;
}

void LogWarning(const char* str) {
    Log::Warning << str << Log::Endl;
}

void LogDebug(const char* str) {
    Log::Debug << str << Log::Endl;
}

void LogError(const char* str) {
    Log::Error << str << Log::Endl;
}

void LogColored(const char* str) {
    Log::Colored << str << Log::Endl;
}