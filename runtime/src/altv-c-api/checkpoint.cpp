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

uint8_t Checkpoint_HasMetaData(alt::ICheckpoint* checkpoint, const char* key) {
    return checkpoint->HasMetaData(key);
}

void Checkpoint_DeleteMetaData(alt::ICheckpoint* checkpoint, const char* key) {
    checkpoint->DeleteMetaData(key);
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

uint8_t Checkpoint_IsPlayerIn(alt::ICheckpoint* checkpoint, alt::IPlayer* player) {
    return checkpoint->IsEntityIn(player);
}

uint8_t Checkpoint_IsVehicleIn(alt::ICheckpoint* checkpoint, alt::IVehicle* vehicle) {
    return checkpoint->IsEntityIn(vehicle);
}

uint8_t Checkpoint_GetColShapeType(alt::ICheckpoint* checkpoint) {
    return (uint8_t) checkpoint->GetColshapeType();
}

void Checkpoint_SetPlayersOnly(alt::ICheckpoint* checkpoint, uint8_t state) {
    checkpoint->SetPlayersOnly(state);
}

uint8_t Checkpoint_IsPlayersOnly(alt::ICheckpoint* checkpoint) {
    return checkpoint->IsPlayersOnly();
}

void Checkpoint_GetNextPosition(alt::ICheckpoint* checkpoint, position_t &pos) {
    auto position = checkpoint->GetNextPosition();
    pos.x = position.x;
    pos.y = position.y;
    pos.z = position.z;
}

void Checkpoint_SetNextPosition(alt::ICheckpoint* checkpoint, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    checkpoint->SetNextPosition(position);
}