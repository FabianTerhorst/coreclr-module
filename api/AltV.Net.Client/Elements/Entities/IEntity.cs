namespace AltV.Net.Client.Elements.Entities
{
    public interface IEntity : IWorldObject
    {
        public IntPtr NativePointer { get; }
        public ushort Id { get; }
        public bool Exists { get; }
    }
}