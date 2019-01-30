#include "eventcallbacks.h"

bool OnPlayerConnect(const alt::CEvent *event)
{
    executeCallback(alt::CEvent::PLAYER_CONNECT, ((alt::CPlayerConnectEvent*)event)->GetTarget());
    return true;
}

void init()
{
    //alt::IServer::Instance().SubscribeEvent(alt::CEvent::PLAYER_CONNECT, OnPlayerConnect);
}
