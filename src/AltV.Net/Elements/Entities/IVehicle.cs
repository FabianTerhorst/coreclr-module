using System;
using System.Collections.Generic;
using AltV.Net.Native;

namespace AltV.Net.Elements.Entities
{
    public interface IVehicle : IEntity
    {
        /// <summary>
        /// Get or set primary color of the vehicle.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        byte PrimaryColor { get; set; }
    }
}