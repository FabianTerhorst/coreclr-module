#include "mvalue.h"

alt::MValue MValue_CreateNil()
{
    return alt::MValue();
}

alt::MValue MValue_CreateBool(const bool &val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateInt(const int32_t &val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateUInt(const uint32_t &val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateDouble(const double &val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateString(const char *val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateList(const alt::Array<alt::MValue> &val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateDict(const std::unordered_map<alt::String, alt::MValue> &val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateEntity(const alt::MValue::Entity &val)
{
    return alt::MValue(val);
}

alt::MValue MValue_CreateFunction(const alt::MValue::Function &val)
{
    return alt::MValue(val);
}
