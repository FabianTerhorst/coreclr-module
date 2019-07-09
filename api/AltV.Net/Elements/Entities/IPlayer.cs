using System;
using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface IPlayer : IEntity
    {
        new uint Model { get; set; }

        bool IsConnected { get; }

        string Name { get; }
        
        ulong SocialClubId { get; }
        
        ulong HardwareIdHash { get; }
        
        ulong HardwareIdExHash { get; }
        
        string AuthToken { get; }

        ushort Health { get; set; }
        
        ushort MaxHealth { get; set; }

        bool IsDead { get; }

        bool IsJumping { get; }

        bool IsInRagdoll { get; }

        bool IsAiming { get; }

        bool IsShooting { get; }

        bool IsReloading { get; }

        ushort Armor { get; set; }
        
        ushort MaxArmor { get; set; }

        float MoveSpeed { get; }

        uint Weapon { get; }

        ushort Ammo { get; }

        Position AimPosition { get; }

        Rotation HeadRotation { get; }

        bool IsInVehicle { get; }

        IVehicle Vehicle { get; }
        
        uint CurrentWeapon { get; set; }
        
        IEntity EntityAimingAt { get; }
        
        Position EntityAimOffset { get; }
        
        bool IsFlashlightActive { get; }


        /**
         * The current vehicle seat
         * driver: 1
         */
        byte Seat { get; }

        uint Ping { get; }
        
        string Ip { get; }

        /// <summary>
        /// Spawns a player at the designated position with a optional delay in milliseconds
        /// </summary>
        /// <param name="position">position</param>
        /// <param name="delayMs">delay in milliseconds until player is spawned</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void Spawn(Position position, uint delayMs = 0);

        void Despawn();

        void SetDateTime(int day, int month, int year, int hour,
            int minute, int second);

        void SetWeather(uint weather);

        void GiveWeapon(uint weapon, int ammo, bool selectWeapon);

        void RemoveWeapon(uint weapon);

        void RemoveAllWeapons();

        void Kick(string reason);

        void Emit(string eventName, params object[] args);

        void AddWeaponComponent(uint weapon, uint weaponComponent);
        
        void RemoveWeaponComponent(uint weapon, uint weaponComponent);

        void GetCurrentWeaponComponents(out uint[] weaponComponents);

        void SetWeaponTintIndex(uint weapon, byte tintIndex);

        byte GetCurrentWeaponTintIndex();

        ReadOnlyPlayer Copy();
    }

    public static class PlayerExtensions
    {
        public static void SetDateTime(this IPlayer player, DateTime dateTime) => player.SetDateTime(dateTime.Day,
            dateTime.Month, dateTime.Year, dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
}