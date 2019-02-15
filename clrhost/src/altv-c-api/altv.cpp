#include "altv.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif

void FreeObject(void* pointer) {
    delete pointer;
}

void FreeArray(void* array) {
    delete[] array;
}
