#pragma once
#include "../../cpp-sdk/SDK.h"

typedef struct {
    float x;
    float y;
    float z;
} vector3_t;

typedef struct {
    float x;
    float y;
} vector2_t;

typedef struct {
    uint32_t componentsCount;
    uint32_t hash;
    uint8_t tintIndex;
    uint32_t* components;
} weapon_t;

typedef struct {
    float x;
    float y;
    float z;
} position_t;

typedef struct {
    float roll;
    float pitch;
    float yaw;
} rotation_t;

typedef struct {
    uint8_t r;
    uint8_t g;
    uint8_t b;
    uint8_t a;
} rgba_t;