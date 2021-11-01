#pragma once

typedef struct {
    uint32_t hash;
    uint8_t tintIndex;
    std::unordered_set<uint32_t> components;
} weapon_t;