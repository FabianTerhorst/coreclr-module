using System;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Pools;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]

namespace AltV.Net
{
    internal static class ModuleWrapper
    {
        private static Module _module;

        private static ResourceLoader _resourceLoader;

        public static void Main(IntPtr serverPointer, string resourceName, string entryPoint)
        {
            _resourceLoader = new ResourceLoader(serverPointer, resourceName, entryPoint);
            var resource = _resourceLoader.Prepare();
            var playerFactory = resource.GetPlayerFactory();
            var vehicleFactory = resource.GetVehicleFactory();
            var blipFactory = resource.GetBlipFactory();
            var checkpointFactory = resource.GetCheckpointFactory();
            var playerPool = new PlayerPool(playerFactory);
            var vehiclePool = new VehiclePool(vehicleFactory);
            var blipPool = new BlipPool(blipFactory);
            var checkpointPool = new CheckpointPool(checkpointFactory);
            var checkpoint = new CheckpointPool(checkpointFactory);
            var entityPool = new BaseEntityPool(playerPool, vehiclePool, blipPool, checkpoint);
            var server = new Server(serverPointer, entityPool, playerPool, vehiclePool, blipPool,
                checkpointPool);
            _module = new Module(server, entityPool, playerPool, vehiclePool, blipPool, checkpointPool);
            _resourceLoader.Start();
        }

        public static void OnStop()
        {
            _resourceLoader.Stop();
        }

        public static void OnCheckpoint(IntPtr checkpointPointer, IntPtr entityPointer, bool state)
        {
            _module.OnCheckpoint(checkpointPointer, entityPointer, state);
        }

        public static void OnPlayerConnect(IntPtr playerPointer, string reason)
        {
            _module.OnPlayerConnect(playerPointer, reason);
        }

        public static void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer, uint weapon, byte damage)
        {
            _module.OnPlayerDamage(playerPointer, attackerEntityPointer, weapon, damage);
        }

        public static void OnPlayerDead(IntPtr playerPointer, IntPtr killerEntityPointer, uint weapon)
        {
            _module.OnPlayerDead(playerPointer, killerEntityPointer, weapon);
        }

        public static void OnVehicleChangeSeat(IntPtr vehiclePointer, IntPtr playerPointer, sbyte oldSeat,
            sbyte newSeat)
        {
            _module.OnVehicleChangeSeat(vehiclePointer, playerPointer, oldSeat, newSeat);
        }

        public static void OnVehicleEnter(IntPtr vehiclePointer, IntPtr playerPointer, sbyte seat)
        {
            _module.OnVehicleEnter(vehiclePointer, playerPointer, seat);
        }

        public static void OnVehicleLeave(IntPtr vehiclePointer, IntPtr playerPointer, sbyte seat)
        {
            _module.OnVehicleLeave(vehiclePointer, playerPointer, seat);
        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            _module.OnPlayerDisconnect(playerPointer, reason);
        }

        public static void OnEntityRemove(IntPtr entityPointer)
        {
            _module.OnEntityRemove(entityPointer);
        }

        public static void OnClientEvent(IntPtr playerPointer, string name, ref MValueArray args)
        {
            _module.OnClientEvent(playerPointer, name, ref args);
        }

        public static void OnServerEvent(string name, ref MValueArray args)
        {
            _module.OnServerEvent(name, ref args);
        }
    }
}