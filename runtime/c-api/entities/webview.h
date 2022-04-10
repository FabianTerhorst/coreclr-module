#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../../cpp-sdk/types/IConnectionInfo.h"
#include "../utils/export.h"
#include "../data/types.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_CLIENT alt::IBaseObject* WebView_GetBaseObject(alt::IWebView* webView);
EXPORT_CLIENT uint8_t WebView_IsFocused(alt::IWebView* webView);
EXPORT_CLIENT uint8_t WebView_IsOverlay(alt::IWebView* webView);
EXPORT_CLIENT uint8_t WebView_IsVisible(alt::IWebView* webView);
EXPORT_CLIENT void WebView_SetIsVisible(alt::IWebView* webView, uint8_t visible);
EXPORT_CLIENT void WebView_GetPosition(alt::IWebView* webView, vector2_t& pos);
EXPORT_CLIENT void WebView_SetPosition(alt::IWebView* webView, vector2_t pos);
EXPORT_CLIENT void WebView_GetSize(alt::IWebView* webView, vector2_t& size);
EXPORT_CLIENT void WebView_SetSize(alt::IWebView* webView, vector2_t size);
EXPORT_CLIENT const char* WebView_GetUrl(alt::IWebView* webView, int32_t& size);
EXPORT_CLIENT void WebView_SetUrl(alt::IWebView* webView, const char* url);
EXPORT_CLIENT void WebView_SetExtraHeader(alt::IWebView* webView, const char* key, const char* value);
EXPORT_CLIENT void WebView_SetZoomLevel(alt::IWebView* webView, float value);
EXPORT_CLIENT void WebView_Focus(alt::IWebView* webView);
EXPORT_CLIENT void WebView_Unfocus(alt::IWebView* webView);

#ifdef __cplusplus
}
#endif
