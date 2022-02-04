#include "connection_info.h"

void ConnectionInfo_Accept(alt::IConnectionInfo *connectionInfo) {
    connectionInfo->Accept();
}

void ConnectionInfo_Decline(alt::IConnectionInfo *connectionInfo, const char* reason) {
    connectionInfo->Decline(reason);
}