using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IEntity : IWorldObject
    {
        public IntPtr EntityNativePointer { get; }
        public ushort Id { get; }
        public bool Exists { get; }
    }
}