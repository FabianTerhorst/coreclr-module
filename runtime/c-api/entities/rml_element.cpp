#include "rml_element.h"
#include "../utils/strings.h"

#ifdef ALT_CLIENT_API
alt::IBaseObject* RmlElement_GetBaseObject(alt::IRmlElement *rmlElement) {
    return dynamic_cast<alt::IBaseObject*>(rmlElement);
}


float RmlElement_GetAbsoluteLeft(alt::IRmlElement* rmlElement) {
    return rmlElement->GetAbsoluteLeft();
}

float RmlElement_GetAbsoluteTop(alt::IRmlElement* rmlElement) {
    return rmlElement->GetAbsoluteTop();
}

void RmlElement_GetAbsoluteOffset(alt::IRmlElement* rmlElement, vector2_t& offset) {
    auto vector = rmlElement->GetAbsoluteOffset();
    offset.x = vector[0];
    offset.y = vector[1];
}

void RmlElement_GetRelativeOffset(alt::IRmlElement* rmlElement, vector2_t& offset) {
    auto vector = rmlElement->GetRelativeOffset();
    offset.x = vector[0];
    offset.y = vector[1];
}

float RmlElement_GetBaseline(alt::IRmlElement* rmlElement) {
    return rmlElement->GetBaseline();
}

uint32_t RmlElement_GetChildCount(alt::IRmlElement* rmlElement) {
    return rmlElement->GetChildCount();
}

void RmlElement_GetChildNodes(alt::IRmlElement* rmlElement, alt::IRmlElement**& arr, uint32_t& size) {
    size = rmlElement->GetChildCount();
    arr = new alt::IRmlElement*[size];

    for(int32_t i = 0; i < size; i++)
    {
        arr[i] = rmlElement->GetChild(i).Get();
    }
}

float RmlElement_GetClientTop(alt::IRmlElement* rmlElement) {
    return rmlElement->GetClientTop();
}

float RmlElement_GetClientLeft(alt::IRmlElement* rmlElement) {
    return rmlElement->GetClientLeft();
}

float RmlElement_GetClientWidth(alt::IRmlElement* rmlElement) {
    return rmlElement->GetClientWidth();
}

float RmlElement_GetClientHeight(alt::IRmlElement* rmlElement) {
    return rmlElement->GetClientHeight();
}

void RmlElement_GetContainingBlock(alt::IRmlElement* rmlElement, vector2_t& containingBlock) {
    auto vector = rmlElement->GetContainingBlock();
    containingBlock.x = vector[0];
    containingBlock.y = vector[1];
}

alt::IRmlElement* RmlElement_GetFirstChild(alt::IRmlElement* rmlElement) {
    return rmlElement->GetFirstChild().Get();
}

alt::IRmlElement* RmlElement_GetFocusedElement(alt::IRmlElement* rmlElement) {
    return rmlElement->GetFocusedElement().Get();
}

uint8_t RmlElement_HasChildren(alt::IRmlElement* rmlElement) {
    return rmlElement->HasChildren();
}

const char* RmlElement_GetId(alt::IRmlElement* rmlElement, int32_t& size) {
    return AllocateString(rmlElement->GetID(), size);
}

void RmlElement_SetId(alt::IRmlElement* rmlElement, const char* value) {
    rmlElement->SetID(value);
}

const char* RmlElement_GetInnerRml(alt::IRmlElement* rmlElement, int32_t& size) {
    return AllocateString(rmlElement->GetInnerRML(), size);
}

void RmlElement_SetInnerRml(alt::IRmlElement* rmlElement, const char* value) {
    rmlElement->SetInnerRML(value);
}

uint8_t RmlElement_IsOwned(alt::IRmlElement* rmlElement) {
    return rmlElement->IsOwned();
}

uint8_t RmlElement_IsVisible(alt::IRmlElement* rmlElement) {
    return rmlElement->IsVisible();
}

alt::IRmlElement* RmlElement_GetLastChild(alt::IRmlElement* rmlElement) {
    return rmlElement->GetLastChild().Get();
}

alt::IRmlElement* RmlElement_GetNextSibling(alt::IRmlElement* rmlElement) {
    return rmlElement->GetNextSibling().Get();
}

alt::IRmlElement* RmlElement_GetPreviousSibling(alt::IRmlElement* rmlElement) {
    return rmlElement->GetPreviousSibling().Get();
}

float RmlElement_GetOffsetTop(alt::IRmlElement* rmlElement) {
    return rmlElement->GetOffsetTop();
}

float RmlElement_GetOffsetLeft(alt::IRmlElement* rmlElement) {
    return rmlElement->GetOffsetLeft();
}

float RmlElement_GetOffsetWidth(alt::IRmlElement* rmlElement) {
    return rmlElement->GetOffsetWidth();
}

float RmlElement_GetOffsetHeight(alt::IRmlElement* rmlElement) {
    return rmlElement->GetOffsetHeight();
}

alt::IRmlDocument* RmlElement_GetOwnerDocument(alt::IRmlElement* rmlElement) {
    return rmlElement->GetOwnerDocument().Get();
}

alt::IRmlElement* RmlElement_GetParent(alt::IRmlElement* rmlElement) {
    return rmlElement->GetParent().Get();
}

float RmlElement_GetScrollHeight(alt::IRmlElement* rmlElement) {
    return rmlElement->GetScrollHeight();
}

float RmlElement_GetScrollWidth(alt::IRmlElement* rmlElement) {
    return rmlElement->GetScrollWidth();
}

float RmlElement_GetScrollLeft(alt::IRmlElement* rmlElement) {
    return rmlElement->GetScrollLeft();
}

void RmlElement_SetScrollLeft(alt::IRmlElement* rmlElement, float value) {
    rmlElement->SetScrollLeft(value);
}

float RmlElement_GetScrollTop(alt::IRmlElement* rmlElement) {
    return rmlElement->GetScrollTop();
}

void RmlElement_SetScrollTop(alt::IRmlElement* rmlElement, float value) {
    rmlElement->SetScrollTop(value);
}

const char* RmlElement_GetTagName(alt::IRmlElement* rmlElement, int32_t& size) {
    return AllocateString(rmlElement->GetTagName(), size);
}

float RmlElement_GetZIndex(alt::IRmlElement* rmlElement) {
    return rmlElement->GetZIndex();
}

void RmlElement_AddClass(alt::IRmlElement* rmlElement, const char* name) {
    rmlElement->AddClass(name);
}

void RmlElement_AddPseudoClass(alt::IRmlElement* rmlElement, const char* name) {
    rmlElement->AddPseudoClass(name);
}

void RmlElement_AppendChild(alt::IRmlElement* rmlElement, alt::IRmlElement* child) {
    rmlElement->AppendChild(child);
}

void RmlElement_Blur(alt::IRmlElement* rmlElement) {
    rmlElement->Blur();
}

void RmlElement_Click(alt::IRmlElement* rmlElement) {
    rmlElement->Click();
}

alt::IRmlElement* RmlElement_GetClosest(alt::IRmlElement* rmlElement, const char* selectors) {
    return rmlElement->GetClosest(selectors).Get();
}

void RmlElement_Focus(alt::IRmlElement* rmlElement) {
    rmlElement->Focus();
}

const char* RmlElement_GetAttribute(alt::IRmlElement* rmlElement, const char* name, int32_t& size) {
    return AllocateString(rmlElement->GetAttribute(name), size);
}

void RmlElement_GetAttributes(alt::IRmlElement* rmlElement, const char**& keys, const char**& values, uint32_t& size) {
    auto map = rmlElement->GetAttributes();
    size = map.size();
    keys = new const char*[size];
    values = new const char*[size];
    auto i = 0;
    for(auto const& el : map) {
        auto keyStr = el.first.c_str();
        auto keySize = el.first.size();
        auto allocKey = new char[keySize + 1];
        for (auto j = 0; j < keySize; j++) allocKey[j] = keyStr[j];
        allocKey[keySize] = '\0';
        keys[i] = allocKey;

        auto valueStr = el.second.c_str();
        auto valueSize = el.second.size();
        auto allocValue = new char[valueSize + 1];
        for (auto j = 0; j < valueSize; j++) allocValue[j] = valueStr[j];
        allocValue[valueSize] = '\0';
        values[i] = allocValue;
        i++;
    }
}

void RmlElement_GetClassList(alt::IRmlElement* rmlElement, const char**& classes, uint32_t& size) {
    auto arr = rmlElement->GetClassList();
    classes = AllocateStringArray(arr, size);
}

alt::IRmlElement* RmlElement_GetElementById(alt::IRmlElement* rmlElement, const char* id) {
    return rmlElement->GetElementByID(id).Get();
}

void RmlElement_GetElementsByClassName(alt::IRmlElement* rmlElement, const char* className, alt::IRmlElement**& arr, uint32_t& size) {
    auto elements = rmlElement->GetElementsByClassName(className);
    size = elements.size();
    arr = new alt::IRmlElement*[size];
    for (auto i = 0; i < size; i++) arr[i] = elements[i].Get();
}

void RmlElement_GetElementsByTagName(alt::IRmlElement* rmlElement, const char* tagName, alt::IRmlElement**& arr, uint32_t& size) {
    auto elements = rmlElement->GetElementsByTagName(tagName);
    size = elements.size();
    arr = new alt::IRmlElement*[size];
    for (auto i = 0; i < size; i++) arr[i] = elements[i].Get();
}

const char* RmlElement_GetLocalProperty(alt::IRmlElement* rmlElement, const char* name, int32_t& size) {
    return AllocateString(rmlElement->GetLocalProperty(name), size);
}

const char* RmlElement_GetProperty(alt::IRmlElement* rmlElement, const char* name, int32_t& size) {
    return AllocateString(rmlElement->GetProperty(name), size);
}

float RmlElement_GetPropertyAbsoluteValue(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->GetPropertyAbsoluteValue(name);
}

void RmlElement_GetPseudoClassList(alt::IRmlElement* rmlElement, const char**& classes, uint32_t& size) {
    auto arr = rmlElement->GetPseudoClassList();
    classes = AllocateStringArray(arr, size);
}

uint8_t RmlElement_HasAttribute(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->HasAttribute(name);
}

uint8_t RmlElement_HasClass(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->HasClass(name);
}

uint8_t RmlElement_HasLocalProperty(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->HasLocalProperty(name);
}

uint8_t RmlElement_HasProperty(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->HasProperty(name);
}

uint8_t RmlElement_HasPseudoClass(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->HasPseudoClass(name);
}

void RmlElement_InsertBefore(alt::IRmlElement* rmlElement, alt::IRmlElement* child, alt::IRmlElement* adjacent) {
    rmlElement->InsertBefore(child, adjacent);
}

uint8_t RmlElement_IsPointWithinElement(alt::IRmlElement* rmlElement, vector2_t point) {
    return rmlElement->IsPointWithinElement({ point.x, point.y });
}

alt::IRmlElement* RmlElement_QuerySelector(alt::IRmlElement* rmlElement, const char* selector) {
    return rmlElement->QuerySelector(selector).Get();
}

void RmlElement_QuerySelectorAll(alt::IRmlElement* rmlElement, const char* selector, alt::IRmlElement**& arr, uint32_t& size) {
    auto elements = rmlElement->QuerySelectorAll(selector);
    size = elements.size();
    arr = new alt::IRmlElement*[size];
    for (auto i = 0; i < size; i++) arr[i] = elements[i].Get();
}

uint8_t RmlElement_RemoveAttribute(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->RemoveAttribute(name);
}

void RmlElement_RemoveChild(alt::IRmlElement* rmlElement, alt::IRmlElement* child) {
    rmlElement->RemoveChild(child);
}

uint8_t RmlElement_RemoveClass(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->RemoveClass(name);
}

uint8_t RmlElement_RemoveProperty(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->RemoveProperty(name);
}

uint8_t RmlElement_RemovePseudoClass(alt::IRmlElement* rmlElement, const char* name) {
    return rmlElement->RemovePseudoClass(name);
}

void RmlElement_ReplaceChild(alt::IRmlElement* rmlElement, alt::IRmlElement* newElem, alt::IRmlElement* oldElem) {
    rmlElement->ReplaceChild(newElem, oldElem);
}

void RmlElement_ScrollIntoView(alt::IRmlElement* rmlElement, uint8_t alignToTop) {
    rmlElement->ScrollIntoView(alignToTop);
}

void RmlElement_SetAttribute(alt::IRmlElement* rmlElement, const char* name, const char* value) {
    rmlElement->SetAttribute(name, value);
}

void RmlElement_SetOffset(alt::IRmlElement* rmlElement, alt::IRmlElement* element, vector2_t offset, uint8_t fixed) {
    rmlElement->SetOffset(element, { offset.x, offset.y }, fixed);
}

void RmlElement_SetProperty(alt::IRmlElement* rmlElement, const char* name, const char* value) {
    rmlElement->SetProperty(name, value);
}

#endif