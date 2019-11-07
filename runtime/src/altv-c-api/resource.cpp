//
// Created by Fabian Terhorst on 2019-02-23.
//

#include "resource.h"

uint64_t Resource_GetExportsCount(alt::IResource* resource) {
    return resource->GetExports()->GetSize();
}

void Resource_GetExports(alt::IResource* resource, const char* keys[],
                         alt::MValueConst* values[]) {
    auto dict = resource->GetExports();
    auto next = dict->Begin();
    uint64_t i = 0;
    do {
        alt::MValueConst mValueElement = next->GetValue();
        keys[i] = next->GetKey().CStr();
        values[i] = &mValueElement;
    } while ((next = dict->Next()) != nullptr);
}

alt::MValueConst* Resource_GetExport(alt::IResource* resource, const char* key) {
    return new alt::Ref(resource->GetExports().Get()->Get(key));
}

void Resource_SetExport(alt::IResource* resource, const char* key, alt::MValue* val) {
    resource->GetExports().Get()->Set(key, *val);
}

void Resource_SetExports(alt::IResource* resource, alt::MValue val[], const char* keys[], int size) {
    alt::MValueDict dict;
    auto dictValue = dict.Get();
    for (int i = 0; i < size; i++) {
        dictValue->Set(keys[i], val[i]);
    }
    resource->SetExports(dict);
}

void Resource_GetPath(alt::IResource* resource, const char*&text) {
    text = resource->GetPath().CStr();
}

void Resource_GetName(alt::IResource* resource, const char*&text) {
    text = resource->GetName().CStr();
}

void Resource_GetMain(alt::IResource* resource, const char*&text) {
    text = resource->GetMain().CStr();
}

void Resource_GetType(alt::IResource* resource, const char*&text) {
    text = resource->GetType().CStr();
}

bool Resource_IsStarted(alt::IResource* resource) {
    return resource->IsStarted();
}

void Resource_Start(alt::IResource* resource) {
    resource->GetImpl()->Start();
}

void Resource_Stop(alt::IResource* resource) {
    resource->GetImpl()->Stop();
}

alt::IResource::Impl* Resource_GetImpl(alt::IResource* resource) {
    return resource->GetImpl();
}

CSharpResourceImpl* Resource_GetCSharpImpl(alt::IResource* resource) {
    return (CSharpResourceImpl*) resource->GetImpl();
}