#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/IScriptRuntime.h>
#ifdef __clang__
#pragma clang diagnostic pop
#endif

#include "clrHost.h"

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