#pragma once
#include <string>
#include <combaseapi.h>
#include "../../cpp-sdk/SDK.h"
#include <string>
#include <codecvt>

EXTERN_C IMAGE_DOS_HEADER __ImageBase;

#ifdef _WIN32
#define STR(s) L##s
#else
#define STR(s) s
#endif

namespace utils
{
    inline std::wstring get_current_dll_path()
    {
        wchar_t strDLLPath[MAX_PATH];
        GetModuleFileName((HINSTANCE)&__ImageBase, strDLLPath, MAX_PATH);
        return {strDLLPath, strDLLPath + wcslen(strDLLPath)};
    }

    inline std::wstring string_to_wstring(const std::string& string)
    {
        std::wstring_convert<std::codecvt_utf8_utf16<wchar_t>> converter;
        std::wstring wide = converter.from_bytes(string);
        return wide;
    }

    inline std::string wstring_to_string(const std::wstring& string)
    {
        std::wstring_convert<std::codecvt_utf8_utf16<wchar_t>> converter;
        std::string narrow = converter.to_bytes(string);
        return narrow;
    }

    template<typename T>
    inline T* get_clr_string(const T* str) {
        size_t ulSize = (std::char_traits<T>::length(str) + 1) * sizeof(T);
        T* returnStr;
        returnStr = CoTaskMemAlloc(ulSize);
        std::char_traits<T>::copy(returnStr, str, ulSize);
        return returnStr;
    }


    template <typename T, typename... Args>
    T *get_clr_value(Args &&...args)
    {
        return new (static_cast<T*>(CoTaskMemAlloc(sizeof(T)))) T(std::forward<Args>(args)...);
    }

    template <typename T, typename Traits = std::char_traits<T>>
    T *get_clr_value(const T *str)
    {
        size_t size = (Traits::length(str) + 1) * sizeof(T);
        T *clr_str = static_cast<T *>(CoTaskMemAlloc(size));
        Traits::copy(clr_str, str, size);
        return clr_str;
    }

    template <typename T, typename Traits = std::char_traits<T>>
    T *get_clr_value(const T *str, int len)
    {
        size_t size = len * sizeof(T);
        T *clr_str = static_cast<T *>(CoTaskMemAlloc(size));
        Traits::copy(clr_str, str, size);
        return clr_str;
    }

//    inline wchar_t* get_clr_string(const wchar_t* str) {
//        ULONG ulSize = (wcslen(str) + 1) * sizeof(wchar_t);
//        wchar_t* returnStr;
//        returnStr = (wchar_t*)::CoTaskMemAlloc(ulSize);
//        wcscpy(returnStr, str);
//        return returnStr;
//    }
//
//    inline char* get_clr_string(const char* str) {
//        ULONG ulSize = (strlen(str) + 1) * sizeof(char);
//        char* returnStr;
//        returnStr = (char*)::CoTaskMemAlloc(ulSize);
//        strcpy(returnStr, str);
//        return returnStr;
//    }

    inline bool has_suffix(const std::string &str, const std::string &suffix)
    {
        return str.size() >= suffix.size() &&
               str.compare(str.size() - suffix.size(), suffix.size(), suffix) == 0;
    }
}  // namespace utils