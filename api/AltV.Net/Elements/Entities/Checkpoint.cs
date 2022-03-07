using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : WorldObject, ICheckpoint
    {
        public IntPtr CheckpointNativePointer { get; }
        public override IntPtr NativePointer => CheckpointNativePointer;
        public IntPtr ColShapeNativePointer => throw new Exception("Checkpoint doesn't have ColShape native pointer");
        
        private static IntPtr GetWorldObjectPointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Server.Checkpoint_GetWorldObject(nativePointer);
            }
        }
        
        public ColShapeType ColShapeType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return (ColShapeType) Core.Library.Server.Checkpoint_GetColShapeType(CheckpointNativePointer);
                }
            }
        }
        
        public bool IsPlayersOnly
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Checkpoint_IsPlayersOnly(CheckpointNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Checkpoint_SetPlayersOnly(CheckpointNativePointer, value ? (byte) 1 : (byte) 0);
                }
            }
        }

        public byte CheckpointType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Checkpoint_GetCheckpointType(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Checkpoint_SetCheckpointType(CheckpointNativePointer, value);
                }
            }
        }

        public float Height
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Checkpoint_GetHeight(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Checkpoint_SetHeight(CheckpointNativePointer, value);
                }
            }
        }

        public float Radius
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Server.Checkpoint_GetRadius(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Checkpoint_SetRadius(CheckpointNativePointer, value);
                }
            }
        }

        public Rgba Color
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var color = Rgba.Zero;
                    Core.Library.Server.Checkpoint_GetColor(CheckpointNativePointer, &color);
                    return color;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Checkpoint_SetColor(CheckpointNativePointer, value);
                }
            }
        }

        public Position NextPosition
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Vector3.Zero;
                    Core.Library.Server.Checkpoint_GetNextPosition(CheckpointNativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Server.Checkpoint_SetNextPosition(CheckpointNativePointer, value);
                }
            }
        }

        public Checkpoint(ICore core, IntPtr nativePointer) : base(core, GetWorldObjectPointer(core, nativePointer), BaseObjectType.Checkpoint)
        {
            CheckpointNativePointer = nativePointer;
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsPlayerIn(IPlayer player)
        {
            Alt.LogWarning("colShape.IsPlayerIn is deprecated, use colShape.IsEntityIn instead");
            return IsEntityIn(player);
        }

        [Obsolete("Use IsEntityIn instead")]
        public bool IsVehicleIn(IVehicle vehicle)
        {
            Alt.LogWarning("colShape.IsVehicleIn is deprecated, use colShape.IsEntityIn instead");
            return IsEntityIn(vehicle);
        }
        
        public bool IsEntityIn(IEntity entity)
        {
            CheckIfEntityExists();
            entity.CheckIfEntityExists();
            
            unsafe
            {
                return Core.Library.Server.Checkpoint_IsEntityIn(CheckpointNativePointer, entity.EntityNativePointer) == 1;
            }
        }
        
        public void Remove()
        {
            Alt.RemoveCheckpoint(this);
        }
    }
}