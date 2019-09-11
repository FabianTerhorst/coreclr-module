#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif
#include <altv-cpp-api/SDK.h>
#include <altv-cpp-api/IScriptRuntime.h>
#include "CSharpResourceImpl.h"
#include "CoreClr.h"
#ifdef __clang__
#pragma clang diagnostic pop
#endif

class CSharpScriptRuntime : public alt::IScriptRuntime
{
    alt::IResource::Impl* CreateImpl(alt::IResource *resource) override;
    void DestroyImpl(alt::IResource::Impl *impl) override;

    void OnTick() override;

  public:
    CSharpScriptRuntime(alt::ICore* server);

  private:
    alt::ICore *core;
    CoreClr* coreClr;
};
