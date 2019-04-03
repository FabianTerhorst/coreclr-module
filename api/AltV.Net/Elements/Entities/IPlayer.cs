using System;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public interface IPlayer : IEntity
    {
        new uint Model { get; set; }

        bool IsConnected { get; }

        string Name { get; set; }

        ushort Health { get; set; }

        bool IsDead { get; }

        bool IsJumping { get; }

        bool IsInRagdoll { get; }

        bool IsAiming { get; }

        bool IsShooting { get; }

        bool IsReloading { get; }

        ushort Armor { get; set; }

        float MoveSpeed { get; }

        uint Weapon { get; }

        ushort Ammo { get; }

        Position AimPosition { get; }

        Rotation HeadRotation { get; }

        bool IsInVehicle { get; }

        IVehicle Vehicle { get; }

        /**
         * The current vehicle seat
         * driver: 1
         */
        byte Seat { get; }

        uint Ping { get; }

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

        void Kick(string reason);

        void Emit(string eventName, params object[] args);

        ReadOnlyPlayer Copy();
    }

    public static class PlayerExtensions
    {
        public static void SetDateTime(this IPlayer player, DateTime dateTime) => player.SetDateTime(dateTime.Day,
            dateTime.Month, dateTime.Year, dateTime.Hour, dateTime.Minute, dateTime.Second);
    }
}