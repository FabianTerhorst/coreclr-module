#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../utils/export.h"
#include "../data/types.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_CLIENT alt::IRmlElement* RmlDocument_GetRmlElement(alt::IRmlDocument* rmlDocument);

EXPORT_CLIENT alt::IRmlElement* RmlDocument_GetBody(alt::IRmlDocument* rmlDocument);
EXPORT_CLIENT const char* RmlDocument_GetSourceUrl(alt::IRmlDocument* rmlDocument, int32_t& size);

EXPORT_CLIENT uint8_t RmlDocument_IsModal(alt::IRmlDocument* rmlDocument);
EXPORT_CLIENT uint8_t RmlDocument_IsVisible(alt::IRmlDocument* rmlDocument);

EXPORT_CLIENT const char* RmlDocument_GetTitle(alt::IRmlDocument* rmlDocument, int32_t& size);
EXPORT_CLIENT void RmlDocument_SetTitle(alt::IRmlDocument* rmlDocument, const char* title);

EXPORT_CLIENT alt::IRmlElement* RmlDocument_CreateElement(alt::IRmlDocument* rmlDocument, const char* tag);
EXPORT_CLIENT alt::IRmlElement* RmlDocument_CreateTextNode(alt::IRmlDocument* rmlDocument, const char* text);

EXPORT_CLIENT void RmlDocument_Hide(alt::IRmlDocument* rmlDocument);
EXPORT_CLIENT void RmlDocument_Show(alt::IRmlDocument* rmlDocument, uint8_t isModal, uint8_t focused);
EXPORT_CLIENT void RmlDocument_Update(alt::IRmlDocument* rmlDocument);


#ifdef __cplusplus
}
#endif
