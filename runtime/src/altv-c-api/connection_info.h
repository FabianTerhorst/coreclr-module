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
#ifdef __cplusplus
}
#endif
