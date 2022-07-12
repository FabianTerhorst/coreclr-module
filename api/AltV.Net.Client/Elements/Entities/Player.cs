using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

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
        public override IntPtr NativePointer => PlayerNativePointer;

        public Player(ICore core, IntPtr playerPointer, ushort id) : base(core, GetEntityPointer(core, playerPointer), id, BaseObjectType.Player)
        {
            PlayerNativePointer = playerPointer;
        }

        public Player(ICore core, IntPtr playerPointer, ushort id, BaseObjectType baseObjectType) : base(core, GetEntityPointer(core, playerPointer), id, baseObjectType)
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
                    CheckIfEntityExists();
                    var ptr = Core.Library.Shared.Player_GetVehicle(PlayerNativePointer);
                    if (ptr == IntPtr.Zero) return null;

                    return Alt.Core.VehiclePool.Get(ptr);
                }
            }
        }
        ISharedVehicle ISharedPlayer.Vehicle => Vehicle!;

        public bool IsInVehicle
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_IsInVehicle(PlayerNativePointer) == 1;
                }
            }
        }

        public string Name
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    int size = 0;
                    var str = Alt.Core.Library.Shared.Player_GetName(this.PlayerNativePointer, &size);
                    var stringResult = Marshal.PtrToStringUTF8(str, size);
                    Core.Library.Shared.FreeString(str);
                    return stringResult;
                }
            }
        }

        public Position AimPosition
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Vector3.Zero;
                    this.Core.Library.Shared.Player_GetAimPos(this.PlayerNativePointer, &position);
                    return position;
                }
            }
        }

        public ushort Armor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    return this.Core.Library.Shared.Player_GetCurrentWeapon(this.PlayerNativePointer);
                }
            }
        }

        public Position EntityAimOffset
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    BaseObjectType type = BaseObjectType.Undefined;
                    var ptr = this.Core.Library.Shared.Player_GetEntityAimingAt(this.PlayerNativePointer, &type);
                    if (ptr == IntPtr.Zero) return null;

                    if (!Core.BaseEntityPool.Get(ptr, type, out var entity)) return null;
                    return entity;
                }
            }
        }

        public void GetCurrentWeaponComponents(out uint[] weaponComponents)
        {
            unsafe
            {
                CheckIfEntityExists();
                var array = UIntArray.Nil;
                Core.Library.Shared.Player_GetCurrentWeaponComponents(PlayerNativePointer, &array);
                weaponComponents = array.ToArray();
                Core.Library.Shared.FreeUIntArray(&array);
            }
        }

        ISharedEntity ISharedPlayer.EntityAimingAt => EntityAimingAt!;

        public bool IsFlashlightActive
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return this.Core.Library.Shared.Player_IsFlashlightActive(this.PlayerNativePointer) == 1;
                }
            }
        }

        public Rotation HeadRotation
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    return this.Core.Library.Client.Player_IsTalking(this.PlayerNativePointer) == 1;
                }
            }
        }

        public ushort MaxArmor
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    return this.Core.Library.Shared.Player_GetMoveSpeed(this.PlayerNativePointer);
                }
            }
        }

        public float ForwardSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return this.Core.Library.Shared.Player_GetForwardSpeed(this.PlayerNativePointer);
                }
            }
        }

        public float StrafeSpeed
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return this.Core.Library.Shared.Player_GetStrafeSpeed(this.PlayerNativePointer);
                }
            }
        }

        public float NonSpatialVolume
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return this.Core.Library.Client.Player_GetNonSpatialVolume(this.PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    return this.Core.Library.Client.Player_GetSpatialVolume(this.PlayerNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    this.Core.Library.Client.Player_SetSpatialVolume(this.PlayerNativePointer, value);
                }
            }
        }
        
        public bool IsSpawned
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_IsSpawned(PlayerNativePointer) == 1;
                }
            }
        }

        public uint CurrentAnimationDict
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_GetCurrentAnimationDict(PlayerNativePointer);
                }
            }
        }

        public uint CurrentAnimationName
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Player_GetCurrentAnimationName(PlayerNativePointer);
                }
            }
        }

    }
}