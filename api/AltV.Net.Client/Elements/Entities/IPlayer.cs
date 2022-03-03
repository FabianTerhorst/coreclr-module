using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IPlayer : IEntity
    {
        public IntPtr PlayerNativePointer { get; }
        public IVehicle? Vehicle { get; }
        // todo
    }
}