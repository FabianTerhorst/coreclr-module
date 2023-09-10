using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Args;
using AltV.Net.Enums;
using AltV.Net.Native;

namespace AltV.Net.Async
{
    public static partial class AltAsync
    {
        [Obsolete("Use async entities instead")]
        public static Task<bool> IsConnectedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsConnected);

        [Obsolete("Use async entities instead")]
        public static Task SetModelAsync(this IPlayer player, uint model) =>
            AltVAsync.Schedule(() => player.Model = model);

        [Obsolete("Use async entities instead")]
        public static async Task<string> GetNameAsync(this IPlayer player) => await AltVAsync.Schedule(
                () => player.Name);

        [Obsolete("Use async entities instead")]
        public static Task<ushort> GetHealthAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Health);

        [Obsolete("Use async entities instead")]
        public static Task SetHealthAsync(this IPlayer player, ushort health) =>
            AltVAsync.Schedule(() => player.Health = health);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsDeadAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsDead);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsJumpingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsJumping);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsInRagdollAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsInRagdoll);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsAimingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsAiming);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsShootingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsShooting);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsReloadingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsReloading);

        [Obsolete("Use async entities instead")]
        public static Task<ushort> GetArmorAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Armor);

        [Obsolete("Use async entities instead")]
        public static Task SetArmorAsync(this IPlayer player, ushort armor) =>
            AltVAsync.Schedule(() => player.Armor = armor);

        [Obsolete("Use async entities instead")]
        public static Task<float> GetMoveSpeedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.MoveSpeed);

        [Obsolete("Use async entities instead")]
        public static Task<Position> GetAimPositionAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.AimPosition);

        [Obsolete("Use async entities instead")]
        public static Task<Rotation> GetHeadRotationAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.HeadRotation);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsInVehicleAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsInVehicle);

        [Obsolete("Use async entities instead")]
        public static async Task<IVehicle> GetVehicleAsync(this IPlayer player)
        {
            return await AltVAsync.Schedule(() =>
                {
                    unsafe
                    {
                        player.CheckIfEntityExists();
                        var vehiclePtr = Alt.Core.Library.Shared.Player_GetVehicle(player.PlayerNativePointer);
                        return Alt.Core.PoolManager.Vehicle.Get(vehiclePtr);
                    }
                });
        }

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetSeatAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Seat);

        [Obsolete("Use async entities instead")]
        public static Task<uint> GetPingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Ping);

        [Obsolete("Use async entities instead")]
        public static Task SpawnAsync(this IPlayer player, Position position, uint delayMs = 0) =>
            AltVAsync.Schedule(() => player.Spawn(position, delayMs));

        [Obsolete("Use async entities instead")]
        public static Task DespawnAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.Despawn);

        [Obsolete("Use async entities instead")]
        public static Task SetDateTimeAsync(this IPlayer player, int day, int month, int year, int hour,
            int minute, int second) =>
            AltVAsync.Schedule(() => player.SetDateTime(day, month, year, hour, minute, second));

        [Obsolete("Use async entities instead")]
        public static Task SetDateTimeAsync(this IPlayer player, DateTime dateTime) =>
            AltVAsync.Schedule(() => player.SetDateTime(dateTime));

        [Obsolete("Use async entities instead")]
        public static Task SetWeatherAsync(this IPlayer player, uint weather) =>
            AltVAsync.Schedule(() => player.SetWeather(weather));

        [Obsolete("Use async entities instead")]
        public static Task GiveWeaponAsync(this IPlayer player, uint weapon, int ammo, bool selectWeapon) =>
            AltVAsync.Schedule(() => player.GiveWeapon(weapon, ammo, selectWeapon));

        [Obsolete("Use async entities instead")]
        public static Task RemoveWeaponAsync(this IPlayer player, uint weapon) =>
            AltVAsync.Schedule(() => player.RemoveWeapon(weapon));

        [Obsolete("Use async entities instead")]
        public static Task RemoveAllWeaponsAsync(this IPlayer player, bool removeAllAmmo) =>
            AltVAsync.Schedule(() => player.RemoveAllWeapons(removeAllAmmo));

        [Obsolete("Use async entities instead")]
        public static Task SetMaxHealthAsync(this IPlayer player, ushort maxhealth) =>
            AltVAsync.Schedule(() => player.MaxHealth = maxhealth);

        [Obsolete("Use async entities instead")]
        public static Task SetMaxArmorAsync(this IPlayer player, ushort maxarmor) =>
            AltVAsync.Schedule(() => player.MaxArmor = maxarmor);

        [Obsolete("Use async entities instead")]
        public static Task SetCurrentWeaponAsync(this IPlayer player, uint weapon) =>
            AltVAsync.Schedule(() => player.CurrentWeapon = weapon);

        [Obsolete("Use async entities instead")]
        public static async Task KickAsync(this IPlayer player, string reason)
        {
            var reasonPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
            await AltVAsync.Schedule(() =>
            {
                unsafe
                {
                    player.CheckIfEntityExists();
                    Alt.Core.Library.Server.Player_Kick(player.PlayerNativePointer, reasonPtr);
                }
            });
            Marshal.FreeHGlobal(reasonPtr);
        }

        [Obsolete("Use async entities instead")]
        public static async Task EmitAsync(this IPlayer player, string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            Alt.Core.CreateMValues(mValues, args);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await AltVAsync.Schedule(() =>
            {
                player.CheckIfEntityExists();
                Alt.Core.TriggerClientEvent(player, eventNamePtr, mValues);
            });
            Marshal.FreeHGlobal(eventNamePtr);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        [Obsolete("Use async entities instead")]
        public static Task<bool> GetVisibleAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Visible);

        [Obsolete("Use async entities instead")]
        public static Task SetVisibleAsync(this IPlayer player, bool visibility) =>
            AltVAsync.Schedule(() => player.Visible = visibility);

        [Obsolete("Use async entities instead")]
        public static Task<bool> GetStreamedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Streamed);

        [Obsolete("Use async entities instead")]
        public static Task SetStreamedAsync(this IPlayer player, bool isStreamed) =>
            AltVAsync.Schedule(() => player.Streamed = isStreamed);

        [Obsolete("Use async entities instead")]
        public static Task<string> GetAuthTokenAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.AuthToken);

        [Obsolete("Use async entities instead")]
        public static Task<uint> GetCurrentWeaponAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.CurrentWeapon);

        [Obsolete("Use async entities instead")]
        public static Task<IEntity> GetEntityAimingAtAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.EntityAimingAt);

        [Obsolete("Use async entities instead")]
        public static Task<Position> GetEntityAimOffsetAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.EntityAimOffset);

        [Obsolete("Use async entities instead")]
        public static Task<ulong> GetHardwareIdHashAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.HardwareIdHash);

        [Obsolete("Use async entities instead")]
        public static Task<ulong> GetHardwareIdExHashAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.HardwareIdExHash);

        [Obsolete("Use async entities instead")]
        public static Task<string> GetIpAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Ip);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsFlashlightActiveAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsFlashlightActive);

        [Obsolete("Use async entities instead")]
        public static Task<ushort> GetMaxArmorAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.MaxArmor);

        [Obsolete("Use async entities instead")]
        public static Task<ushort> GetMaxHealthAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.MaxHealth);

        [Obsolete("Use async entities instead")]
        public static Task<ulong> GetSocialClubIdAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.SocialClubId);

        [Obsolete("Use async entities instead")]
        public static Task AddWeaponComponentAsync(this IPlayer player, uint weapon, uint weaponComponent) =>
            AltVAsync.Schedule(() => player.AddWeaponComponent(weapon, weaponComponent));

        [Obsolete("Use async entities instead")]
        public static Task AddWeaponComponentAsync(this IPlayer player, WeaponModel weaponModel, uint weaponComponent) =>
            AltVAsync.Schedule(() => player.AddWeaponComponent(weaponModel, weaponComponent));

        [Obsolete("Use async entities instead")]
        public static Task AttachToEntityAsync(this IPlayer player, IEntity entity, ushort otherBoneId, ushort ownBoneId,
            Position position, Rotation rotation, bool collision, bool noFixedRotation) =>
            AltVAsync.Schedule(() =>
                player.AttachToEntity(entity, otherBoneId, ownBoneId, position, rotation, collision, noFixedRotation));

        [Obsolete("Use async entities instead")]
        public static Task ClearBloodDamageAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.ClearBloodDamage);

        [Obsolete("Use async entities instead")]
        public static Task ClearPropsAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.ClearProps(component));

        [Obsolete("Use async entities instead")]
        public static Task DetachAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.Detach);

        [Obsolete("Use async entities instead")]
        public static Task<Cloth> GetClothesAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetClothes(component));

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetCurrentWeaponTintIndexAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.GetCurrentWeaponTintIndex);

        [Obsolete("Use async entities instead")]
        public static Task<DlcCloth> GetDlcClothesAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetDlcClothes(component));

        [Obsolete("Use async entities instead")]
        public static Task<DlcProp> GetDlcPropsAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetDlcProps(component));

        [Obsolete("Use async entities instead")]
        public static Task<Prop> GetPropsAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetProps(component));

        [Obsolete("Use async entities instead")]
        public static Task<byte> GetWeaponTintIndexAsync(this IPlayer player, uint weapon) =>
            AltVAsync.Schedule(() => player.GetWeaponTintIndex(weapon));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsEntityInStreamingRangeAsync(this IPlayer player, IEntity entity) =>
            AltVAsync.Schedule(() => player.IsEntityInStreamingRange(entity));

        [Obsolete("Use async entities instead")]
        public static Task RemoveWeaponComponentAsync(this IPlayer player, uint weapon, uint weaponComponent) =>
            AltVAsync.Schedule(() => player.RemoveWeaponComponent(weapon, weaponComponent));

        [Obsolete("Use async entities instead")]
        public static Task<bool> SetClothesAsync(this IPlayer player, byte component, ushort drawable, byte texture,
            byte palette) =>
            AltVAsync.Schedule(() => player.SetClothes(component, drawable, texture, palette));

        [Obsolete("Use async entities instead")]
        public static Task<bool> SetDlcClothesAsync(this IPlayer player, byte component, ushort drawable, byte texture,
            byte palette, uint dlc) =>
            AltVAsync.Schedule(() => player.SetDlcClothes(component, drawable, texture, palette, dlc));

        [Obsolete("Use async entities instead")]
        public static Task<bool> SetPropsAsync(this IPlayer player, byte component, ushort drawable, byte texture) =>
            AltVAsync.Schedule(() => player.SetProps(component, drawable, texture));

        [Obsolete("Use async entities instead")]
        public static Task<bool> SetDlcPropsAsync(this IPlayer player, byte component, ushort drawable, byte texture,
            uint dlc) =>
            AltVAsync.Schedule(() => player.SetDlcProps(component, drawable, texture, dlc));

        [Obsolete("Use async entities instead")]
        public static Task SetWeaponTintIndexAsync(this IPlayer player, uint weapon, byte tintIndex) =>
            AltVAsync.Schedule(() => player.SetWeaponTintIndex(weapon, tintIndex));

        [Obsolete("Use async entities instead")]
        public static Task SetWeaponTintIndexAsync(this IPlayer player, WeaponModel weaponModel, byte tintIndex) =>
            AltVAsync.Schedule(() => player.SetWeaponTintIndex(weaponModel, tintIndex));

        [Obsolete("Use async entities instead")]
        public static Task<bool> GetInvincibleAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Invincible);

        [Obsolete("Use async entities instead")]
        public static Task SetInvincibleAsync(this IPlayer player, bool isInvincible) =>
            AltVAsync.Schedule(() => player.Invincible = isInvincible);

        [Obsolete("Use async entities instead")]
        public static Task SetIntoVehicleAsync(this IPlayer player, IVehicle vehicle, byte seat) =>
            AltVAsync.Schedule(() => player.SetIntoVehicle(vehicle, seat));

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsSuperJumpEnabledAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsSuperJumpEnabled);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsCrouchingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsCrouching);

        [Obsolete("Use async entities instead")]
        public static Task<bool> IsStealthyAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsStealthy);

        [Obsolete("Use async entities instead")]
        public static Task PlayAmbientSpeechAsync(this IPlayer player, string speechName, string speechParam, uint speechDictHash) =>
            AltVAsync.Schedule(() => player.PlayAmbientSpeech(speechName, speechParam, speechDictHash));
    }
}