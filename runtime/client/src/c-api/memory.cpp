#include "memory.h"

void FreeUIntArray(alt::Array<uint32_t>* array) {
    array->~Array<uint32_t>();
}

void FreeCharArray(char charArray[]) {
    delete[] charArray;
}

void FreeString(const char* string) {
    delete[] string;
}