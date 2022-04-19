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

EXPORT_CLIENT alt::IBaseObject* HttpClient_GetBaseObject(alt::IHttpClient* httpClient);

typedef void (*HttpResponseDelegate_t)(int statusCode, const char* body, const char** headersKeys, const char** valuesKeys, int32_t headersSize);
EXPORT_CLIENT void HttpClient_SetExtraHeader(alt::IHttpClient* httpClient, const char* key, const char* value);
EXPORT_CLIENT void HttpClient_GetExtraHeaders(alt::IHttpClient* httpClient, const char**& keys, const char**& values, int32_t& size);

EXPORT_CLIENT void HttpClient_Get(alt::IHttpClient* httpClient, const char* url, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Head(alt::IHttpClient* httpClient, const char* url, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Connect(alt::IHttpClient* httpClient, const char* url, const char* body, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Delete(alt::IHttpClient* httpClient, const char* url, const char* body, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Options(alt::IHttpClient* httpClient, const char* url, const char* body, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Patch(alt::IHttpClient* httpClient, const char* url, const char* body, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Post(alt::IHttpClient* httpClient, const char* url, const char* body, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Put(alt::IHttpClient* httpClient, const char* url, const char* body, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);
EXPORT_CLIENT void HttpClient_Trace(alt::IHttpClient* httpClient, const char* url, const char* body, /** ClientEvents.HttpResponseModuleDelegate */ HttpResponseDelegate_t callback);

#ifdef __cplusplus
}
#endif
