using System;
using System.Runtime.CompilerServices;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]

namespace AltV.Net
{
    internal static class ModuleWrapper
    {
        private static Module _module;

        private static ResourceLoader _resourceLoader;

        private static IResource _resource;

        public static void Main(IntPtr serverPointer, string resourceName, string entryPoint)
        {
            _resourceLoader = new ResourceLoader(serverPointer, resourceName, entryPoint);
            _resource = _resourceLoader.Prepare();
            if (_resource == null)
            {
                return;
            }

            var playerFactory = _resource.GetPlayerFactory();
            var vehicleFactory = _resource.GetVehicleFactory();
            var blipFactory = _resource.GetBlipFactory();
            var checkpointFactory = _resource.GetCheckpointFactory();
            var playerPool = _resource.GetPlayerPool(playerFactory);
            var vehiclePool = _resource.GetVehiclePool(vehicleFactory);
            var blipPool = _resource.GetBlipPool(blipFactory);
            var checkpointPool = _resource.GetCheckpointPool(checkpointFactory);
            var entityPool = _resource.GetBaseEntityPool(playerPool, vehiclePool, blipPool, checkpointPool);
            var server = new Server(serverPointer, entityPool, playerPool, vehiclePool, blipPool,
                checkpointPool);
            _module = _resource.GetModule(server, entityPool, playerPool, vehiclePool, blipPool, checkpointPool);
            _resource.OnStart();
        }

        public static void OnStop()
        {
            _resource.OnStop();
        }

        public static void OnTick()
        {
            _resource.OnTick();
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