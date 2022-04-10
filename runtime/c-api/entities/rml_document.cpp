#include "rml_document.h"
#include "../utils/strings.h"

alt::IRmlElement* RmlDocument_GetRmlElement(alt::IRmlDocument* rmlDocument) {
    return dynamic_cast<alt::IRmlElement*>(rmlDocument);
}

#ifdef ALT_CLIENT_API
alt::IRmlElement* RmlDocument_GetBody(alt::IRmlDocument* rmlDocument) {
    return rmlDocument->GetBody().Get();
}

const char* RmlDocument_GetSourceUrl(alt::IRmlDocument* rmlDocument, int32_t& size) {
    return AllocateString(rmlDocument->GetSourceUrl(), size);
}

uint8_t RmlDocument_IsModal(alt::IRmlDocument* rmlDocument) {
    return rmlDocument->IsModal();
}

uint8_t RmlDocument_IsVisible(alt::IRmlDocument* rmlDocument) {
    return rmlDocument->IsVisible();
}

const char* RmlDocument_GetTitle(alt::IRmlDocument* rmlDocument, int32_t& size) {
    return AllocateString(rmlDocument->GetTitle(), size);
}

void RmlDocument_SetTitle(alt::IRmlDocument* rmlDocument, const char* title) {
    rmlDocument->SetTitle(title);
}

alt::IRmlElement* RmlDocument_CreateElement(alt::IRmlDocument* rmlDocument, const char* tag) {
    return rmlDocument->CreateElement(tag).Get();
}

alt::IRmlElement* RmlDocument_CreateTextNode(alt::IRmlDocument* rmlDocument, const char* text) {
    return rmlDocument->CreateTextNode(text).Get();
}

void RmlDocument_Hide(alt::IRmlDocument* rmlDocument) {
    rmlDocument->Hide();
}

void RmlDocument_Show(alt::IRmlDocument* rmlDocument, uint8_t isModal, uint8_t focused) {
    rmlDocument->Show(isModal, focused);
}

void RmlDocument_Update(alt::IRmlDocument* rmlDocument) {
    rmlDocument->Update();
}
#endif