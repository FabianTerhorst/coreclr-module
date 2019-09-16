//
// Created by Fabian Terhorst on 2019-02-23.
//

#include "resource.h"

void Resource_GetExports(alt::IResource* resource, alt::Array<alt::String> &keys, alt::MValue::List &values) {
    auto dict = resource->GetExports().Get<alt::MValue::Dict>();
    alt::Array<alt::String> mapKeys;
    alt::MValue::List mapValues;
    for (auto &it : dict) {
        mapKeys.Push(it.first);
        mapValues.Push(it.second);
    }
    keys = mapKeys;
    values = mapValues;
}

bool Resource_GetExport(alt::IResource* resource, const char* key, alt::MValue &value) {
    auto dict = resource->GetExports().Get<alt::MValue::Dict>();
    auto dictValue = dict.find(key);
    std::cout << "try find in size " << std::to_string(dict.size()) << std::endl;
    if (dictValue == dict.end()) {
        std::cout << "not found key" << std::endl;
        return false;
    }
    value = resource->GetExports()[key];//dictValue->second
    return true;
}

void Resource_SetExport(alt::IResource* resource, const char* key, const alt::MValue& val) {
    resource->GetExports()[key] = val;
}

void Resource_SetExports(alt::IResource* resource, alt::MValue* val, const char** keys, int size) {
    alt::MValueDict dict;
    for (int i = 0; i < size; i++) {
        dict[keys[i]] = val[i];
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