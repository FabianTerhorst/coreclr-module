#include "checkpoint.h"

bool Checkpoint_IsGlobal(alt::ICheckpoint *checkpoint)
{
    return checkpoint->IsGlobal();
}

uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint *checkpoint)
{
    return checkpoint->GetCheckpointType();
}

float Checkpoint_GetHeight(alt::ICheckpoint *checkpoint)
{
    return checkpoint->GetHeight();
}

float Checkpoint_GetRadius(alt::ICheckpoint *checkpoint)
{
    return checkpoint->GetRadius();
}

alt::RGBA Checkpoint_GetColor(alt::ICheckpoint *checkpoint)
{
    return checkpoint->GetColor();
}
