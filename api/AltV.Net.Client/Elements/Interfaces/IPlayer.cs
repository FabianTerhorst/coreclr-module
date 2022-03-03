namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IPlayer : IEntity
    {
        public IntPtr PlayerNativePointer { get; }
        public IVehicle? Vehicle { get; }
        // todo
    }
}