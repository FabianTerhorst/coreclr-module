using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public interface IPlayer : IEntity
    {
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

        byte Seat { get; }
        
        uint Ping { get; }

        void Spawn(Position position);

        void Despawn();

        void SetDateTime(int day, int month, int year, int hour,
            int minute, int second);

        void SetWeather(uint weather);

        void Kick(string reason);

        void Emit(string eventName, params object[] args);

        ReadOnlyPlayer Copy();
    }
}