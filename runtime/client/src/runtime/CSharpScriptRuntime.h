#pragma once
#include <coreclr/CoreCLR.h>
#include "../../../cpp-sdk/SDK.h"

class CSharpScriptRuntime : public alt::IScriptRuntime {
public:
    explicit CSharpScriptRuntime(alt::ICore* core);

    alt::IResource::Impl * CreateImpl(alt::IResource *resource) override;
    void DestroyImpl(alt::IResource::Impl *impl) override;

    CoreClr clr;

private:
    alt::ICore* core;
};