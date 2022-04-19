#define ALT_CLIENT_API
#include <exceptions/LoadException.h>
#include "../../cpp-sdk/SDK.h"
#include "runtime/CSharpScriptRuntime.h"
#include "../../cpp-sdk/version/version.h"
#include <Log.h>

using namespace alt;

EXPORT alt::IScriptRuntime* CreateScriptRuntime(ICore* core)
{
    ICore::SetInstance(core);
    try
    {
        Log::Info << "Main thread is " << std::this_thread::get_id() << Log::Endl;
        Log::Info << "Starting initialization" << Log::Endl;
        auto* runtime = new CSharpScriptRuntime(core);
        core->RegisterScriptRuntime("csharp", runtime);
        Log::Info << "Initialized successfully" << Log::Endl;
        return runtime;
    } catch(std::exception& e) {
        Log::Error << "Initialization failed:" << Log::Endl;
        Log::Error << e.what() << Log::Endl;
        throw;
    }
}

EXPORT const char* GetType()
{
    return "csharp";
}

EXPORT char* GetSDKHash()
{
    return ALT_SDK_VERSION;
}

#ifdef DEBUG_CLIENT
int main() {
    try {
        CoreCLR clr(nullptr);
        clr.Initialize();
//        Test test;
//        clr.start_resource(&test);
    } catch(std::exception& e) {
        Log::Error << "Initialization failed: " << Log::Endl;
        Log::Error << e.what() << Log::Endl;
    }
}
#endif