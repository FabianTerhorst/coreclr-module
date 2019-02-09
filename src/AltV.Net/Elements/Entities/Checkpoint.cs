using System;
using AltV.Net.Data;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : Entity, ICheckpoint
    {
        public bool IsGlobal => Exists && AltVNative.Checkpoint.Checkpoint_IsGlobal(NativePointer);
        public byte CheckpointType => !Exists ? default : AltVNative.Checkpoint.Checkpoint_GetType(NativePointer);
        public float Height => !Exists ? default : AltVNative.Checkpoint.Checkpoint_GetHeight(NativePointer);
        public float Radius => !Exists ? default : AltVNative.Checkpoint.Checkpoint_GetRadius(NativePointer);
        public Rgba Color => !Exists ? Rgba.Zero : AltVNative.Checkpoint.Checkpoint_GetColor(NativePointer);

        public Checkpoint(IntPtr nativePointer) : base(nativePointer, EntityType.Checkpoint)
        {
        }
    }
}