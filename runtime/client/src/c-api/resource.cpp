#include "resource.h"
#include "utils.h"

char* Resource_GetName(alt::IResource* resource) {
    return utils::get_clr_value(resource->GetName().CStr());
}

bool Resource_FileExists(alt::IResource* resource, const char* path) {
    auto pkg = resource->GetPackage();
    return pkg->FileExists(path);
}

void Resource_GetFile(alt::IResource* resource, const char* path, int* bufferSize, void** buffer) {
    auto pkg = resource->GetPackage();
    if(!pkg->FileExists(path)) return;
    alt::IPackage::File* pkgFile = pkg->OpenFile(path);
    uint64_t size = pkg->GetFileSize(pkgFile);

    alt::String content(size);
    pkg->ReadFile(pkgFile, content.GetData(), content.GetSize());
    pkg->CloseFile(pkgFile);

    *bufferSize = static_cast<int>(content.GetSize());
    *buffer = utils::get_clr_value(content.GetData(), size);
}

CSharpResourceImpl* Resource_GetCSharpImpl(alt::IResource* resource)
{
    return (CSharpResourceImpl*) resource->GetImpl();
}
