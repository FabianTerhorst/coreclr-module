#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "data/types.h"
#include "utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif
    
EXPORT_SERVER void Event_Cancel(alt::CEvent* event);
EXPORT_SERVER void Event_PlayerBeforeConnect_Cancel(alt::CEvent* event, const char* reason);
EXPORT_SERVER uint8_t Event_WasCancelled(alt::CEvent* event);

#ifdef __cplusplus
}
#endif
