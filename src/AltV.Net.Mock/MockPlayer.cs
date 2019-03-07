using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockPlayer : MockEntity, IPlayer
    {
        public MockPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, BaseObjectType.Player, id)
        {
        }

        public bool IsConnected { get; }
        public string Name { get; set; }
        public ushort Health { get; set; }
        public bool IsDead { get; set; }
        public bool IsJumping { get; }
        public bool IsInRagdoll { get; }
        public bool IsAiming { get; }
        public bool IsShooting { get; }
        public bool IsReloading { get; }
        public ushort Armor { get; set; }
        public float MoveSpeed { get; }
        public uint Weapon { get; }
        public ushort Ammo { get; }
        public Position AimPosition { get; }
        public Rotation HeadRotation { get; }
        public bool IsInVehicle { get; set; }
        public IVehicle Vehicle { get; set; }
        public byte Seat { get; set; }
        public uint Ping { get; }

        public void Spawn(Position position)
        {
        }

        public void Despawn()
        {
        }

        public void SetDateTime(int day, int month, int year, int hour, int minute, int second)
        {
        }

        public void SetWeather(uint weather)
        {
        }

        public void Kick(string reason)
        {
            if (Exists)
            {
                this.Disconnect(reason);
            }
        }

        public void Emit(string eventName, params object[] args)
        {
            if (Exists)
            {
                Alt.Server.TriggerClientEvent(this, eventName, args);
            }
        }

        public ReadOnlyPlayer Copy()
        {
            return ReadOnlyPlayer.Empty;
        }
    }
}