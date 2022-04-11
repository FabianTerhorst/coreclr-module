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

EXPORT_CLIENT alt::IBaseObject* WebSocketClient_GetBaseObject(alt::IWebSocketClient* webSocketClient);

EXPORT_CLIENT uint8_t WebSocketClient_IsAutoReconnect(alt::IWebSocketClient* webSocketClient);
EXPORT_CLIENT void WebSocketClient_SetAutoReconnect(alt::IWebSocketClient* webSocketClient, uint8_t value);
EXPORT_CLIENT uint8_t WebSocketClient_IsPerMessageDeflate(alt::IWebSocketClient* webSocketClient);
EXPORT_CLIENT void WebSocketClient_SetPerMessageDeflate(alt::IWebSocketClient* webSocketClient, uint8_t value);
EXPORT_CLIENT uint16_t WebSocketClient_GetPingInterval(alt::IWebSocketClient* webSocketClient);
EXPORT_CLIENT void WebSocketClient_SetPingInterval(alt::IWebSocketClient* webSocketClient, uint16_t value);
EXPORT_CLIENT uint8_t WebSocketClient_GetReadyState(alt::IWebSocketClient* webSocketClient, int32_t& size);
EXPORT_CLIENT const char* WebSocketClient_GetUrl(alt::IWebSocketClient* webSocketClient, int32_t& size);
EXPORT_CLIENT void WebSocketClient_SetUrl(alt::IWebSocketClient* webSocketClient, const char* value);

EXPORT_CLIENT void WebSocketClient_AddSubProtocol(alt::IWebSocketClient* webSocketClient, const char* protocol);
EXPORT_CLIENT const char** WebSocketClient_GetSubProtocols(alt::IWebSocketClient* webSocketClient, uint32_t& size);
EXPORT_CLIENT uint8_t WebSocketClient_Send_String(alt::IWebSocketClient* webSocketClient, const char* str);
EXPORT_CLIENT uint8_t WebSocketClient_Send_Binary(alt::IWebSocketClient* webSocketClient, const char* str, uint32_t size);
EXPORT_CLIENT void WebSocketClient_SetExtraHeader(alt::IWebSocketClient* webSocketClient, const char* key, const char* value);
EXPORT_CLIENT void WebSocketClient_Start(alt::IWebSocketClient* webSocketClient);
EXPORT_CLIENT void WebSocketClient_Stop(alt::IWebSocketClient* webSocketClient);

#ifdef __cplusplus
}
#endif
