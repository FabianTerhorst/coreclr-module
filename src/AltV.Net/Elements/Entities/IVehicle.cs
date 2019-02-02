namespace AltV.Net.Elements.Entities
{
    public interface IVehicle : IEntity
    {
        /// <summary>
        /// Get the current driver of the vehicle
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        IPlayer Driver { get; }

        /// <summary>
        /// Get or set primary color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        byte PrimaryColor { get; set; }
    }
}