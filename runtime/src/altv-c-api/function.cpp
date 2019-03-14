#include "function.h"

alt::MValue::Function MValueFunction_Create(void* (* fct)()) {
    alt::MValue::Function function = {};
    function.invoker = &fct;//TODO: what kind of function pointer does the api accept.
    return function;
}
