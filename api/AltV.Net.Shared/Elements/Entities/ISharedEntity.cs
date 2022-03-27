namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedEntity : ISharedWorldObject
    {
        IntPtr EntityNativePointer { get; }
        
        /// <summary>
        /// Get the entity id.
        /// </summary>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        ushort Id { get; }
    }
}