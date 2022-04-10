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

EXPORT_CLIENT NO_GC alt::IBaseObject* RmlElement_GetBaseObject(alt::IRmlElement* rmlElement);

EXPORT_CLIENT NO_GC float RmlElement_GetAbsoluteLeft(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetAbsoluteTop(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC void RmlElement_GetAbsoluteOffset(alt::IRmlElement* rmlElement, vector2_t& offset);
EXPORT_CLIENT NO_GC void RmlElement_GetRelativeOffset(alt::IRmlElement* rmlElement, vector2_t& offset);
EXPORT_CLIENT NO_GC float RmlElement_GetBaseline(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC uint32_t RmlElement_GetChildCount(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC void RmlElement_GetChildNodes(alt::IRmlElement* rmlElement, alt::IRmlElement**& arr, uint32_t& size);
EXPORT_CLIENT NO_GC float RmlElement_GetClientTop(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetClientLeft(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetClientWidth(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetClientHeight(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC void RmlElement_GetContainingBlock(alt::IRmlElement* rmlElement, vector2_t& containingBlock);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetFirstChild(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetFocusedElement(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC uint8_t RmlElement_HasChildren(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC const char* RmlElement_GetId(alt::IRmlElement* rmlElement, int32_t& size);
EXPORT_CLIENT NO_GC void RmlElement_SetId(alt::IRmlElement* rmlElement, const char* value);
EXPORT_CLIENT NO_GC const char* RmlElement_GetInnerRml(alt::IRmlElement* rmlElement, int32_t& size);
EXPORT_CLIENT void RmlElement_SetInnerRml(alt::IRmlElement* rmlElement, const char* value);
EXPORT_CLIENT NO_GC uint8_t RmlElement_IsOwned(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC uint8_t RmlElement_IsVisible(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetLastChild(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetNextSibling(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetPreviousSibling(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetOffsetTop(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetOffsetLeft(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetOffsetWidth(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetOffsetHeight(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC alt::IRmlDocument* RmlElement_GetOwnerDocument(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetParent(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetScrollHeight(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetScrollWidth(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC float RmlElement_GetScrollLeft(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC void RmlElement_SetScrollLeft(alt::IRmlElement* rmlElement, float value);
EXPORT_CLIENT NO_GC float RmlElement_GetScrollTop(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC void RmlElement_SetScrollTop(alt::IRmlElement* rmlElement, float value);
EXPORT_CLIENT NO_GC const char* RmlElement_GetTagName(alt::IRmlElement* rmlElement, int32_t& size);
EXPORT_CLIENT NO_GC float RmlElement_GetZIndex(alt::IRmlElement* rmlElement);

EXPORT_CLIENT NO_GC void RmlElement_AddClass(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT NO_GC void RmlElement_AddPseudoClass(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT void RmlElement_AppendChild(alt::IRmlElement* rmlElement, alt::IRmlElement* child);
EXPORT_CLIENT NO_GC void RmlElement_Blur(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC void RmlElement_Click(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetClosest(alt::IRmlElement* rmlElement, const char* selectors);
EXPORT_CLIENT NO_GC void RmlElement_Focus(alt::IRmlElement* rmlElement);
EXPORT_CLIENT NO_GC const char* RmlElement_GetAttribute(alt::IRmlElement* rmlElement, const char* name, int32_t& size);
EXPORT_CLIENT NO_GC void RmlElement_GetAttributes(alt::IRmlElement* rmlElement, const char**& keys, const char**& values, uint32_t& size);
EXPORT_CLIENT NO_GC void RmlElement_GetClassList(alt::IRmlElement* rmlElement, const char**& classes, uint32_t& size);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_GetElementById(alt::IRmlElement* rmlElement, const char* id);
EXPORT_CLIENT NO_GC void RmlElement_GetElementsByClassName(alt::IRmlElement* rmlElement, const char* className, alt::IRmlElement**& arr, uint32_t& size);
EXPORT_CLIENT NO_GC void RmlElement_GetElementsByTagName(alt::IRmlElement* rmlElement, const char* tagName, alt::IRmlElement**& arr, uint32_t& size);
EXPORT_CLIENT NO_GC const char* RmlElement_GetLocalProperty(alt::IRmlElement* rmlElement, const char* name, int32_t& size);
EXPORT_CLIENT NO_GC const char* RmlElement_GetProperty(alt::IRmlElement* rmlElement, const char* name, int32_t& size);
EXPORT_CLIENT NO_GC float RmlElement_GetPropertyAbsoluteValue(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT NO_GC void RmlElement_GetPseudoClassList(alt::IRmlElement* rmlElement, const char**& classes, uint32_t& size);
EXPORT_CLIENT NO_GC uint8_t RmlElement_HasAttribute(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT NO_GC uint8_t RmlElement_HasClass(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT NO_GC uint8_t RmlElement_HasLocalProperty(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT NO_GC uint8_t RmlElement_HasProperty(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT NO_GC uint8_t RmlElement_HasPseudoClass(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT void RmlElement_InsertBefore(alt::IRmlElement* rmlElement, alt::IRmlElement* child, alt::IRmlElement* adjacent);
EXPORT_CLIENT NO_GC uint8_t RmlElement_IsPointWithinElement(alt::IRmlElement* rmlElement, vector2_t point);
EXPORT_CLIENT NO_GC alt::IRmlElement* RmlElement_QuerySelector(alt::IRmlElement* rmlElement, const char* selector);
EXPORT_CLIENT NO_GC void RmlElement_QuerySelectorAll(alt::IRmlElement* rmlElement, const char* selector, alt::IRmlElement**& arr, uint32_t& size);

EXPORT_CLIENT NO_GC uint8_t RmlElement_RemoveAttribute(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT void RmlElement_RemoveChild(alt::IRmlElement* rmlElement, alt::IRmlElement* child);
EXPORT_CLIENT NO_GC uint8_t RmlElement_RemoveClass(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT uint8_t RmlElement_RemoveProperty(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT NO_GC uint8_t RmlElement_RemovePseudoClass(alt::IRmlElement* rmlElement, const char* name);
EXPORT_CLIENT void RmlElement_ReplaceChild(alt::IRmlElement* rmlElement, alt::IRmlElement* newElem, alt::IRmlElement* oldElem);
EXPORT_CLIENT NO_GC void RmlElement_ScrollIntoView(alt::IRmlElement* rmlElement, uint8_t alignToTop);
EXPORT_CLIENT NO_GC void RmlElement_SetAttribute(alt::IRmlElement* rmlElement, const char* name, const char* value);
EXPORT_CLIENT NO_GC void RmlElement_SetOffset(alt::IRmlElement* rmlElement, alt::IRmlElement* element, vector2_t offset, uint8_t fixed);
EXPORT_CLIENT void RmlElement_SetProperty(alt::IRmlElement* rmlElement, const char* name, const char* value);


#ifdef __cplusplus
}
#endif
