#include "checkpoint.h"

// Entity

void Checkpoint_GetPosition(alt::ICheckpoint* checkpoint, position_t &position) {
    auto checkpointPosition = checkpoint->GetPosition();
    position.x = checkpointPosition.x;
    position.y = checkpointPosition.y;
    position.z = checkpointPosition.z;
}

void Checkpoint_SetPosition(alt::ICheckpoint* checkpoint, alt::Position pos) {
    checkpoint->SetPosition(pos);
}

int16_t Checkpoint_GetDimension(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetDimension();
}

void Checkpoint_SetDimension(alt::ICheckpoint* checkpoint, uint16_t dimension) {
    checkpoint->SetDimension(dimension);
}

void Checkpoint_GetMetaData(alt::ICheckpoint* checkpoint, const char* key, alt::MValue &val) {
    val = checkpoint->GetMetaData(key);
}

void Checkpoint_SetMetaData(alt::ICheckpoint* checkpoint, const char* key, alt::MValue* val) {
    checkpoint->SetMetaData(key, *val);
}

// Checkpoint

bool Checkpoint_IsGlobal(alt::ICheckpoint* checkpoint) {
    return checkpoint->IsGlobal();
}

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

alt::IPlayer* Checkpoint_GetTarget(alt::ICheckpoint* checkpoint) {
    return checkpoint->GetTarget();
}
