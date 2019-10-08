using System;
using AltV.Net.Data;
using AltV.Net.Enums;

namespace AltV.Net.Elements.Entities
{
    public interface IPlayer : IEntity
    {
        /// <summary>
        /// The players model / skin
        /// </summary>
        new uint Model { get; set; }

        /// <summary>
        /// Returns true if player is connected - false if not connected
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Returns the players alt:V username
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns the players Social Club ID
        /// </summary>
        ulong SocialClubId { get; }

        /// <summary>
        /// Returns the players Hardware ID Hash
        /// </summary>
        ulong HardwareIdHash { get; }

        ulong HardwareIdExHash { get; }

        string AuthToken { get; }

        /// <summary>
        /// Gets and Sets the players health
        /// </summary>
        ushort Health { get; set; }

        /// <summary>
        /// Gets and Sets the players max health
        /// </summary>
        ushort MaxHealth { get; set; }

        /// <summary>
        /// Returns if the player is dead. True = player is dead
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Returns if the player is jumping. True = player jumping
        /// </summary>
        bool IsJumping { get; }

        /// <summary>
        /// Returns if the player is currently in RagDoll state.
        /// </summary>
        bool IsInRagdoll { get; }

        /// <summary>
        /// Returns if the player is aiming.
        /// </summary>
        bool IsAiming { get; }

        /// <summary>
        /// Returns if the player is firing.
        /// </summary>
        bool IsShooting { get; }

        /// <summary>
        /// Returns if the player is reloading
        /// </summary>
        bool IsReloading { get; }

        /// <summary>
        /// Sets and returns the players current armor
        /// </summary>
        ushort Armor { get; set; }

        /// <summary>
        /// Sets and returns the max armor for the player
        /// </summary>
        ushort MaxArmor { get; set; }

        /// <summary>
        /// Gets the current movement speed of the player in m/s
        /// </summary>
        float MoveSpeed { get; }

        /// <summary>
        /// Returns the current weapon the player is holding
        /// </summary>
        uint Weapon { get; }

        /// <summary>
        /// Returns the ammo in the current weapon the player is holding
        /// </summary>
        ushort Ammo { get; }

        /// <summary>
        /// Returns the World Position of where the player is currently aiming
        /// </summary>
        Position AimPosition { get; }

        /// <summary>
        /// The current rotation of the players head
        /// </summary>
        Rotation HeadRotation { get; }

        /// <summary>
        /// Returns if the player is in a vehicle
        /// </summary>
        bool IsInVehicle { get; }

        /// <summary>
        /// Returns the current vehicle. Null if not in a vehicle
        /// </summary>
        IVehicle Vehicle { get; }

        /// <summary>
        /// Returns the current weapon the player has equipped
        /// </summary>
        uint CurrentWeapon { get; set; }

        /// <summary>
        /// Returns the IEntity object if the player is aiming at
        /// </summary>
        IEntity EntityAimingAt { get; }

        Position EntityAimOffset { get; }

        /// <summary>
        /// Returns if the players weapon flashlight or weapon is active (Being aimed)
        /// </summary>
        bool IsFlashlightActive { get; }

        /// <summary>
        /// Returns the current seat the player is in. Drivers = 1
        /// </summary>
        byte Seat { get; }

        /// <summary>
        /// Returns the current ping of the player
        /// </summary>
        uint Ping { get; }

        /// <summary>
        /// Returns the IP of the player
        /// </summary>
        string Ip { get; }

        /// <summary>
        /// Spawns a player at the designated position with a optional delay in milliseconds
        /// </summary>
        /// <param name="position">position</param>
        /// <param name="delayMs">delay in milliseconds until player is spawned</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void Spawn(Position position, uint delayMs = 0);

        /// <summary>
        /// Despawns a player
        /// </summary>
        void Despawn();

        /// <summary>
        /// Sets the current date and time for a player
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        void SetDateTime(int day, int month, int year, int hour,
            int minute, int second);

        /// <summary>
        /// Sets the current weather for the player
        /// </summary>
        /// <param name="weather"></param>
        void SetWeather(uint weather);

        /// <summary>
        /// Gives the player a weapon, ammo and if it is active
        /// </summary>
        /// <param name="weapon">weapon hash</param>
        /// <param name="ammo">ammo count</param>
        /// <param name="selectWeapon">True - Places into hand</param>
        void GiveWeapon(uint weapon, int ammo, bool selectWeapon);

        /// <summary>
        /// Removes the weapon by hash
        /// </summary>
        /// <param name="weapon"></param>
        void RemoveWeapon(uint weapon);

        /// <summary>
        /// Removes all player weapons
        /// </summary>
        void RemoveAllWeapons();

        /// <summary>
        /// Kicks the player with reason
        /// </summary>
        /// <param name="reason">Reason why the player is kicked</param>
        void Kick(string reason);

        /// <summary>
        /// Triggers client side event for a player
        /// </summary>
        /// <param name="eventName">Event Trigger</param>
        /// <param name="args">Parameters</param>
        void Emit(string eventName, params object[] args);

        /// <summary>
        /// Adds a weapon component to a weapon
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        /// <param name="weaponComponent">Weapon Component hash</param>
        void AddWeaponComponent(uint weapon, uint weaponComponent);

        /// <summary>
        /// Removes a weapon component from a weapon
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        /// <param name="weaponComponent">Weapon Component hash</param>
        void RemoveWeaponComponent(uint weapon, uint weaponComponent);

        /// <summary>
        /// Gets the current weapon components for the weapon in hand
        /// </summary>
        /// <param name="weaponComponents">Array of component hashes</param>
        void GetCurrentWeaponComponents(out uint[] weaponComponents);

        /// <summary>
        /// Sets the weapon tint to a weapon
        /// </summary>
        /// <param name="weapon">Weapon hash</param>
        /// <param name="tintIndex">tintIndex</param>
        void SetWeaponTintIndex(uint weapon, byte tintIndex);

        /// <summary>
        /// Returns weapon tint of current weapon
        /// </summary>
        /// <returns></returns>
        byte GetCurrentWeaponTintIndex();

        ReadOnlyPlayer Copy();
    }

    public static class PlayerExtensions
    {
        /// <summary>
        /// Sets the players current Date and Time
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="dateTime">The DateTime object</param>
        public static void SetDateTime(this IPlayer player, DateTime dateTime) => player.SetDateTime(dateTime.Day,
            dateTime.Month, dateTime.Year, dateTime.Hour, dateTime.Minute, dateTime.Second);

        /// <summary>
        /// Sets the players current weather
        /// </summary>
        /// <param name="player">The Player</param>
        /// <param name="weatherType">The weather type</param>
        public static void SetWeather(this IPlayer player, WeatherType weatherType) =>
            player.SetWeather((uint) weatherType);

        /// <summary>
        /// Adds a weapon component to model
        /// </summary>
        /// <param name="player">The Player</param>
        /// <param name="weaponModel">The Weapon</param>
        /// <param name="weaponComponent">The Component</param>
        public static void AddWeaponComponent(this IPlayer player, WeaponModel weaponModel, uint weaponComponent) =>
            player.AddWeaponComponent((uint) weaponModel, weaponComponent);

        /// <summary>
        /// Removes a weapon component from model
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="weaponModel">The weapon</param>
        /// <param name="weaponComponent">The component to be removed</param>
        public static void RemoveWeaponComponent(this IPlayer player, WeaponModel weaponModel, uint weaponComponent) =>
            player.RemoveWeaponComponent((uint) weaponModel, weaponComponent);

        /// <summary>
        /// Sets the weapon tint to a weapon
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="weaponModel">The weapon</param>
        /// <param name="tintIndex">The tint index</param>
        public static void SetWeaponTintIndex(this IPlayer player, WeaponModel weaponModel, byte tintIndex) =>
            player.SetWeaponTintIndex((uint) weaponModel, tintIndex);

        /// <summary>
        /// Gives player a weapon
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="weaponModel">The weapon</param>
        /// <param name="ammo">The amount of ammo</param>
        /// <param name="selectWeapon">If the weapon is selected automatically</param>
        public static void GiveWeapon(this IPlayer player, WeaponModel weaponModel, int ammo, bool selectWeapon) =>
            player.GiveWeapon((uint) weaponModel, ammo, selectWeapon);

        /// <summary>
        /// Removes the specific weapon from the player
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="weaponModel">The weapon to remove</param>
        public static void RemoveWeapon(this IPlayer player, WeaponModel weaponModel) =>
            player.RemoveWeapon((uint) weaponModel);
    }
}