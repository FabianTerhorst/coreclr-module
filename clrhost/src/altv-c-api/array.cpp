#include "array.h"

alt::Array<alt::MValue> MValueArray_Create()
{
    return alt::Array<alt::MValue>();
}

void MValueArray_Push(alt::Array<alt::MValue> arr, const alt::MValue &val)
{
    arr.Push(val);
}
