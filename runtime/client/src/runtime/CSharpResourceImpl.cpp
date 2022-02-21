#include <utils.h>
#include <fstream>
#include <vector>
#include "CSharpScriptRuntime.h"
#include "CSharpResourceImpl.h"
#include "Log.h"
#include "CRC.h"
#include <sstream>
#include <string>
#include <iomanip>

using namespace std;

bool CSharpResourceImpl::Start()
{
    GetRuntime()->clr.start_resource(resource, core);
    return true;
}

bool CSharpResourceImpl::Stop()
{
    GetRuntime()->clr.stop_resource(resource);
    return true;
}

bool CSharpResourceImpl::OnEvent(const alt::CEvent* ev)
{
    if (ev == nullptr) return true;

    switch(ev->GetType()) {
        case alt::CEvent::Type::SERVER_SCRIPT_EVENT:
            auto serverScriptEvent = (alt::CServerScriptEvent*) ev;
            alt::MValueArgs serverArgs = serverScriptEvent->GetArgs();
            uint64_t size = serverArgs.GetSize();
            if (size == 0) {
                OnServerEventDelegate(serverScriptEvent->GetName().CStr(), nullptr, 0);
            } else {
                auto constArgs = new alt::MValueConst*[size];
                for(uint64_t i = 0; i < size; i++)
                {
                    constArgs[i] = &serverArgs[i];
                }
                OnServerEventDelegate(serverScriptEvent->GetName().CStr(), constArgs, size);
                delete[] constArgs;
            }
            break;
    }

    return true;
}

void CSharpResourceImpl::OnTick()
{
    OnTickDelegate();
}

void CSharpResourceImpl::OnCreateBaseObject(alt::Ref<alt::IBaseObject> object)
{
    // Called every time a base object has been created, so you can use this to keep track
    // of all the existing base objects, to check if they are valid in the user scripts
}

void CSharpResourceImpl::OnRemoveBaseObject(alt::Ref<alt::IBaseObject> object)
{
    // Called every time a base object has been created, so you can use this to keep track
    // of all the existing base objects, to check if they are valid in the user scripts
}

alt::String CSharpResourceImpl::ReadFile(alt::String path)
{
    auto pkg = resource->GetPackage();
    if(!pkg->FileExists(path)) return {};
    alt::IPackage::File* pkgFile = pkg->OpenFile(path);
    alt::String src(pkg->GetFileSize(pkgFile));
    pkg->ReadFile(pkgFile, src.GetData(), src.GetSize());
    pkg->CloseFile(pkgFile);

    return src;
}


void CSharpResourceImpl::ResetDelegates() {
    OnTickDelegate = []() {};
    OnServerEventDelegate = [](auto var, auto var2, auto var3) {};
}