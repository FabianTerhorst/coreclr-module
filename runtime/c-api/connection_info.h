#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../../cpp-sdk/types/IConnectionInfo.h"
#include "utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
    
EXPORT_SERVER void ConnectionInfo_Accept(alt::IConnectionInfo* connectionInfo);
EXPORT_SERVER void ConnectionInfo_Decline(alt::IConnectionInfo* connectionInfo, const char* reason);
EXPORT_SERVER const char* ConnectionInfo_GetName(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT_SERVER uint64_t ConnectionInfo_GetSocialId(alt::IConnectionInfo *connectionInfo);
EXPORT_SERVER uint64_t ConnectionInfo_GetHwIdHash(alt::IConnectionInfo *connectionInfo);
EXPORT_SERVER uint64_t ConnectionInfo_GetHwIdExHash(alt::IConnectionInfo *connectionInfo);
EXPORT_SERVER const char* ConnectionInfo_GetAuthToken(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT_SERVER uint8_t ConnectionInfo_GetIsDebug(alt::IConnectionInfo *connectionInfo);
EXPORT_SERVER const char* ConnectionInfo_GetBranch(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT_SERVER uint32_t ConnectionInfo_GetBuild(alt::IConnectionInfo *connectionInfo);
EXPORT_SERVER const char* ConnectionInfo_GetCdnUrl(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT_SERVER uint64_t ConnectionInfo_GetPasswordHash(alt::IConnectionInfo *connectionInfo);
EXPORT_SERVER const char* ConnectionInfo_GetIp(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT_SERVER const char* ConnectionInfo_GetDiscordUserID(alt::IConnectionInfo *connectionInfo, int32_t& size);
EXPORT_SERVER void ConnectionInfo_AddRef(alt::IConnectionInfo *connectionInfo);
EXPORT_SERVER void ConnectionInfo_RemoveRef(alt::IConnectionInfo *connectionInfo);

#ifdef __cplusplus
}
#endif
