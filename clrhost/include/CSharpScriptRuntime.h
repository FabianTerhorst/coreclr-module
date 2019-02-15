#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/API.h>
#include <altv-cpp-api/IScriptRuntime.h>
#include "CSharpResource.h"
#include "CoreClr.h"
#ifdef __clang__
#pragma clang diagnostic pop
#endif

class CSharpScriptRuntime : public alt::IScriptRuntime
{
    alt::IResource *CreateResource(alt::IResource::CreationInfo *info) override;
    void DeleteResource(alt::IResource *resource) override;

    void OnTick() override;

  public:
    CSharpScriptRuntime(alt::IServer* server);

  private:
    alt::IServer *server;
    CoreClr* coreClr;
};
