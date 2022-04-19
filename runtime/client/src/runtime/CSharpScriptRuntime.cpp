#include <Log.h>
#include "CSharpScriptRuntime.h"
#include "CSharpResourceImpl.h"
#include "natives.h"

#define WIN32_LEAN_AND_MEAN
#define NOMINMAX
#include <windows.h>

CSharpScriptRuntime::CSharpScriptRuntime(alt::ICore* core) : clr(core), core(core) {
    Log::Info << "CSharp runtime initialized" << Log::Endl;
    auto config = core->GetClientConfig();
    try {
        if (!config["disableRestrictedSandbox"].ToBool(false)) return;

        const int result = MessageBox(nullptr, L"You've enabled disableRestrictedSandbox in altv.cfg\r\n"
            "ONLY JOIN TRUSTED SERVERS, AS WITHOUT SANDBOXING THEY CAN ACCESS YOUR PERSONAL DATA.\r\n"
            "Are you sure you want to disable sandboxing?", L"Do you want to disable restricted sandbox?",  MB_YESNO | MB_ICONWARNING);
        if (result != IDYES) return;
        
        Log::Warning << "C# sandbox disabled" << Log::Endl;
        clr.sandbox = false;
    } catch(std::exception& e) {
        Log::Error << "Failed to parse disableRestrictedSandbox value: " << e.what() << Log::Endl;
    }
}

alt::IResource::Impl* CSharpScriptRuntime::CreateImpl(alt::IResource* resource)
{
    InitNatives();
    return new CSharpResourceImpl(this, resource, core);
}

void CSharpScriptRuntime::DestroyImpl(alt::IResource::Impl* impl) {}