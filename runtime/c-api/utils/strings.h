#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <string>
#include <vector>

const char* AllocateString(const std::string& str, int32_t& size);
const char** AllocateStringArray(const char* arr[], uint32_t& size);
const char** AllocateStringArray(std::vector<std::string> arr, uint32_t& size);