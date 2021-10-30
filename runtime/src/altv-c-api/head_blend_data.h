#pragma once

typedef struct {
    uint32_t shapeFirstID;
    uint32_t shapeSecondID;
    uint32_t shapeThirdID;
    uint32_t skinFirstID;
    uint32_t skinSecondID;
    uint32_t skinThirdID;
    float shapeMix;
    float skinMix;
    float thirdMix;
} head_blend_data_t;