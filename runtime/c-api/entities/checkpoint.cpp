#include "checkpoint.h"


alt::IColShape* Checkpoint_GetColShape(alt::ICheckpoint* checkpoint) {
    return dynamic_cast<alt::IColShape*>(checkpoint);
}

uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetCheckpointType();
}

void Checkpoint_SetCheckpointType(alt::ICheckpoint* checkpoint, uint8_t type) {
    checkpoint->SetCheckpointType(type);
}

float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetHeight();
}

void Checkpoint_SetHeight(alt::ICheckpoint* checkpoint, float height) {
    checkpoint->SetHeight(height);
}

float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetRadius();
}

void Checkpoint_SetRadius(alt::ICheckpoint* checkpoint, float radius) {
    checkpoint->SetRadius(radius);
}

void Checkpoint_GetColor(alt::ICheckpoint* checkpoint, rgba_t &color) {
    auto checkpointColor = checkpoint->GetColor();
    color.r = checkpointColor.r;
    color.g = checkpointColor.g;
    color.b = checkpointColor.b;
    color.a = checkpointColor.a;
}

void Checkpoint_SetColor(alt::ICheckpoint* checkpoint, rgba_t color) {
    alt::RGBA newColor;
    newColor.r = color.r;
    newColor.g = color.g;
    newColor.b = color.b;
    newColor.a = color.a;
    checkpoint->SetColor(newColor);
}

void Checkpoint_GetNextPosition(alt::ICheckpoint* checkpoint, vector3_t &pos) {
    auto position = checkpoint->GetNextPosition();
    pos.x = position.x;
    pos.y = position.y;
    pos.z = position.z;
}

void Checkpoint_SetNextPosition(alt::ICheckpoint* checkpoint, vector3_t pos) {
    checkpoint->SetNextPosition({ pos.x, pos.y, pos.z });
}