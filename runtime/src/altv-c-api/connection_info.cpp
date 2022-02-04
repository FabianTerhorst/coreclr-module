#include "connection_info.h"
#include "strings.h"

void ConnectionInfo_Accept(alt::IConnectionInfo *connectionInfo) {
    connectionInfo->Accept();
}

void ConnectionInfo_Decline(alt::IConnectionInfo *connectionInfo, const char* reason) {
    connectionInfo->Decline(reason);
}

const char* ConnectionInfo_GetName(alt::IConnectionInfo *connectionInfo, int32_t& size) {
    return AllocateString(connectionInfo->GetName(), size);
}

uint64_t ConnectionInfo_GetSocialId(alt::IConnectionInfo *connectionInfo) {
    return connectionInfo->GetSocialId();
}

uint64_t ConnectionInfo_GetHwIdHash(alt::IConnectionInfo *connectionInfo) {
    return connectionInfo->GetHwIdHash();
}

uint64_t ConnectionInfo_GetHwIdExHash(alt::IConnectionInfo *connectionInfo) {
    return connectionInfo->GetHwIdExHash();
}

const char* ConnectionInfo_GetAuthToken(alt::IConnectionInfo *connectionInfo, int32_t& size) {
    return AllocateString(connectionInfo->GetAuthToken(), size);
}

bool ConnectionInfo_GetIsDebug(alt::IConnectionInfo *connectionInfo) {
    return connectionInfo->GetIsDebug();
}

const char* ConnectionInfo_GetBranch(alt::IConnectionInfo *connectionInfo, int32_t& size) {
    return AllocateString(connectionInfo->GetBranch(), size);
}

uint32_t ConnectionInfo_GetBuild(alt::IConnectionInfo *connectionInfo) {
    return connectionInfo->GetBuild();
}

const char* ConnectionInfo_GetCdnUrl(alt::IConnectionInfo *connectionInfo, int32_t& size) {
    return AllocateString(connectionInfo->GetCdnUrl(), size);
}

uint64_t ConnectionInfo_GetPasswordHash(alt::IConnectionInfo *connectionInfo) {
    return connectionInfo->GetPasswordHash();
}

const char* ConnectionInfo_GetIp(alt::IConnectionInfo *connectionInfo, int32_t& size) {
    return AllocateString(connectionInfo->GetIp(), size);
}

const char* ConnectionInfo_GetDiscordUserID(alt::IConnectionInfo *connectionInfo, int32_t& size) {
    return AllocateString(connectionInfo->GetDiscordUserID(), size);
}

void ConnectionInfo_AddRef(alt::IConnectionInfo *connectionInfo) {
    connectionInfo->AddRef();
}

void ConnectionInfo_RemoveRef(alt::IConnectionInfo *connectionInfo) {
    connectionInfo->RemoveRef();
}