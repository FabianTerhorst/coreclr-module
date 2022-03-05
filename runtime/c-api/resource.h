#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "utils/export.h"

#if ALT_SERVER_API
#include <CSharpResourceImpl.h>
#endif

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED void Resource_GetName(alt::IResource* resource, const char*&text);
    
EXPORT_SERVER uint64_t Resource_GetExportsCount(alt::IResource* resource);
EXPORT_SERVER void Resource_GetExports(alt::IResource* resource, const char* keys[], alt::MValueConst* values[]);
EXPORT_SERVER alt::MValueConst* Resource_GetExport(alt::IResource* resource, const char* key);
EXPORT_SERVER int Resource_GetDependenciesSize(alt::IResource* resource);
EXPORT_SERVER void Resource_GetDependencies(alt::IResource* resource, const char* dependencies[], int size);
EXPORT_SERVER int Resource_GetDependantsSize(alt::IResource* resource);
EXPORT_SERVER void Resource_GetDependants(alt::IResource* resource, const char* dependencies[], int size);
EXPORT_SERVER void Resource_SetExport(alt::ICore* core, alt::IResource* resource, const char* key, alt::MValueConst* val);
EXPORT_SERVER void Resource_SetExports(alt::ICore* core, alt::IResource* resource, alt::MValueConst* val[], const char* keys[], int size);
EXPORT_SERVER void Resource_GetPath(alt::IResource* resource, const char*&text);
EXPORT_SERVER void Resource_GetMain(alt::IResource* resource, const char*&text);
EXPORT_SERVER void Resource_GetType(alt::IResource* resource, const char*&text);
EXPORT_SERVER uint8_t Resource_IsStarted(alt::IResource* resource);
EXPORT_SERVER alt::IResource::Impl* Resource_GetImpl(alt::IResource* resource);
EXPORT_SERVER void Resource_Start(alt::IResource* resource);
EXPORT_SERVER void Resource_Stop(alt::IResource* resource);

#ifdef ALT_SERVER_API
EXPORT_SERVER CSharpResourceImpl* Resource_GetCSharpImpl(alt::IResource* resource);
#endif

#ifdef __cplusplus
}
#endif
