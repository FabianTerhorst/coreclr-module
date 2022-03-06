#pragma once

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wempty-body"
#pragma clang diagnostic ignored "-Wswitch"
#endif

#include "../../cpp-sdk/SDK.h"
#include "../data/types.h"
#include "../data/cloth.h"
#include "../data/dlc_cloth.h"
#include "../data/prop.h"
#include "../data/dlc_prop.h"
#include "../data/head_blend_data.h"
#include "../data/head_overlay.h"
#include "../utils/export.h"

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#ifdef __cplusplus
extern "C"
{
#endif

EXPORT_SHARED uint16_t Player_GetID(alt::IPlayer* player);
EXPORT_SHARED alt::IEntity* Player_GetEntity(alt::IPlayer* player);

EXPORT_SHARED const char* Player_GetName(alt::IPlayer* player, int32_t& size);

EXPORT_SHARED uint16_t Player_GetHealth(alt::IPlayer* player);
EXPORT_SHARED uint16_t Player_GetMaxHealth(alt::IPlayer* player);

EXPORT_SHARED void Player_GetCurrentWeaponComponents(alt::IPlayer* player, alt::Array<uint32_t> &weaponComponents);
EXPORT_SHARED uint32_t Player_GetCurrentWeapon(alt::IPlayer* player);

EXPORT_SHARED uint8_t Player_IsDead(alt::IPlayer* player);
EXPORT_SHARED uint8_t Player_IsJumping(alt::IPlayer* player);
EXPORT_SHARED uint8_t Player_IsInRagdoll(alt::IPlayer* player);
EXPORT_SHARED uint8_t Player_IsAiming(alt::IPlayer* player);
EXPORT_SHARED uint8_t Player_IsShooting(alt::IPlayer* player);
EXPORT_SHARED uint8_t Player_IsReloading(alt::IPlayer* player);

EXPORT_SHARED uint16_t Player_GetArmor(alt::IPlayer* player);
EXPORT_SHARED uint16_t Player_GetMaxArmor(alt::IPlayer* player);

EXPORT_SHARED float Player_GetMoveSpeed(alt::IPlayer* player);

EXPORT_SHARED void Player_GetAimPos(alt::IPlayer* player, position_t &aimPosition);
EXPORT_SHARED void Player_GetHeadRotation(alt::IPlayer* player, rotation_t &headRotation);

EXPORT_SHARED uint8_t Player_IsInVehicle(alt::IPlayer* player);
EXPORT_SHARED alt::IVehicle* Player_GetVehicle(alt::IPlayer* player);
EXPORT_SHARED uint8_t Player_GetVehicleID(alt::IPlayer* player, uint16_t& id);
EXPORT_SHARED uint8_t Player_GetSeat(alt::IPlayer* player);

EXPORT_SHARED void* Player_GetEntityAimingAt(alt::IPlayer* player, alt::IBaseObject::Type &type);
EXPORT_SHARED void Player_GetEntityAimOffset(alt::IPlayer* player, position_t &position);

EXPORT_SHARED uint8_t Player_IsFlashlightActive(alt::IPlayer* player);

EXPORT_SERVER alt::MValueConst* Player_GetLocalMetaData(alt::IPlayer* player, const char* key);
EXPORT_SERVER void Player_SetLocalMetaData(alt::IPlayer* player, const char* key, alt::MValueConst* val);
EXPORT_SERVER uint8_t Player_HasLocalMetaData(alt::IPlayer* player, const char* key);
EXPORT_SERVER void Player_DeleteLocalMetaData(alt::IPlayer* player, const char* key);

EXPORT_SERVER uint8_t Player_IsConnected(alt::IPlayer* player);
EXPORT_SERVER void Player_Spawn(alt::IPlayer* player, alt::Position pos, uint32_t delayMs);
EXPORT_SERVER void Player_Despawn(alt::IPlayer* player);
EXPORT_SERVER void Player_SetModel(alt::IPlayer* player, uint32_t model);

EXPORT_SERVER uint64_t Player_GetSocialID(alt::IPlayer* player);
EXPORT_SERVER uint64_t Player_GetHwidHash(alt::IPlayer* player);
EXPORT_SERVER uint64_t Player_GetHwidExHash(alt::IPlayer* player);
EXPORT_SERVER const char* Player_GetAuthToken(alt::IPlayer* player, int32_t& size);

EXPORT_SERVER void Player_SetHealth(alt::IPlayer* player, uint16_t health);
EXPORT_SERVER void Player_SetMaxHealth(alt::IPlayer* player, uint16_t maxHealth);

EXPORT_SERVER void Player_SetDateTime(alt::IPlayer* player, int day, int month, int year, int hour, int minute, int second);
EXPORT_SERVER void Player_SetWeather(alt::IPlayer* player, uint32_t weather);

EXPORT_SERVER void Player_GiveWeapon(alt::IPlayer* player, uint32_t weapon, int32_t ammo, uint8_t selectWeapon);
EXPORT_SERVER uint8_t Player_RemoveWeapon(alt::IPlayer* player, uint32_t weapon);
EXPORT_SERVER void Player_RemoveAllWeapons(alt::IPlayer* player);

EXPORT_SERVER void Player_AddWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);
EXPORT_SERVER void Player_RemoveWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);
EXPORT_SERVER uint8_t Player_HasWeaponComponent(alt::IPlayer* player, uint32_t weapon, uint32_t component);

EXPORT_SERVER void Player_SetWeaponTintIndex(alt::IPlayer* player, uint32_t weapon, uint8_t tintIndex);
EXPORT_SERVER uint8_t Player_GetWeaponTintIndex(alt::IPlayer* player, uint32_t weapon);
EXPORT_SERVER uint8_t Player_GetCurrentWeaponTintIndex(alt::IPlayer* player);

EXPORT_SERVER void Player_SetCurrentWeapon(alt::IPlayer* player, uint32_t weapon);

EXPORT_SERVER uint64_t Player_GetWeaponCount(alt::IPlayer* player);
EXPORT_SERVER void Player_GetWeapons(alt::IPlayer* player, alt::Array<weapon_t>& weapons);

EXPORT_SERVER void Player_SetArmor(alt::IPlayer* player, uint16_t armor);
EXPORT_SERVER void Player_SetMaxArmor(alt::IPlayer* player, uint16_t armor);

EXPORT_SERVER void Player_Kick(alt::IPlayer* player, const char* reason);

EXPORT_SERVER uint32_t Player_GetPing(alt::IPlayer* player);
EXPORT_SERVER const char* Player_GetIP(alt::IPlayer* player, int32_t& size);

EXPORT_SERVER void Player_ClearBloodDamage(alt::IPlayer* player);

EXPORT_SERVER void Player_GetClothes(alt::IPlayer* player, uint8_t component, cloth_t& cloth);
EXPORT_SERVER void Player_SetClothes(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint8_t palette);
EXPORT_SERVER void Player_GetDlcClothes(alt::IPlayer* player, uint8_t component, dlccloth_t& cloth);
EXPORT_SERVER void Player_SetDlcClothes(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint8_t palette, uint32_t dlc);

EXPORT_SERVER void Player_GetProps(alt::IPlayer* player, uint8_t component, prop_t& prop);
EXPORT_SERVER void Player_SetProps(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture);
EXPORT_SERVER void Player_GetDlcProps(alt::IPlayer* player, uint8_t component, dlcprop_t& prop);
EXPORT_SERVER void Player_SetDlcProps(alt::IPlayer* player, uint8_t component, uint16_t drawable, uint8_t texture, uint32_t dlc);
EXPORT_SERVER void Player_ClearProps(alt::IPlayer* player, uint8_t component);

EXPORT_SERVER uint8_t Player_IsEntityInStreamingRange(alt::IPlayer* player, alt::IEntity* entity);

EXPORT_SERVER void Player_AttachToEntity(alt::IPlayer* player, alt::IEntity* entity, int16_t otherBone, int16_t ownBone, position_t pos, rotation_t rot, uint8_t collision, uint8_t noFixedRot);
EXPORT_SERVER void Player_Detach(alt::IPlayer* player);

EXPORT_SERVER uint8_t Player_GetInvincible(alt::IPlayer* player);
EXPORT_SERVER void Player_SetInvincible(alt::IPlayer* player, uint8_t state);

EXPORT_SERVER void Player_SetIntoVehicle(alt::IPlayer* player, alt::IVehicle* vehicle, uint8_t seat);

EXPORT_SERVER uint8_t Player_IsSuperJumpEnabled(alt::IPlayer* playere);
EXPORT_SERVER uint8_t Player_IsCrouching(alt::IPlayer* player);
EXPORT_SERVER uint8_t Player_IsStealthy(alt::IPlayer* player);

EXPORT_SERVER void Player_PlayAmbientSpeech(alt::IPlayer* player, const char* speechName, const char* speechParam, uint32_t speechDictHash);

EXPORT_SERVER uint8_t Player_SetHeadOverlay(alt::IPlayer* player, uint8_t overlayID, uint8_t index, float opacity);
EXPORT_SERVER uint8_t Player_RemoveHeadOverlay(alt::IPlayer* player, uint8_t overlayID);
EXPORT_SERVER uint8_t Player_SetHeadOverlayColor(alt::IPlayer* player, uint8_t overlayID, uint8_t colorType, uint8_t colorIndex, uint8_t secondColorIndex);
EXPORT_SERVER void Player_GetHeadOverlay(alt::IPlayer* player, uint8_t overlayID, head_overlay_t& headOverlay);

EXPORT_SERVER uint8_t Player_SetFaceFeature(alt::IPlayer* player, uint8_t index, float scale);
EXPORT_SERVER float Player_GetFaceFeatureScale(alt::IPlayer* player, uint8_t index);
EXPORT_SERVER uint8_t Player_RemoveFaceFeature(alt::IPlayer* player, uint8_t index);

EXPORT_SERVER uint8_t Player_SetHeadBlendPaletteColor(alt::IPlayer* player, uint8_t id, uint8_t red, uint8_t green, uint8_t blue);
EXPORT_SERVER void Player_GetHeadBlendPaletteColor(alt::IPlayer* player, uint8_t id, rgba_t& headBlendPaletteColor);
EXPORT_SERVER void Player_SetHeadBlendData(alt::IPlayer* player, uint32_t shapeFirstID, uint32_t shapeSecondID, uint32_t shapeThirdID,
    uint32_t skinFirstID, uint32_t skinSecondID, uint32_t skinThirdID,
    float shapeMix, float skinMix, float thirdMix);
EXPORT_SERVER void Player_GetHeadBlendData(alt::IPlayer* player, head_blend_data_t& headBlendData);

EXPORT_SERVER uint8_t Player_SetEyeColor(alt::IPlayer* player, uint16_t eyeColor);
EXPORT_SERVER uint16_t Player_GetEyeColor(alt::IPlayer* player);

EXPORT_SERVER void Player_SetHairColor(alt::IPlayer* player, uint8_t hairColor);
EXPORT_SERVER uint8_t Player_GetHairColor(alt::IPlayer* player);

EXPORT_SERVER void Player_SetHairHighlightColor(alt::IPlayer* player, uint8_t hairHighlightColor);
EXPORT_SERVER uint8_t Player_GetHairHighlightColor(alt::IPlayer* player);

EXPORT_CLIENT uint8_t Player_IsTalking(alt::IPlayer* player);
EXPORT_CLIENT float Player_GetMicLevel(alt::IPlayer* player);

EXPORT_CLIENT float Player_GetNonSpatialVolume(alt::IPlayer* player);
EXPORT_CLIENT void Player_SetNonSpatialVolume(alt::IPlayer* player, float value);

EXPORT_CLIENT float Player_GetSpatialVolume(alt::IPlayer* player);
EXPORT_CLIENT void Player_SetSpatialVolume(alt::IPlayer* player, float value);

EXPORT_CLIENT uint16_t LocalPlayer_GetID(alt::ILocalPlayer* localPlayer);
EXPORT_CLIENT alt::ILocalPlayer* Player_GetLocal();
EXPORT_CLIENT alt::IPlayer* LocalPlayer_GetPlayer(alt::ILocalPlayer* player);

EXPORT_CLIENT uint16_t LocalPlayer_GetCurrentAmmo(alt::ILocalPlayer* localPlayer);

#ifdef __cplusplus
}
#endif
