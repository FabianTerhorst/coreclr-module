#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif

//#include "altv.h"
//#include "clrHost.h"

#include <altv-cpp-api/API.h>
#include "CSharpScriptRuntime.h"

EXPORT bool altMain(alt::IServer *server) {
    server->LogInfo("HII from test");
    auto* cSharpScriptRuntime = new CSharpScriptRuntime(server);
    server->RegisterScriptRuntime("csharp", cSharpScriptRuntime);
    return true;
}

/*bool altMain(alt::IServer* server) {
    //auto* cSharpScriptRuntime = new CSharpScriptRuntime();
    //IServer::Instance().RegisterScriptRuntime("csharp", cSharpScriptRuntime);
    server->LogDebug("bla");
    return true;
}*/

/*static ClrHost *clrHost = nullptr;

void SetupPlugin(alt::IMultiplayer *mp) {
    clrHost = new ClrHost();
    if (clrHost->load() == false) {
        return;
    }

    if (clrHost->mainCallback() != nullptr) {
        clrHost->mainCallback()(mp);
    }
}

void CleanupPlugin() {
    if (clrHost == nullptr) {
        return;
    }

    clrHost->unload();

    delete clrHost;
    clrHost = nullptr;
}*/

//TODO: add altv main and trigger script runtime resource type ect.