using System.Numerics;
using AltV.Net.Client.Elements.Interfaces;
using Microsoft.CodeAnalysis;

namespace AltV.Net.Client.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        private static IntPtr GetEntityPointer(ICore core, IntPtr playerNativePointer)
        {
            unsafe
            {
                return core.Library.Player_GetEntity(playerNativePointer);
            }
        }
        
        public IntPtr PlayerNativePointer { get; }
        
        public Player(ICore core, IntPtr playerPointer, ushort id) : base(core, GetEntityPointer(core, playerPointer), id)
        {
            PlayerNativePointer = playerPointer;
        }

        public IVehicle? Vehicle
        {
            get
            {
                unsafe
                {
                    ushort id = 0;
                    var success = Core.Library.Player_GetVehicleId(PlayerNativePointer, &id);
                    if (success == 0) return null;
                    
                    Alt.Module.VehiclePool.Get(id, out var vehicle);
                    return vehicle;
                }
            }
        }
    }
}