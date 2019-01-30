#include "events.h"

//std::map<alt::CEvent::Type, void *> _callbacks;

void RegisterEventHandler(alt::CEvent::Type type, void *callback)
{
    //_callbacks[type] = callback;
}

void UnregisterEventHandler(alt::CEvent::Type type)
{
    /*auto callback = _callbacks.find(type);
    if (callback == _callbacks.end())
    {
        return;
    }

    _callbacks.erase(callback);*/
}
