#pragma once
#include "altv-cpp-api/ICore.h"

typedef void (* TickDelegate_t)();
typedef void (* ServerEventDelegate_t)(const char* name, alt::MValueConst** args, uint64_t size);