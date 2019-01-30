#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#include <altv-cpp-api/IServer.h>
#include <altv-cpp-api/API.h>
#ifdef __clang__
#pragma clang diagnostic pop
#endif

//#include <c++/8/map>

#ifdef __cplusplus
extern "C"
{
#endif
    EXPORT void RegisterEventHandler(alt::CEvent::Type type, void *callback);
    EXPORT void UnregisterEventHandler(alt::CEvent::Type type);
#ifdef __cplusplus
}
#endif

//extern std::map<alt::CEvent::Type, void *> _callbacks;