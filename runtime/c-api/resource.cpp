//
// Created by Fabian Terhorst on 2019-02-23.
//

#include "resource.h"

// needs migration to std::string in cpp-sdk
void Resource_GetName(alt::IResource* resource, const char*&text) {
    text = resource->GetName().CStr();
}

// needs migration to std::string in cpp-sdk
void Resource_GetType(alt::IResource* resource, const char*&text) {
    text = resource->GetType().CStr();
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
        keys[i] = next->GetKey().CStr();
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
        dependencies[i] = resource->GetDependencies()[i].CStr();
    }
}

int Resource_GetDependantsSize(alt::IResource* resource) {
    return resource->GetDependants().GetSize();
}

void Resource_GetDependants(alt::IResource* resource, const char* dependencies[], int size) {

    if (resource->GetDependants().GetSize() != size) return;
    for (uint64_t i = 0, length = resource->GetDependants().GetSize(); i < length; i++) {
        dependencies[i] = resource->GetDependants()[i].CStr();
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
// needs migration to std::string in cpp-sdk
void Resource_GetPath(alt::IResource* resource, const char*&text) {
    text = resource->GetPath().CStr();
}

// needs migration to std::string in cpp-sdk
void Resource_GetMain(alt::IResource* resource, const char*&text) {
    text = resource->GetMain().CStr();
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

    alt::String content(size);
    pkg->ReadFile(pkgFile, content.GetData(), content.GetSize());
    pkg->CloseFile(pkgFile);

    *bufferSize = static_cast<int>(content.GetSize());
    *buffer = utils::get_clr_value(content.GetData(), size);
}

alt::ILocalStorage* Resource_GetLocalStorage(alt::IResource* resource) {
    return resource->GetLocalStorage();
}

#endif