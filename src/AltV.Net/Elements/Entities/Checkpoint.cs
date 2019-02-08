using System;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : Entity, ICheckpoint
    {
        public Checkpoint(IntPtr nativePointer) : base(nativePointer, EntityType.Checkpoint)
        {
        }
    }
}