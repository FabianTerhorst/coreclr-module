using System.Numerics;
using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IPlayer : IEntity
    {
        public IntPtr PlayerNativePointer { get; }
        public IVehicle? Vehicle { get; }
        string Name { get; }
        Vector3 AimPos { get; }
        ushort Armour { get; }
        uint CurrentWeapon { get; }
        Vector3 EntityAimOffset { get; }
        bool IsFlashlightActive { get; }
        Rotation HeadRot { get; }
        ushort Health { get; }
        bool IsAiming { get; }
        bool IsDead { get; }
        bool IsInRagdoll { get; }
        bool IsReloading { get; }
        bool IsTalking { get; }
        ushort MaxArmour { get; }
        ushort MaxHealth { get; }
        float MicLevel { get; }
        float MoveSpeed { get; }
        float NonSpatialVolume { get; set; }
        byte Seat { get; }
        float SpatialVolume { get; set; }
        bool IsLocal { get; }
        IEntity? EntityAimingAt { get; }
        uint[] CurrentWeaponComponents { get; }
        // todo
    }
}