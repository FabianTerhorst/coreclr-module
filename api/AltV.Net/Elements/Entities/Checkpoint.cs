using System;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : ColShape, ICheckpoint
    {
        public IntPtr CheckpointNativePointer { get; }
        public override IntPtr NativePointer => CheckpointNativePointer;

        private static IntPtr GetColShapePointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Checkpoint_GetColShape(nativePointer);
            }
        }

        public static uint GetId(IntPtr pedPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Checkpoint_GetID(pedPointer);
            }
        }

        public byte CheckpointType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_GetCheckpointType(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetCheckpointType(CheckpointNativePointer, value);
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
                    return Core.Library.Shared.Checkpoint_GetHeight(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetHeight(CheckpointNativePointer, value);
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
                    return Core.Library.Shared.Checkpoint_GetRadius(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetRadius(CheckpointNativePointer, value);
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
                    Core.Library.Shared.Checkpoint_GetColor(CheckpointNativePointer, &color);
                    return color;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetColor(CheckpointNativePointer, value);
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
                    Core.Library.Shared.Checkpoint_GetNextPosition(CheckpointNativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetNextPosition(CheckpointNativePointer, value);
                }
            }
        }

        public uint StreamingDistance
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_GetStreamingDistance(CheckpointNativePointer);
                }
            }
        }

        public Checkpoint(ICore core, IntPtr nativePointer, uint id) : base(core, GetColShapePointer(core, nativePointer), BaseObjectType.Checkpoint, id)
        {
            CheckpointNativePointer = nativePointer;
        }

        public bool Visible
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_IsVisible(CheckpointNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetVisible(CheckpointNativePointer, value ? (byte)1:(byte)0);
                }
            }
        }
    }
}