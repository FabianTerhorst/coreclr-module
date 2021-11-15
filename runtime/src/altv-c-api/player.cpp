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

uint8_t Player_HasMetaData(alt::IPlayer* player, const char* key) {
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

uint8_t Player_HasSyncedMetaData(alt::IPlayer* player, const char* key) {
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

uint8_t Player_HasStreamSyncedMetaData(alt::IPlayer* player, const char* key) {
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

uint8_t Player_GetVisible(alt::IPlayer* player) {
    return player->GetVisible();
}

void Player_SetVisible(alt::IPlayer* player, uint8_t state) {
    player->SetVisible(state);
}

uint8_t Player_GetStreamed(alt::IPlayer* player) {
    return player->GetStreamed();
}

void Player_SetStreamed(alt::IPlayer* player, uint8_t state) {
    player->SetStreamed(state);
}

// Player

uint8_t Player_IsConnected(alt::IPlayer* player) {
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

void Player_GiveWeapon(alt::IPlayer* player, uint32_t weapon, int32_t ammo, uint8_t selectWeapon) {
    player->GiveWeapon(weapon, ammo, selectWeapon);
}

uint8_t Player_RemoveWeapon(alt::IPlayer* player, uint32_t weapon) {
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

uint8_t Player_HasWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component) {
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

uint64_t Player_GetWeaponCount(alt::IPlayer* player) {
    return player->GetWeapons().GetSize();
}

void Player_GetWeapons(alt::IPlayer* player, weapon_t weapons[], uint64_t size) {
    auto playerWeapons = player->GetWeapons();

    if (playerWeapons.GetSize() < size) {
        size = playerWeapons.GetSize();
    }

    for (uint64_t i = 0; i < size; i++) {
        weapons[i].hash = playerWeapons[i].hash;
        weapons[i].tintIndex = playerWeapons[i].tintIndex;

        int componentsSize = playerWeapons[i].components.size();

        //Free in C#
        if (componentsSize == 0) {
            weapons[i].components = nullptr;
        }
        else {
            weapons[i].components = new uint32_t[componentsSize];
        }

        int j = 0;
        for (auto component : playerWeapons[i].components) {
            if (j >= componentsSize) {
                break;
            }

            weapons[i].components[j] = component;
            j++;
        }
    }
}

uint8_t Player_IsDead(alt::IPlayer* player) {
    return player->IsDead();
}

uint8_t Player_IsJumping(alt::IPlayer* player) {
    return player->IsJumping();
}

uint8_t Player_IsInRagdoll(alt::IPlayer* player) {
    return player->IsInRagdoll();
}

uint8_t Player_IsAiming(alt::IPlayer* player) {
    return player->IsAiming();
}

uint8_t Player_IsShooting(alt::IPlayer* player) {
    return player->IsShooting();
}

uint8_t Player_IsReloading(alt::IPlayer* player) {
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

uint8_t Player_IsInVehicle(alt::IPlayer* player) {
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

uint8_t Player_IsFlashlightActive(alt::IPlayer* player) {
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

void Player_SetNetworkOwner(alt::IPlayer* player, alt::IPlayer* networkOwnerPlayer, uint8_t disableMigration) {
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

void Player_ClearProps(alt::IPlayer* player, uint8_t component) {
    player->ClearProps(component);
}

uint8_t Player_IsEntityInStreamingRange_Player(alt::IPlayer* player, alt::IPlayer* entity) {
    return player->IsEntityInStreamingRange(entity);
}

uint8_t Player_IsEntityInStreamingRange_Vehicle(alt::IPlayer* player, alt::IVehicle* entity) {
    return player->IsEntityInStreamingRange(entity);
}

void Player_AttachToEntity_Player(alt::IPlayer* player, alt::IPlayer* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot)
{
    alt::Position position{pos.x, pos.y, pos.z};
    alt::Rotation rotation{rot.roll, rot.pitch, rot.yaw};
    player->AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRot);
}

void Player_AttachToEntity_Vehicle(alt::IPlayer* player, alt::IVehicle* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot)
{
    alt::Position position{pos.x, pos.y, pos.z};
    alt::Rotation rotation{rot.roll, rot.pitch, rot.yaw};
    player->AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRot);
}

void Player_Detach(alt::IPlayer* player)
{
    player->Detach();
}

uint8_t Player_GetInvincible(alt::IPlayer* player)
{
    return player->GetInvincible();
}

void Player_SetInvincible(alt::IPlayer* player, uint8_t state) {
    player->SetInvincible(state);
}

void Player_SetIntoVehicle(alt::IPlayer* player, alt::IVehicle* vehicle, uint8_t seat) {
    player->SetIntoVehicle(vehicle, seat);
}

uint8_t Player_IsSuperJumpEnabled(alt::IPlayer* player)
{
    return player->IsSuperJumpEnabled();
}

uint8_t Player_IsCrouching(alt::IPlayer* player)
{
    return player->IsCrouching();
}

uint8_t Player_IsStealthy(alt::IPlayer* player)
{
    return player->IsStealthy();
}

void Player_PlayAmbientSpeech(alt::IPlayer* player, const char* speechName, const char* speechParam, uint32_t speechDictHash)
{
    player->PlayAmbientSpeech(speechName, speechParam, speechDictHash);
}

uint8_t Player_SetHeadOverlay(alt::IPlayer* player, uint8_t overlayID, uint8_t index, float opacity)
{
    return player->SetHeadOverlay(overlayID, index, opacity);
}

uint8_t Player_RemoveHeadOverlay(alt::IPlayer* player, uint8_t overlayID)
{
    return player->RemoveHeadOverlay(overlayID);
}

uint8_t Player_SetHeadOverlayColor(alt::IPlayer* player, uint8_t overlayID, uint8_t colorType, uint8_t colorIndex, uint8_t secondColorIndex)
{
    return player->SetHeadOverlayColor(overlayID, colorType, colorIndex, secondColorIndex);
}

void Player_GetHeadOverlay(alt::IPlayer* player, uint8_t overlayID, head_overlay_t &headOverlay)
{
    auto playerHeadOverlay = player->GetHeadOverlay(overlayID);
    headOverlay.index = playerHeadOverlay.index;
    headOverlay.opacity = playerHeadOverlay.opacity;
    headOverlay.colorType = playerHeadOverlay.colorType;
    headOverlay.colorIndex = playerHeadOverlay.colorIndex;
    headOverlay.secondColorIndex = playerHeadOverlay.secondColorIndex;
}

uint8_t Player_SetFaceFeature(alt::IPlayer* player, uint8_t index, float scale)
{
    return player->SetFaceFeature(index, scale);
}

float Player_GetFaceFeatureScale(alt::IPlayer* player, uint8_t index)
{
    return player->GetFaceFeatureScale(index);
}

uint8_t Player_RemoveFaceFeature(alt::IPlayer* player, uint8_t index)
{
    return player->RemoveFaceFeature(index);
}

uint8_t Player_SetHeadBlendPaletteColor(alt::IPlayer* player, uint8_t id, uint8_t red, uint8_t green, uint8_t blue)
{
    return player->SetHeadBlendPaletteColor(id, red, green, blue);
}

void Player_GetHeadBlendPaletteColor(alt::IPlayer* player, uint8_t id, rgba_t &headBlendPaletteColor)
{
    auto playerHeadBlendPaletteColor = player->GetHeadBlendPaletteColor(id);
    headBlendPaletteColor.r = playerHeadBlendPaletteColor.r;
    headBlendPaletteColor.g = playerHeadBlendPaletteColor.g;
    headBlendPaletteColor.b = playerHeadBlendPaletteColor.b;
    headBlendPaletteColor.a= playerHeadBlendPaletteColor.a;
}

void Player_SetHeadBlendData(alt::IPlayer* player, uint32_t shapeFirstID, uint32_t shapeSecondID, uint32_t shapeThirdID,
    uint32_t skinFirstID, uint32_t skinSecondID, uint32_t skinThirdID,
    float shapeMix, float skinMix, float thirdMix)
{
    return player->SetHeadBlendData(shapeFirstID, shapeSecondID, shapeThirdID, skinFirstID, skinSecondID, skinThirdID, shapeMix, skinMix, thirdMix);
}

void Player_GetHeadBlendData(alt::IPlayer* player, head_blend_data_t &headBlendData)
{
    auto playerHeadBlendData = player->GetHeadBlendData();
    headBlendData.shapeFirstID = playerHeadBlendData.shapeFirstID;
    headBlendData.shapeSecondID = playerHeadBlendData.shapeSecondID;
    headBlendData.shapeThirdID = playerHeadBlendData.shapeThirdID;
    headBlendData.skinFirstID = playerHeadBlendData.skinFirstID;
    headBlendData.skinSecondID = playerHeadBlendData.skinSecondID;
    headBlendData.skinThirdID = playerHeadBlendData.skinThirdID;
    headBlendData.shapeMix = playerHeadBlendData.shapeMix;
    headBlendData.skinMix = playerHeadBlendData.skinMix;
    headBlendData.thirdMix = playerHeadBlendData.thirdMix;
}

uint8_t Player_SetEyeColor(alt::IPlayer* player, uint16_t eyeColor)
{
    return player->SetEyeColor(eyeColor);
}

uint16_t Player_GetEyeColor(alt::IPlayer* player)
{
    return player->GetEyeColor();
}

void Player_SetHairColor(alt::IPlayer* player, uint8_t hairColor)
{
    return player->SetHairColor(hairColor);
}

uint8_t Player_GetHairColor(alt::IPlayer* player)
{
    return player->GetHairColor();
}

void Player_SetHairHighlightColor(alt::IPlayer* player, uint8_t hairHighlightColor)
{
    return player->SetHairHighlightColor(hairHighlightColor);
}

uint8_t Player_GetHairHighlightColor(alt::IPlayer* player)
{
    return player->GetHairHighlightColor();
}