#include "altv.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif

using alt::Array;

void FreeUIntArray(alt::Array<uint16_t>* array) {
    array->~Array<uint16_t>();
}

void FreeStringViewArray(alt::Array<alt::StringView>* array) {
    array->~Array<alt::StringView>();
}

void FreeStringArray(alt::Array<alt::String>* array) {
    array->~Array<alt::String>();
}

void FreeMValueArray(alt::Array<alt::MValue>* array) {
    array->~Array<alt::MValue>();
}
