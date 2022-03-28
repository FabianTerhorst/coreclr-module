namespace AltV.Net.Client.Interfaces.Entities
{
    public interface IPlayer : IEntity
    {
        string Name { get; }
        
        int Health { get; }
        int MaxHealth { get; }
        
        bool HasWeaponComponent(uint weaponHash, uint componentHash);
        //TODO: Add virtual Array<uint32_t> GetCurrentWeaponComponents() const = 0;
        
        uint GetWeaponTintIndex(uint weaponHash);
        uint CurrentWeaponTintIndex { get; }
        
        uint CurrentWeapon { get; }
        
        bool IsDead { get; }
        bool IsJumping { get; }
        bool IsInRagdoll { get; }
        bool IsAiming { get; }
        bool IsShooting { get; }
        bool IsReloading { get; }

        uint Armor { get; }
        uint MaxArmor { get; }
        
        float MoveSpeed { get; }
        
        //TODO: Use Position / Vector3
        object AimPos { get; }
        //TODO: Use Position / Vector3
        object HeadRotation { get; }
        
        bool IsInVehicle { get; }
        //TODO: Add virtual Ref<IVehicle> GetVehicle() const = 0;
        uint Seat { get; }
        //TODO: Add virtual Ref<IEntity> GetEntityAimingAt() const = 0;
        object EntityAimOffset { get; }
        
        bool FlashlightActive { get; }
        
        bool IsSuperJumpEnabled { get; }
        bool IsCrouching { get; }
        bool IsStealthy { get; }
        
        bool IsTalking { get; }
        float MicLevel { get; }
        
        float SpatialVolume { get; set; }
        float NonSpatialVolume { get; set; }
        
    }
}