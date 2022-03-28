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
    // Handle incoming events here, e.g. call the event handlers registered by the resource
    return true;
}

void CSharpResourceImpl::OnTick()
{
    // Do everything here that needs to be handled on tick that is resource related
    // This can be e.g. timers
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
