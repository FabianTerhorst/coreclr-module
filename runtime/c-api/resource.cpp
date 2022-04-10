//
// Created by Fabian Terhorst on 2019-02-23.
//

#include "resource.h"
#include "utils/strings.h"

const char* Resource_GetName(alt::IResource* resource, int32_t& size) {
    return AllocateString(resource->GetName(), size);
}

const char* Resource_GetType(alt::IResource* resource, int32_t& size) {
    return AllocateString(resource->GetType(), size);
}

CSharpResourceImpl* Resource_GetCSharpImpl(alt::IResource* resource) {
    return (CSharpResourceImpl*) resource->GetImpl();
}
uint64_t Resource_GetExportsCount(alt::IResource* resource) {
    alt::IMValueDict* dict = resource->GetExports().Get();
    if (dict == nullptr) return 0;
    return dict->GetSize();
}

void Resource_GetExports(alt::IResource* resource, const char* keys[],
                         alt::MValueConst* values[]) {
    auto dict = resource->GetExports();
    if (dict.Get() == nullptr) {
        return;
    }
    auto next = dict->Begin();
    uint64_t i = 0;
    do {
        alt::MValueConst mValueElement = next->GetValue();
        keys[i] = next->GetKey().c_str();
        values[i] = &mValueElement;
    } while ((next = dict->Next()) != nullptr);
}

alt::MValueConst* Resource_GetExport(alt::IResource* resource, const char* key) {
    alt::IMValueDict* dict = resource->GetExports().Get();
    if (dict == nullptr) return nullptr;
    auto value = dict->Get(key);
    if (value.Get() == nullptr) {
        return nullptr;
    }
    return new alt::MValueConst(value);
}

int Resource_GetDependenciesSize(alt::IResource* resource) {
    return resource->GetDependencies().GetSize();
}

void Resource_GetDependencies(alt::IResource* resource, const char* dependencies[], int size) {

    if (resource->GetDependencies().GetSize() != size) return;
    for (uint64_t i = 0, length = resource->GetDependencies().GetSize(); i < length; i++) {
        dependencies[i] = resource->GetDependencies()[i].c_str();
    }
}

int Resource_GetDependantsSize(alt::IResource* resource) {
    return resource->GetDependants().GetSize();
}

void Resource_GetDependants(alt::IResource* resource, const char* dependencies[], int size) {

    if (resource->GetDependants().GetSize() != size) return;
    for (uint64_t i = 0, length = resource->GetDependants().GetSize(); i < length; i++) {
        dependencies[i] = resource->GetDependants()[i].c_str();
    }
}

void Resource_SetExport(alt::ICore* core, alt::IResource* resource, const char* key, alt::MValueConst* val) {
    alt::MValueDict dict = resource->GetExports();
    if (dict.Get() == nullptr) {
        dict = core->CreateMValueDict();
        resource->SetExports(dict);
    }
    dict->Set(key, val->Get()->Clone());
}

void Resource_SetExports(alt::ICore* core, alt::IResource* resource, alt::MValueConst* val[], const char* keys[], int size) {
    alt::MValueDict dict = core->CreateMValueDict();
    for (int i = 0; i < size; i++) {
        dict->Set(keys[i], val[i]->Get()->Clone());
    }
    resource->SetExports(dict);
}

uint8_t Resource_IsStarted(alt::IResource* resource) {
    return resource->IsStarted();
}

alt::IResource::Impl* Resource_GetImpl(alt::IResource* resource) {
    return resource->GetImpl();
}

#ifdef ALT_SERVER_API
const char* Resource_GetPath(alt::IResource* resource, int32_t& size) {
    return AllocateString(resource->GetPath(), size);
}

const char* Resource_GetMain(alt::IResource* resource, int32_t& size) {
    return AllocateString(resource->GetMain(), size);
}

void Resource_Start(alt::IResource* resource) {
    resource->GetImpl()->Start();
}

void Resource_Stop(alt::IResource* resource) {
    resource->GetImpl()->Stop();
}
#endif

#ifdef ALT_CLIENT_API
bool Resource_FileExists(alt::IResource* resource, const char* path) {
    auto pkg = resource->GetPackage();
    return pkg->FileExists(path);
}

void Resource_GetFile(alt::IResource* resource, const char* path, int* bufferSize, void** buffer) {
    auto pkg = resource->GetPackage();
    if(!pkg->FileExists(path)) return;
    alt::IPackage::File* pkgFile = pkg->OpenFile(path);
    uint64_t size = pkg->GetFileSize(pkgFile);

    std::string content(size, 0);
    pkg->ReadFile(pkgFile, content.data(), content.size());
    pkg->CloseFile(pkgFile);

    *bufferSize = static_cast<int>(content.size());
    *buffer = utils::get_clr_value(content.data(), size);
}

alt::ILocalStorage* Resource_GetLocalStorage(alt::IResource* resource) {
    return resource->GetLocalStorage();
}

#endif