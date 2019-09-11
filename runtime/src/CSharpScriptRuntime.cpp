#include "CSharpScriptRuntime.h"

CSharpScriptRuntime::CSharpScriptRuntime(alt::ICore* core) {
    this->core = core;
    this->coreClr = new CoreClr(core);
    this->coreClr->CreateManagedHost();
}

alt::IResource::Impl* CSharpScriptRuntime::CreateImpl(alt::IResource* resource) {
    return new CSharpResourceImpl(this->core, this->coreClr, resource);
}

void CSharpScriptRuntime::DestroyImpl(alt::IResource::Impl* impl) {
    this->coreClr->Shutdown(this->core, ((CSharpResourceImpl*) impl)->runtimeHost,
                            ((CSharpResourceImpl*) impl)->domainId);
    delete impl;
}

void CSharpScriptRuntime::OnTick() {
}
