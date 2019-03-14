#include "CSharpScriptRuntime.h"

CSharpScriptRuntime::CSharpScriptRuntime(alt::IServer* server)
{
    this->server = server;
    this->coreClr = new CoreClr(server);
}

alt::IResource *CSharpScriptRuntime::CreateResource(alt::IResource::CreationInfo* info)
{
    auto *cSharpResource = new CSharpResource(this->server, this->coreClr, info);
    return cSharpResource;
}

void CSharpScriptRuntime::RemoveResource(alt::IResource *resource)
{
    this->coreClr->Shutdown(this->server, ((CSharpResource*)resource)->runtimeHost, ((CSharpResource*)resource)->domainId);   
    delete resource;
}

void CSharpScriptRuntime::OnTick()
{
}
