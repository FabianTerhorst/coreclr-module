#include "checkpoint.h"

// Entity

void Checkpoint_GetPosition(alt::ICheckpoint* checkpoint, position_t &position) {
    auto checkpointPosition = checkpoint->GetPosition();
    position.x = checkpointPosition.x;
    position.y = checkpointPosition.y;
    position.z = checkpointPosition.z;
}

void Checkpoint_SetPosition(alt::ICheckpoint* checkpoint, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    checkpoint->SetPosition(position);
}

int32_t Checkpoint_GetDimension(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetDimension();
}

void Checkpoint_SetDimension(alt::ICheckpoint* checkpoint, int32_t dimension) {
    checkpoint->SetDimension(dimension);
}

alt::MValueConst* Checkpoint_GetMetaData(alt::ICheckpoint* checkpoint, const char* key) {
    return new alt::MValueConst(checkpoint->GetMetaData(key));
}

void Checkpoint_SetMetaData(alt::ICheckpoint* checkpoint, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    checkpoint->SetMetaData(key, val->Get()->Clone());
}

void Checkpoint_AddRef(alt::ICheckpoint* checkpoint) {
    checkpoint->AddRef();
}

void Checkpoint_RemoveRef(alt::ICheckpoint* checkpoint) {
    checkpoint->RemoveRef();
}

// Checkpoint

uint8_t Checkpoint_GetCheckpointType(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetCheckpointType();
}

float Checkpoint_GetHeight(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetHeight();
}

float Checkpoint_GetRadius(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetRadius();
}

void Checkpoint_GetColor(alt::ICheckpoint* checkpoint, rgba_t &color) {
    auto checkpointColor = checkpoint->GetColor();
    color.r = checkpointColor.r;
    color.g = checkpointColor.g;
    color.b = checkpointColor.b;
    color.a = checkpointColor.a;
}

bool Checkpoint_IsPlayerIn(alt::ICheckpoint* checkpoint, alt::IPlayer* player) {
    return checkpoint->IsEntityIn(player);
}

bool Checkpoint_IsVehicleIn(alt::ICheckpoint* checkpoint, alt::IVehicle* vehicle) {
    return checkpoint->IsEntityIn(vehicle);
}

uint8_t Checkpoint_GetColShapeType(alt::ICheckpoint* checkpoint) {
    return (uint8_t) checkpoint->GetColshapeType();
}