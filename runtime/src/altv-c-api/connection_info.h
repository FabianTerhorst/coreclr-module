#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include <altv-cpp-api/SDK.h>
#include <altv-cpp-api/types/IConnectionInfo.h>

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
EXPORT void ConnectionInfo_Accept(alt::IConnectionInfo* connectionInfo);
EXPORT void ConnectionInfo_Decline(alt::IConnectionInfo* connectionInfo, const char* reason);
EXPORT const char* ConnectionInfo_GetName(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT uint64_t ConnectionInfo_GetSocialId(alt::IConnectionInfo *connectionInfo);
EXPORT uint64_t ConnectionInfo_GetHwIdHash(alt::IConnectionInfo *connectionInfo);
EXPORT uint64_t ConnectionInfo_GetHwIdExHash(alt::IConnectionInfo *connectionInfo);
EXPORT const char* ConnectionInfo_GetAuthToken(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT bool ConnectionInfo_GetIsDebug(alt::IConnectionInfo *connectionInfo);
EXPORT const char* ConnectionInfo_GetBranch(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT uint32_t ConnectionInfo_GetBuild(alt::IConnectionInfo *connectionInfo);
EXPORT const char* ConnectionInfo_GetCdnUrl(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT uint64_t ConnectionInfo_GetPasswordHash(alt::IConnectionInfo *connectionInfo);
EXPORT const char* ConnectionInfo_GetIp(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT const char* ConnectionInfo_GetDiscordUserID(alt::IConnectionInfo *connectionInfo, int32_t& size);
#ifdef __cplusplus
}
#endif
