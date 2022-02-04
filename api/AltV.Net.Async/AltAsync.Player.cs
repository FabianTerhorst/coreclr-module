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
        public static Task<bool> IsConnectedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsConnected);

        public static Task SetModelAsync(this IPlayer player, uint model) =>
            AltVAsync.Schedule(() => player.Model = model);

        public static async Task<string> GetNameAsync(this IPlayer player) => await AltVAsync.Schedule(
                () => player.Name);

        public static Task<ushort> GetHealthAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Health);

        public static Task SetHealthAsync(this IPlayer player, ushort health) =>
            AltVAsync.Schedule(() => player.Health = health);

        public static Task<bool> IsDeadAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsDead);

        public static Task<bool> IsJumpingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsJumping);

        public static Task<bool> IsInRagdollAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsInRagdoll);

        public static Task<bool> IsAimingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsAiming);

        public static Task<bool> IsShootingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsShooting);

        public static Task<bool> IsReloadingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsReloading);

        public static Task<ushort> GetArmorAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Armor);

        public static Task SetArmorAsync(this IPlayer player, ushort armor) =>
            AltVAsync.Schedule(() => player.Armor = armor);

        public static Task<float> GetMoveSpeedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.MoveSpeed);

        public static Task<Position> GetAimPositionAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.AimPosition);

        public static Task<Rotation> GetHeadRotationAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.HeadRotation);

        public static Task<bool> IsInVehicleAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsInVehicle);

        public static async Task<IVehicle> GetVehicleAsync(this IPlayer player)
        {
            return await AltVAsync.Schedule(() =>
                {
                    unsafe
                    {
                        player.CheckIfEntityExists();
                        var vehiclePtr = Alt.Server.Library.Player_GetVehicle(player.NativePointer);
                        return Alt.Module.VehiclePool.Get(vehiclePtr, out var vehicle) ? vehicle : null;
                    }
                });
        }

        public static Task<byte> GetSeatAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Seat);

        public static Task<uint> GetPingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Ping);

        public static Task SpawnAsync(this IPlayer player, Position position, uint delayMs = 0) =>
            AltVAsync.Schedule(() => player.Spawn(position, delayMs));

        public static Task DespawnAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.Despawn);

        public static Task SetDateTimeAsync(this IPlayer player, int day, int month, int year, int hour,
            int minute, int second) =>
            AltVAsync.Schedule(() => player.SetDateTime(day, month, year, hour, minute, second));

        public static Task SetDateTimeAsync(this IPlayer player, DateTime dateTime) =>
            AltVAsync.Schedule(() => player.SetDateTime(dateTime));

        public static Task SetWeatherAsync(this IPlayer player, uint weather) =>
            AltVAsync.Schedule(() => player.SetWeather(weather));

        public static Task GiveWeaponAsync(this IPlayer player, uint weapon, int ammo, bool selectWeapon) =>
            AltVAsync.Schedule(() => player.GiveWeapon(weapon, ammo, selectWeapon));

        public static Task RemoveWeaponAsync(this IPlayer player, uint weapon) =>
            AltVAsync.Schedule(() => player.RemoveWeapon(weapon));

        public static Task RemoveAllWeaponsAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.RemoveAllWeapons);

        public static Task SetMaxHealthAsync(this IPlayer player, ushort maxhealth) =>
            AltVAsync.Schedule(() => player.MaxHealth = maxhealth);

        public static Task SetMaxArmorAsync(this IPlayer player, ushort maxarmor) =>
            AltVAsync.Schedule(() => player.MaxArmor = maxarmor);

        public static Task SetCurrentWeaponAsync(this IPlayer player, uint weapon) =>
            AltVAsync.Schedule(() => player.CurrentWeapon = weapon);

        public static async Task KickAsync(this IPlayer player, string reason)
        {
            var reasonPtr = AltNative.StringUtils.StringToHGlobalUtf8(reason);
            await AltVAsync.Schedule(() =>
            {
                unsafe
                {
                    player.CheckIfEntityExists();
                    Alt.Server.Library.Player_Kick(player.NativePointer, reasonPtr);
                }
            });
            Marshal.FreeHGlobal(reasonPtr);
        }

        public static async Task EmitAsync(this IPlayer player, string eventName, params object[] args)
        {
            var size = args.Length;
            var mValues = new MValueConst[size];
            Alt.Server.CreateMValues(mValues, args);
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            await AltVAsync.Schedule(() =>
            {
                player.CheckIfEntityExists();
                Alt.Server.TriggerClientEvent(player, eventNamePtr, mValues);
            });
            Marshal.FreeHGlobal(eventNamePtr);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public static Task<bool> GetVisibleAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Visible);

        public static Task SetVisibleAsync(this IPlayer player, bool visibility) =>
            AltVAsync.Schedule(() => player.Visible = visibility);

        public static Task<bool> GetStreamedAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Streamed);

        public static Task SetStreamedAsync(this IPlayer player, bool isStreamed) =>
            AltVAsync.Schedule(() => player.Streamed = isStreamed);

        public static Task<string> GetAuthTokenAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.AuthToken);

        public static Task<uint> GetCurrentWeaponAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.CurrentWeapon);

        public static Task<IEntity> GetEntityAimingAtAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.EntityAimingAt);

        public static Task<Position> GetEntityAimOffsetAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.EntityAimOffset);

        public static Task<ulong> GetHardwareIdHashAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.HardwareIdHash);

        public static Task<ulong> GetHardwareIdExHashAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.HardwareIdExHash);

        public static Task<string> GetIpAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Ip);

        public static Task<bool> IsFlashlightActiveAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsFlashlightActive);

        public static Task<ushort> GetMaxArmorAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.MaxArmor);

        public static Task<ushort> GetMaxHealthAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.MaxHealth);

        public static Task<ulong> GetSocialClubIdAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.SocialClubId);

        public static Task AddWeaponComponentAsync(this IPlayer player, uint weapon, uint weaponComponent) =>
            AltVAsync.Schedule(() => player.AddWeaponComponent(weapon, weaponComponent));

        public static Task AddWeaponComponentAsync(this IPlayer player, WeaponModel weaponModel, uint weaponComponent) =>
            AltVAsync.Schedule(() => player.AddWeaponComponent(weaponModel, weaponComponent));

        public static Task AttachToEntityAsync(this IPlayer player, IEntity entity, short otherBone, short ownBone,
            Position position, Rotation rotation, bool collision, bool noFixedRotation) =>
            AltVAsync.Schedule(() =>
                player.AttachToEntity(entity, otherBone, ownBone, position, rotation, collision, noFixedRotation));

        public static Task ClearBloodDamageAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.ClearBloodDamage);

        public static Task ClearPropsAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.ClearProps(component));

        public static Task DetachAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.Detach);

        public static Task<Cloth> GetClothesAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetClothes(component));

        public static Task<byte> GetCurrentWeaponTintIndexAsync(this IPlayer player) =>
            AltVAsync.Schedule(player.GetCurrentWeaponTintIndex);

        public static Task<DlcCloth> GetDlcClothesAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetDlcClothes(component));

        public static Task<DlcProp> GetDlcPropsAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetDlcProps(component));

        public static Task<Prop> GetPropsAsync(this IPlayer player, byte component) =>
            AltVAsync.Schedule(() => player.GetProps(component));

        public static Task<byte> GetWeaponTintIndexAsync(this IPlayer player, uint weapon) =>
            AltVAsync.Schedule(() => player.GetWeaponTintIndex(weapon));

        public static Task<bool> IsEntityInStreamingRangeAsync(this IPlayer player, IEntity entity) =>
            AltVAsync.Schedule(() => player.IsEntityInStreamingRange(entity));

        public static Task RemoveWeaponComponentAsync(this IPlayer player, uint weapon, uint weaponComponent) =>
            AltVAsync.Schedule(() => player.RemoveWeaponComponent(weapon, weaponComponent));

        public static Task SetClothesAsync(this IPlayer player, byte component, ushort drawable, byte texture,
            byte palette) =>
            AltVAsync.Schedule(() => player.SetClothes(component, drawable, texture, palette));

        public static Task SetDlcClothesAsync(this IPlayer player, byte component, ushort drawable, byte texture,
            byte palette, uint dlc) =>
            AltVAsync.Schedule(() => player.SetDlcClothes(component, drawable, texture, palette, dlc));

        public static Task SetPropsAsync(this IPlayer player, byte component, ushort drawable, byte texture) =>
            AltVAsync.Schedule(() => player.SetProps(component, drawable, texture));

        public static Task SetDlcPropsAsync(this IPlayer player, byte component, ushort drawable, byte texture,
            uint dlc) =>
            AltVAsync.Schedule(() => player.SetDlcProps(component, drawable, texture, dlc));

        public static Task SetWeaponTintIndexAsync(this IPlayer player, uint weapon, byte tintIndex) =>
            AltVAsync.Schedule(() => player.SetWeaponTintIndex(weapon, tintIndex));

        public static Task SetWeaponTintIndexAsync(this IPlayer player, WeaponModel weaponModel, byte tintIndex) =>
            AltVAsync.Schedule(() => player.SetWeaponTintIndex(weaponModel, tintIndex));

        public static Task<bool> GetInvincibleAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.Invincible);

        public static Task SetInvincibleAsync(this IPlayer player, bool isInvincible) =>
            AltVAsync.Schedule(() => player.Invincible = isInvincible);

        public static Task SetIntoVehicleAsync(this IPlayer player, IVehicle vehicle, byte seat) =>
            AltVAsync.Schedule(() => player.SetIntoVehicle(vehicle, seat));

        public static Task<bool> IsSuperJumpEnabledAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsSuperJumpEnabled);

        public static Task<bool> IsCrouchingAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsCrouching);

        public static Task<bool> IsStealthyAsync(this IPlayer player) =>
            AltVAsync.Schedule(() => player.IsStealthy);

        public static Task PlayAmbientSpeechAsync(this IPlayer player, string speechName, string speechParam, uint speechDictHash) =>
            AltVAsync.Schedule(() => player.PlayAmbientSpeech(speechName, speechParam, speechDictHash));
    }
}