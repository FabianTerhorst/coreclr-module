using System.Numerics;
using AltV.Net.Data;

namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedPlayer : ISharedEntity
    {
        IntPtr PlayerNativePointer { get; }
        
        /// <summary>
        /// Returns the current vehicle. Null if not in a vehicle
        /// </summary>
        ISharedVehicle Vehicle { get; }

        /// <summary>
        /// Returns the players alt:V username
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns the World Position of where the player is currently aiming
        /// </summary>
        Position AimPosition { get; }

        /// <summary>
        /// Returns the players current armor
        /// </summary>
        ushort Armor { get; }

        /// <summary>
        /// Returns the current weapon the player has equipped
        /// </summary>
        uint CurrentWeapon { get; }

        Position EntityAimOffset { get; }

        /// <summary>
        /// Returns if the players weapon flashlight or weapon is active (Being aimed)
        /// </summary>
        bool IsFlashlightActive { get; }

        /// <summary>
        /// The current rotation of the players head
        /// </summary>
        Rotation HeadRotation { get; }

        /// <summary>
        /// Gets and Sets the players health
        /// </summary>
        ushort Health { get; }

        /// <summary>
        /// Returns if the player is aiming.
        /// </summary>
        bool IsAiming { get; }

        /// <summary>
        /// Returns if the player is dead. True = player is dead
        /// </summary>
        bool IsDead { get; }

        /// <summary>
        /// Returns if the player is currently in RagDoll state.
        /// </summary>
        bool IsInRagdoll { get; }
        
        /// <summary>
        /// Returns if the player is in a vehicle
        /// </summary>
        bool IsInVehicle { get; }

        /// <summary>
        /// Returns if the player is reloading
        /// </summary>
        bool IsReloading { get; }

        /// <summary>
        /// Returns the max armor for the player
        /// </summary>
        ushort MaxArmor { get; }

        /// <summary>
        /// Gets and Sets the players max health
        /// </summary>
        ushort MaxHealth { get; }

        /// <summary>
        /// Gets the current movement speed of the player in m/s
        /// </summary>
        float MoveSpeed { get; }
        
        float ForwardSpeed { get; }
        
        float StrafeSpeed { get; }

        /// <summary>
        /// Returns the current seat the player is in. Drivers = 1
        /// </summary>
        byte Seat { get; }

        /// <summary>
        /// Returns if the player is spawned
        /// </summary>
        bool IsSpawned { get; }

        /// <summary>
        /// Returns player's current animation dictionary hash
        /// </summary>
        uint CurrentAnimationDict { get; }

        /// <summary>
        /// Returns player's current animation name hash
        /// </summary>
        uint CurrentAnimationName { get; }

        /// <summary>
        /// Returns the IEntity object if the player is aiming at
        /// </summary>
        ISharedEntity EntityAimingAt { get; }
        
        uint InteriorLocation { get; }

        /// <summary>
        /// Gets the current weapon components for the weapon in hand
        /// </summary>
        /// <param name="weaponComponents">Array of component hashes</param>
        void GetCurrentWeaponComponents(out uint[] weaponComponents);
    }
}