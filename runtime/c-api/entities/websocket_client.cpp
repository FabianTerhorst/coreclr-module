#include "websocket_client.h"
#include "../utils/strings.h"

#ifdef ALT_CLIENT_API

alt::IBaseObject* WebSocketClient_GetBaseObject(alt::IWebSocketClient* webSocketClient) {
    return dynamic_cast<alt::IBaseObject*>(webSocketClient);
}


uint8_t WebSocketClient_IsAutoReconnect(alt::IWebSocketClient* webSocketClient) {
    return webSocketClient->IsAutoReconnectEnabled();
}

void WebSocketClient_SetAutoReconnect(alt::IWebSocketClient* webSocketClient, uint8_t value) {
    webSocketClient->SetAutoReconnectEnabled(value);
}

uint8_t WebSocketClient_IsPerMessageDeflate(alt::IWebSocketClient* webSocketClient) {
    return webSocketClient->IsPerMessageDeflateEnabled();
}

void WebSocketClient_SetPerMessageDeflate(alt::IWebSocketClient* webSocketClient, uint8_t value) {
    webSocketClient->SetPerMessageDeflateEnabled(value);
}

uint16_t WebSocketClient_GetPingInterval(alt::IWebSocketClient* webSocketClient) {
    return webSocketClient->GetPingInterval();
}

void WebSocketClient_SetPingInterval(alt::IWebSocketClient* webSocketClient, uint16_t value) {
    webSocketClient->SetPingInterval(value);
}

uint8_t WebSocketClient_GetReadyState(alt::IWebSocketClient* webSocketClient, int32_t& size) {
    return webSocketClient->GetReadyState();
}

const char* WebSocketClient_GetUrl(alt::IWebSocketClient* webSocketClient, int32_t& size) {
    return AllocateString(webSocketClient->GetUrl(), size);
}

void WebSocketClient_SetUrl(alt::IWebSocketClient* webSocketClient, const char* value) {
    webSocketClient->SetUrl(value);
}

void WebSocketClient_AddSubProtocol(alt::IWebSocketClient* webSocketClient, const char* protocol) {
    webSocketClient->AddSubProtocol(protocol);
}

const char** WebSocketClient_GetSubProtocols(alt::IWebSocketClient* webSocketClient, uint32_t& size) {
    return AllocateStringArray(webSocketClient->GetSubProtocols(), size);
}

uint8_t WebSocketClient_Send_String(alt::IWebSocketClient* webSocketClient, const char* str) {
    webSocketClient->Send(str);
}

uint8_t WebSocketClient_Send_Binary(alt::IWebSocketClient* webSocketClient, const char* str, uint32_t size) {
    std::string data(str, size);
    webSocketClient->SendBinary(data);
}

void WebSocketClient_SetExtraHeader(alt::IWebSocketClient* webSocketClient, const char* key, const char* value) {
    webSocketClient->SetExtraHeader(key, value);
}

void WebSocketClient_Start(alt::IWebSocketClient* webSocketClient) {
    webSocketClient->Start();
}

void WebSocketClient_Stop(alt::IWebSocketClient* webSocketClient) {
    webSocketClient->Stop();
}
#endif