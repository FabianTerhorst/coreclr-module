namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IVehicle : IEntity
    {
        public IntPtr VehicleNativePointer { get; }
        uint Model { get; }
        // todo
    }
}