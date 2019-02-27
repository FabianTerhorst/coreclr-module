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
    if(dictValue == dict.end()) {
        return false;
    }
    value = dictValue->second;
    return true;
}