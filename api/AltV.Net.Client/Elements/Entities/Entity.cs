using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Entities
{
    public class Entity : WorldObject, IEntity
    {
        private static IntPtr GetWorldObjectPointer(ICore core, IntPtr entityPointer)
        {
            unsafe
            {
                return core.Library.Entity_GetWorldObject(entityPointer);
            }
        }
        
        public IntPtr EntityNativePointer { get; }
        
        public Entity(ICore core, IntPtr entityPointer, ushort id) : base(core, GetWorldObjectPointer(core, entityPointer))
        {
            Id = id;
            EntityNativePointer = entityPointer;
        }

        public ushort Id { get; }
        public bool Exists => true; // todo
    }
}