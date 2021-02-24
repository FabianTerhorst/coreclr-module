#include "player.h"

// Entity

uint16_t Player_GetID(alt::IPlayer* player) {
    return player->GetID();
}

alt::IPlayer* Player_GetNetworkOwner(alt::IPlayer* player) {
    return player->GetNetworkOwner().Get();
}

uint32_t Player_GetModel(alt::IPlayer* player) {
    return player->GetModel();
}

void Player_SetModel(alt::IPlayer* player, uint32_t model) {
    player->SetModel(model);
}

void Player_GetPosition(alt::IPlayer* player, position_t &position) {
    auto playerPosition = player->GetPosition();
    position.x = playerPosition.x;
    position.y = playerPosition.y;
    position.z = playerPosition.z;
}

void Player_GetPositionCoords(alt::IPlayer* player, float *position_x, float *position_y, float *position_z, int *dimension) {
    auto playerPosition = player->GetPosition();
    *position_x = playerPosition.x;
    *position_y = playerPosition.y;
    *position_z = playerPosition.z;
    *dimension = player->GetDimension();
}

void Player_SetPosition(alt::IPlayer* player, position_t pos) {
    alt::Position position;
    position.x = pos.x;
    position.y = pos.y;
    position.z = pos.z;
    player->SetPosition(position);
}

void Player_GetRotation(alt::IPlayer* player, rotation_t &rotation) {
    auto playerRotation = player->GetRotation();
    rotation.roll = playerRotation.roll;
    rotation.pitch = playerRotation.pitch;
    rotation.yaw = playerRotation.yaw;
}

void Player_SetRotation(alt::IPlayer* player, rotation_t rot) {
    alt::Rotation rotation;
    rotation.roll = rot.roll;
    rotation.pitch = rot.pitch;
    rotation.yaw = rot.yaw;
    player->SetRotation(rotation);
}

int32_t Player_GetDimension(alt::IPlayer* player) {
    return player->GetDimension();
}

void Player_SetDimension(alt::IPlayer* player, int32_t dimension) {
    player->SetDimension(dimension);
}

alt::MValueConst* Player_GetMetaData(alt::IPlayer* player, const char* key) {
    return new alt::MValueConst(player->GetMetaData(key));
}

void Player_SetMetaData(alt::IPlayer* player, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    player->SetMetaData(key, val->Get()->Clone());
}

bool Player_HasMetaData(alt::IPlayer* player, const char* key) {
    return player->HasMetaData(key);
}

void Player_DeleteMetaData(alt::IPlayer* player, const char* key) {
    player->DeleteMetaData(key);
}

alt::MValueConst* Player_GetSyncedMetaData(alt::IPlayer* player, const char* key) {
    return new alt::MValueConst(player->GetSyncedMetaData(key));
}

void Player_SetSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    player->SetSyncedMetaData(key, val->Get()->Clone());
}

bool Player_HasSyncedMetaData(alt::IPlayer* player, const char* key) {
    return player->HasSyncedMetaData(key);
}

void Player_DeleteSyncedMetaData(alt::IPlayer* player, const char* key) {
    player->DeleteSyncedMetaData(key);
}

alt::MValueConst* Player_GetStreamSyncedMetaData(alt::IPlayer* player, const char* key) {
    return new alt::MValueConst(player->GetStreamSyncedMetaData(key));
}

void Player_SetStreamSyncedMetaData(alt::IPlayer* player, const char* key, alt::MValueConst* val) {
    if (val == nullptr) return;
    player->SetStreamSyncedMetaData(key, val->Get()->Clone());
}

bool Player_HasStreamSyncedMetaData(alt::IPlayer* player, const char* key) {
    return player->HasStreamSyncedMetaData(key);
}

void Player_DeleteStreamSyncedMetaData(alt::IPlayer* player, const char* key) {
    player->DeleteStreamSyncedMetaData(key);
}

void Player_AddRef(alt::IPlayer* player) {
    player->AddRef();
}

void Player_RemoveRef(alt::IPlayer* player) {
    player->RemoveRef();
}

bool Player_GetVisible(alt::IPlayer* player) {
    return player->GetVisible();
}

void Player_SetVisible(alt::IPlayer* player, bool state) {
    player->SetVisible(state);
}

// Player

bool Player_IsConnected(alt::IPlayer* player) {
    return player->IsConnected();
}

void Player_Spawn(alt::IPlayer* player, alt::Position pos, uint32_t delayMs) {
    player->Spawn(pos, delayMs);
}

void Player_Despawn(alt::IPlayer* player) {
    player->Despawn();
}

void Player_GetName(alt::IPlayer* player, const char*&name) {
    name = player->GetName().CStr();
}

uint64_t Player_GetSocialID(alt::IPlayer* player) {
    return player->GetSocialID();
}

uint64_t Player_GetHwidHash(alt::IPlayer* player) {
    return player->GetHwidHash();
}

uint64_t Player_GetHwidExHash(alt::IPlayer* player) {
    return player->GetHwidExHash();
}

void Player_GetAuthToken(alt::IPlayer* player, const char*&name) {
    name = player->GetAuthToken().CStr();
}

uint16_t Player_GetHealth(alt::IPlayer* player) {
    return player->GetHealth();
}

void Player_SetHealth(alt::IPlayer* player, uint16_t health) {
    player->SetHealth(health);
}

uint16_t Player_GetMaxHealth(alt::IPlayer* player) {
    return player->GetMaxHealth();
}

void Player_SetMaxHealth(alt::IPlayer* player, uint16_t maxHealth) {
    player->SetMaxHealth(maxHealth);
}

void Player_GetIP(alt::IPlayer* player, const char*&ip) {
    ip = player->GetIP().CStr();
}

void Player_SetDateTime(alt::IPlayer* player, int day, int month, int year, int hour, int minute, int second) {
    player->SetDateTime(day, month, year, hour, minute, second);
}

void Player_SetWeather(alt::IPlayer* player, uint32_t weather) {
    player->SetWeather(weather);
}

void Player_GiveWeapon(alt::IPlayer* player, uint32_t weapon, int32_t ammo, bool selectWeapon) {
    player->GiveWeapon(weapon, ammo, selectWeapon);
}

bool Player_RemoveWeapon(alt::IPlayer* player, uint32_t weapon) {
    return player->RemoveWeapon(weapon);
}

void Player_RemoveAllWeapons(alt::IPlayer* player) {
    player->RemoveAllWeapons();
}

void Player_AddWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component) {
    player->AddWeaponComponent(weapon, component);
}

void Player_RemoveWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component) {
    player->RemoveWeaponComponent(weapon, component);
}

bool Player_HasWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component) {
    return player->HasWeaponComponent(weapon, component);
}

void Player_GetCurrentWeaponComponents(alt::IPlayer* player, alt::Array<uint32_t> &weaponComponents) {
    auto currWeaponComponents = player->GetCurrentWeaponComponents();
    alt::Array<uint32_t> values;
    for (auto currWeaponComponent : currWeaponComponents) {
        values.Push(currWeaponComponent);
    }
    weaponComponents = values;
}

void Player_SetWeaponTintIndex(alt::IPlayer* player, uint32_t weapon, uint8_t tintIndex) {
    player->SetWeaponTintIndex(weapon, tintIndex);
}

uint8_t Player_GetWeaponTintIndex(alt::IPlayer* player, uint32_t weapon) {
    return player->GetWeaponTintIndex(weapon);
}

uint8_t Player_GetCurrentWeaponTintIndex(alt::IPlayer* player) {
    return player->GetCurrentWeaponTintIndex();
}

uint32_t Player_GetCurrentWeapon(alt::IPlayer* player) {
    return player->GetCurrentWeapon();
}

void Player_SetCurrentWeapon(alt::IPlayer* player, uint32_t weapon) {
    player->SetCurrentWeapon(weapon);
}

bool Player_IsDead(alt::IPlayer* player) {
    return player->IsDead();
}

bool Player_IsJumping(alt::IPlayer* player) {
    return player->IsJumping();
}

bool Player_IsInRagdoll(alt::IPlayer* player) {
    return player->IsInRagdoll();
}

bool Player_IsAiming(alt::IPlayer* player) {
    return player->IsAiming();
}

bool Player_IsShooting(alt::IPlayer* player) {
    return player->IsShooting();
}

bool Player_IsReloading(alt::IPlayer* player) {
    return player->IsReloading();
}

uint16_t Player_GetArmor(alt::IPlayer* player) {
    return player->GetArmour();
}

void Player_SetArmor(alt::IPlayer* player, uint16_t armor) {
    player->SetArmour(armor);
}

uint16_t Player_GetMaxArmor(alt::IPlayer* player) {
    return player->GetMaxArmour();
}

void Player_SetMaxArmor(alt::IPlayer* player, uint16_t armor) {
    player->SetMaxArmour(armor);
}

float Player_GetMoveSpeed(alt::IPlayer* player) {
    return player->GetMoveSpeed();
}

void Player_GetAimPos(alt::IPlayer* player, position_t &aimPosition) {
    auto playerAimPosition = player->GetAimPos();
    aimPosition.x = playerAimPosition.x;
    aimPosition.y = playerAimPosition.y;
    aimPosition.z = playerAimPosition.z;
}

void Player_GetHeadRotation(alt::IPlayer* player, rotation_t &headRotation) {
    auto playerHeadRotation = player->GetHeadRotation();
    headRotation.roll = playerHeadRotation.roll;
    headRotation.pitch = playerHeadRotation.pitch;
    headRotation.yaw = playerHeadRotation.yaw;
}

bool Player_IsInVehicle(alt::IPlayer* player) {
    return player->IsInVehicle();
}

alt::IVehicle* Player_GetVehicle(alt::IPlayer* player) {
    return player->GetVehicle().Get();
}

uint8_t Player_GetSeat(alt::IPlayer* player) {
    return player->GetSeat();
}

void* Player_GetEntityAimingAt(alt::IPlayer* player, alt::IBaseObject::Type &type) {
    auto entity = player->GetEntityAimingAt().Get();
    if (entity != nullptr) {
        type = entity->GetType();
        switch (type) {
            case alt::IBaseObject::Type::PLAYER:
                return dynamic_cast<alt::IPlayer*>(entity);
            case alt::IBaseObject::Type::VEHICLE:
                return dynamic_cast<alt::IVehicle*>(entity);
            default:
                return nullptr;
        }
    }
    return nullptr;
}

void Player_GetEntityAimOffset(alt::IPlayer* player, position_t &position) {
    auto offset = player->GetEntityAimOffset();
    position.x = offset.x;
    position.y = offset.y;
    position.z = offset.z;
}

bool Player_IsFlashlightActive(alt::IPlayer* player) {
    return player->IsFlashlightActive();
}

void Player_Kick(alt::IPlayer* player, const char* reason) {
    player->Kick(reason);
}

uint32_t Player_GetPing(alt::IPlayer* player) {
    return player->GetPing();
}

void Player_Copy(alt::IPlayer* player, player_struct_t* player_struct) {
    player_struct->id = player->GetID();
    auto position = player->GetPosition();
    player_struct->position.x = position.x;
    player_struct->position.y = position.y;
    player_struct->position.z = position.z;
    auto rotation = player->GetRotation();
    player_struct->rotation.roll = rotation.roll;
    player_struct->rotation.pitch = rotation.pitch;
    player_struct->rotation.yaw = rotation.yaw;
    player_struct->dimension = player->GetDimension();
    player_struct->ping = player->GetPing();
    player_struct->model = player->GetModel();
    player_struct->seat = player->GetSeat();
    auto aimPosition = player->GetAimPos();
    player_struct->aim_position.x = aimPosition.x;
    player_struct->aim_position.y = aimPosition.y;
    player_struct->aim_position.z = aimPosition.z;
    auto headRotation = player->GetHeadRotation();
    player_struct->head_rotation.roll = headRotation.roll;
    player_struct->head_rotation.pitch = headRotation.pitch;
    player_struct->head_rotation.yaw = headRotation.yaw;
    player_struct->armor = player->GetArmour();
    player_struct->move_speed = player->GetMoveSpeed();
    auto name = player->GetName();
    // Free in c# after async method ends
    auto copiedName = new char[name.GetSize() + 1];
    memcpy(copiedName, name.GetData(), name.GetSize());
    copiedName[name.GetSize()] = '\0';
    player_struct->name = copiedName;
    player_struct->health = player->GetHealth();
    player_struct->is_in_ragdoll = player->IsInRagdoll();
    player_struct->is_dead = player->IsDead();
    player_struct->is_shooting = player->IsShooting();
    player_struct->is_aiming = player->IsAiming();
    player_struct->is_in_vehicle = player->IsInVehicle();
    player_struct->is_jumping = player->IsJumping();
    player_struct->is_reloading = player->IsReloading();
    player_struct->is_connected = player->IsConnected();
    player_struct->vehicle = player->GetVehicle().Get();
}

void Player_Copy_Dispose(player_struct_t* player_struct) {
    delete[] player_struct->name;
}

void Player_GetPositionCoords2(alt::IPlayer* player, float* position_x, float* position_y, float* position_z,float *rotation_x,float *rotation_y,float *rotation_z,int* dimension) {
    auto playerPosition = player->GetPosition();
    *position_x = playerPosition.x;
    *position_y = playerPosition.y;
    *position_z = playerPosition.z;
    auto playerRotation = player->GetRotation();
    *rotation_x = playerRotation.pitch;
    *rotation_y = playerRotation.roll;
    *rotation_z = playerRotation.yaw;
    *dimension = player->GetDimension();
}

void Player_SetNetworkOwner(alt::IPlayer* player, alt::IPlayer* networkOwnerPlayer, bool disableMigration) {
    player->SetNetworkOwner(networkOwnerPlayer, disableMigration);
}

void Player_ClearBloodDamage(alt::IPlayer* player) {
    player->ClearBloodDamage();
}

void Player_GetClothes(alt::IPlayer* player, uint8_t component, cloth_t& cloth) {
    auto clothes = player->GetClothes(component);
    cloth.drawable = clothes.drawableId;
    cloth.texture = clothes.textureId;
    cloth.palette = clothes.textureId;
}

void Player_SetClothes(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint8_t palette) {
    player->SetClothes(component, drawable, texture, palette);
}

void Player_GetDlcClothes(alt::IPlayer* player, uint8_t component, dlccloth_t& cloth) {
    auto clothes = player->GetDlcClothes(component);
    cloth.dlc = clothes.dlc;
    cloth.drawable = clothes.drawableId;
    cloth.texture = clothes.textureId;
    cloth.palette = clothes.textureId;
}

void Player_SetDlcClothes(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint8_t palette, uint32_t dlc) {
    player->SetDlcClothes(component, drawable, texture, palette, dlc);
}

void Player_GetProps(alt::IPlayer* player, uint8_t component, prop_t& prop) {
    auto props = player->GetProps(component);
    prop.drawable = props.drawableId;
    prop.texture = props.textureId;
}

void Player_SetProps(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture) {
    player->SetProps(component, drawable, texture);
}

void Player_GetDlcProps(alt::IPlayer* player, uint8_t component, dlcprop_t& prop) {
    auto props = player->GetDlcProps(component);
    prop.dlc = props.dlc;
    prop.drawable = props.drawableId;
    prop.texture = props.textureId;
}

void Player_SetDlcProps(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint32_t dlc) {
    player->SetDlcProps(component, drawable, texture, dlc);
}

bool Player_IsEntityInStreamingRange(alt::IPlayer* player, alt::IEntity* entity) {
    return player->IsEntityInStreamingRange(entity);
}
