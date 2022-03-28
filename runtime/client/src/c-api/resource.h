#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
//EXPORT uint64_t Resource_GetExportsCount(alt::IResource* resource);
//EXPORT void Resource_GetExports(alt::IResource* resource, const char* keys[],
//                                alt::MValueConst* values[]);
//EXPORT alt::MValueConst* Resource_GetExport(alt::IResource* resource, const char* key);
//EXPORT int Resource_GetDependenciesSize(alt::IResource* resource);
//EXPORT void Resource_GetDependencies(alt::IResource* resource, const char* dependencies[], int size);
//EXPORT int Resource_GetDependantsSize(alt::IResource* resource);
//EXPORT void Resource_GetDependants(alt::IResource* resource, const char* dependencies[], int size);
//EXPORT void Resource_SetExport(alt::ICore* core, alt::IResource* resource, const char* key, alt::MValueConst* val);
//EXPORT void Resource_SetExports(alt::ICore* core, alt::IResource* resource, alt::MValueConst* val[], const char* keys[], int size);
//EXPORT void Resource_GetPath(alt::IResource* resource, const char*&text);
EXPORT char* Resource_GetName(alt::IResource* resource);
//EXPORT void Resource_GetMain(alt::IResource* resource, const char*&text);
//EXPORT void Resource_GetType(alt::IResource* resource, const char*&text);
//EXPORT uint8_t Resource_IsStarted(alt::IResource* resource);
//EXPORT void Resource_Start(alt::IResource* resource);
//EXPORT void Resource_Stop(alt::IResource* resource);
EXPORT void Resource_GetFile(alt::IResource* resource, const char* path, int* bufferSize, void** buffer);
EXPORT bool Resource_FileExists(alt::IResource* resource, const char* path);
//EXPORT alt::IResource::Impl* Resource_GetImpl(alt::IResource* resource);
//EXPORT CSharpResourceImpl* Resource_GetCSharpImpl(alt::IResource* resource);
#ifdef __cplusplus
}
#endif