#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include "altv-c-api/altv.h"
#include "CSharpScriptRuntime.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

EXPORT bool altMain(alt::ICore* server) {
    auto* cSharpScriptRuntime = new CSharpScriptRuntime(server);
    server->RegisterScriptRuntime("csharp", cSharpScriptRuntime);
    return true;
}

EXPORT uint32_t GetSDKVersion() {
    return alt::ICore::SDK_VERSION;
}