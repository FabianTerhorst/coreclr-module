#include "webview.h"
#include "../utils/strings.h"

#ifdef ALT_CLIENT_API
alt::IBaseObject* WebView_GetBaseObject(alt::IWebView* webview) {
    return dynamic_cast<alt::IBaseObject*>(webview);
}

uint8_t WebView_IsFocused(alt::IWebView* webview) {
    return webview->IsFocused();
}

uint8_t WebView_IsOverlay(alt::IWebView* webview) {
    return webview->IsOverlay();
}

uint8_t WebView_IsVisible(alt::IWebView* webview) {
    return webview->IsVisible();
}

void WebView_SetIsVisible(alt::IWebView* webview, uint8_t visible) {
    webview->SetVisible(visible);
}

void WebView_GetPosition(alt::IWebView* webview, vector2_t& pos) {
    auto position = webview->GetPosition();
    pos.x = position[0];
    pos.y = position[1];
}

void WebView_SetPosition(alt::IWebView* webview, vector2_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    webview->SetPosition(position);
}

void WebView_GetSize(alt::IWebView* webview, vector2_t& size) {
    auto webviewSize = webview->GetSize();
    size.x = webviewSize[0];
    size.y = webviewSize[1];
}

void WebView_SetSize(alt::IWebView* webview, vector2_t size) {
    alt::Position position;
    position.x = size.x;
    position.y = size.y;
    webview->SetSize(position);
}

const char* WebView_GetUrl(alt::IWebView* webview, int32_t& size) {
    return AllocateString(webview->GetUrl(), size);
}

void WebView_SetUrl(alt::IWebView* webview, const char* url) {
    webview->SetUrl(url);
}

void WebView_SetExtraHeader(alt::IWebView* webview, const char* key, const char* value) {
    webview->SetExtraHeader(key, value);
}

void WebView_SetZoomLevel(alt::IWebView* webview, float value) {
    webview->SetZoomLevel(value);
}

void WebView_Focus(alt::IWebView* webview) {
    webview->Focus();
}

void WebView_Unfocus(alt::IWebView* webview) {
    webview->Unfocus();
}
#endif