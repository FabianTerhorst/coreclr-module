#pragma once
#include "../../../cpp-sdk/SDK.h"
#include "../runtime/CSharpResourceImpl.h"

extern "C"
{
    EXPORT char* Resource_GetName(alt::IResource* resource);
    EXPORT void Resource_GetFile(alt::IResource* resource, const char* path, int* bufferSize, void** buffer);
    EXPORT bool Resource_FileExists(alt::IResource* resource, const char* path);
    EXPORT CSharpResourceImpl* Resource_GetCSharpImpl(alt::IResource* resource);
}