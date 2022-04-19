//
// Created by fabia on 19.01.2022.
//

#include "strings.h"
#include "../../cpp-sdk/types/Array.h"

const char* AllocateString(const std::string& str, int32_t& size) {
    size_t stringSize = str.size();
    size = (int32_t) stringSize;
    char* writable = new char[stringSize + 1];
    std::copy(str.begin(), str.end(), writable);
    writable[stringSize] = '\0';
    return writable;
}

const char** AllocateStringArray(std::vector<std::string> arr, uint32_t& size) {
    size = arr.size();
    auto out = new const char*[size];
    for (auto i = 0; i < size; i++) {
        auto el = arr[i];
        auto elSize = el.size();
        auto str = el.c_str();
        auto allocStr = new char[elSize + 1];
        for (auto j = 0; j < elSize; j++) allocStr[j] = str[j];
        allocStr[elSize] = '\0';
        out[i] = allocStr;
    }

    return out;
}

const char** AllocateStringArray(alt::Array<std::string> arr, uint32_t& size) {
    size = arr.GetSize();
    auto out = new const char*[size];
    for (auto i = 0; i < size; i++) {
        auto el = arr[i];
        auto elSize = el.size();
        auto str = el.c_str();
        auto allocStr = new char[elSize + 1];
        for (auto j = 0; j < elSize; j++) allocStr[j] = str[j];
        allocStr[elSize] = '\0';
        out[i] = allocStr;
    }

    return out;
}