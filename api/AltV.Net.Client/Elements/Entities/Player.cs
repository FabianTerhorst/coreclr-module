using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;

namespace AltV.Net.Client.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        private static IntPtr GetEntityPointer(ICore core, IntPtr playerNativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Player_GetEntity(playerNativePointer);
            }
        }
        
        public IntPtr PlayerNativePointer { get; }
        
        public Player(ICore core, IntPtr playerPointer, ushort id) : base(core, GetEntityPointer(core, playerPointer), id)
        {
            PlayerNativePointer = playerPointer;
        }
        
        public virtual bool IsLocal => false;

        public IVehicle? Vehicle
        {
            get
            {
                unsafe
                {
                    var ptr = Core.Library.Shared.Player_GetVehicle(PlayerNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    
                    return Alt.Core.VehiclePool.Get(ptr);
                }
            }
        }

        public string Name
        {
            get
            {
                unsafe
                {
                    int size = 0;
                    var str = Alt.Core.Library.Shared.Player_GetName(this.PlayerNativePointer, &size);
                    var stringResult = Marshal.PtrToStringUTF8(str, size);
                    Core.Library.Shared.FreeString(str);
                    return stringResult;
                }
            }
        }

        public Vector3 AimPos
        {
            get
            {
                unsafe
                {
                    var position = Vector3.Zero;
                    this.Core.Library.Shared.Player_GetAimPos(this.PlayerNativePointer, &position);
                    return position;
                }
            }
        }

        public ushort Armour
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_GetArmor(this.PlayerNativePointer);
                }
            }
        }
        
        public uint CurrentWeapon
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_GetCurrentWeapon(this.PlayerNativePointer);
                }
            }
        }
        
        public uint[] CurrentWeaponComponents
        {
            get
            {
                unsafe
                {
                    var array = UIntArray.Nil;
                    Core.Library.Shared.Player_GetCurrentWeaponComponents(PlayerNativePointer, &array);
                    var components = array.ToArray();
                    Core.Library.Shared.FreeUIntArray(&array);
                    return components;
                }
            }
        }

        public Vector3 EntityAimOffset
        {
            get
            {
                unsafe
                {
                    var position = Vector3.Zero;
                    this.Core.Library.Shared.Player_GetEntityAimOffset(this.PlayerNativePointer, &position);
                    return position;                    
                }
            }
        }
        
        public IEntity? EntityAimingAt
        {
            get
            {
                unsafe
                {
                    // ushort id = 0;
                    // var success = this.Core.Library.Player_GetEntityAimingAtID(this.PlayerNativePointer, &id);
                    // if (success == 0) return null;
                    //
                    // if (!Alt.Module.GetEntityById(id, out var entity)) return null;
                    // return entity;
                    // todo
                    return null;
                }
            }
        }
        
        public bool IsFlashlightActive
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_IsFlashlightActive(this.PlayerNativePointer) == 1;
                }
            }
        }
        
        public Rotation HeadRot
        {
            get
            {
                unsafe
                {
                    var position = Rotation.Zero;
                    this.Core.Library.Shared.Player_GetHeadRotation(this.PlayerNativePointer, &position);
                    return position;
                }
            }
        }
        
        public ushort Health
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_GetHealth(this.PlayerNativePointer);
                }
            }
        }
        
        public bool IsAiming
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_IsAiming(this.PlayerNativePointer) == 1;
                }
            }
        }
        
        public bool IsDead
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_IsDead(this.PlayerNativePointer) == 1;
                }
            }
        }
        
        public bool IsInRagdoll
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_IsInRagdoll(this.PlayerNativePointer) == 1;
                }
            }
        }
        
        public bool IsReloading
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_IsReloading(this.PlayerNativePointer) == 1;
                }
            }
        }
        
        public bool IsTalking
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Client.Player_IsTalking(this.PlayerNativePointer) == 1;
                }
            }
        }
        
        public ushort MaxArmour
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_GetMaxArmor(this.PlayerNativePointer);
                }
            }
        }
        
        public ushort MaxHealth
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_GetMaxHealth(this.PlayerNativePointer);
                }
            }
        }
        
        public float MicLevel
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Client.Player_GetMicLevel(this.PlayerNativePointer);
                }
            }
        }
        
        public float MoveSpeed
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_GetMoveSpeed(this.PlayerNativePointer);
                }
            }
        }
        
        public float NonSpatialVolume
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Client.Player_GetNonSpatialVolume(this.PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    this.Core.Library.Client.Player_SetNonSpatialVolume(this.PlayerNativePointer, value);
                }
            }
        }
        
        public byte Seat
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Shared.Player_GetSeat(this.PlayerNativePointer);
                }
            }
        }
        
        public float SpatialVolume
        {
            get
            {
                unsafe
                {
                    return this.Core.Library.Client.Player_GetSpatialVolume(this.PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    this.Core.Library.Client.Player_SetSpatialVolume(this.PlayerNativePointer, value);
                }
            }
        }
        
    }
}