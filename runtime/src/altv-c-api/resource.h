#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include <CSharpResourceImpl.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT void Resource_GetExports(alt::IResource* resource, alt::Array<alt::String> &keys, alt::MValue::List &values);
EXPORT bool Resource_GetExport(alt::IResource* resource, const char* key, alt::MValue &value);
EXPORT void Resource_SetExport(alt::IResource* resource, const char* key, const alt::MValue* val);
EXPORT void Resource_GetPath(alt::IResource* resource, const char*&text);
EXPORT void Resource_GetName(alt::IResource* resource, const char*&text);
EXPORT void Resource_GetMain(alt::IResource* resource, const char*&text);
EXPORT void Resource_GetType(alt::IResource* resource, const char*&text);
EXPORT bool Resource_IsStarted(alt::IResource* resource);
EXPORT void Resource_Start(alt::IResource* resource);
EXPORT void Resource_Stop(alt::IResource* resource);
EXPORT alt::IResource::Impl* Resource_GetImpl(alt::IResource* resource);
EXPORT CSharpResourceImpl* Resource_GetCSharpImpl(alt::IResource* resource);
#ifdef __cplusplus
}
#endif
