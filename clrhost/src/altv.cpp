#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif

#include <altv-cpp-api/API.h>
#include "altv-c-api/altv.h"
#include "CSharpScriptRuntime.h"

EXPORT bool altMain(alt::IServer *server) {
    auto* cSharpScriptRuntime = new CSharpScriptRuntime(server);
    server->RegisterScriptRuntime("csharp", cSharpScriptRuntime);
    return true;
}
