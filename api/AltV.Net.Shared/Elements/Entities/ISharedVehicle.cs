namespace AltV.Net.Shared.Elements.Entities
{
    public interface ISharedVehicle : ISharedEntity
    {
        IntPtr VehicleNativePointer { get; }

        /// <summary>
        /// Amount of Wheels
        /// </summary>
        byte WheelsCount { get; }
    }
}