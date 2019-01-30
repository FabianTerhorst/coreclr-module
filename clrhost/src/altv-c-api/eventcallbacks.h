#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/IServer.h>
#ifdef __clang__
#pragma clang diagnostic pop
#endif

#include "events.h"

void init();

template <class... Types>
void executeCallback(alt::CEvent::Type type, Types... args)
{
    /*auto callback = _callbacks.find(type);
    if (callback == _callbacks.end() || callback->second == 0)
    {
        return;
    }

    typedef void(Callback)(Types...);

    ((Callback *)callback->second)(args...);*/
}
