using System;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Pools;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

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
            if (!_module.CheckpointPool.GetOrCreate(checkpointPointer, out var checkpointEntity) ||
                !(checkpointEntity is ICheckpoint checkpoint))
            {
                return;
            }

            if (!_module.BaseEntityPool.GetOrCreate(entityPointer, out var entity))
            {
                return;
            }

            foreach (var @delegate in _module.CheckpointEventHandler.GetSubscriptions())
            {
                @delegate(checkpoint, entity, state);
            }
        }

        public static void OnPlayerConnect(IntPtr playerPointer, string reason)
        {
            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var entity) || !(entity is IPlayer player))
            {
                return;
            }

            foreach (var @delegate in _module.PlayerConnectEventHandler.GetSubscriptions())
            {
                @delegate(player, reason);
            }
        }

        public static void OnPlayerDamage(IntPtr playerPointer, IntPtr attackerEntityPointer, uint weapon, byte damage)
        {
            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var entity) || !(entity is IPlayer player))
            {
                return;
            }

            if (!_module.BaseEntityPool.GetOrCreate(attackerEntityPointer, out var attacker))
            {
                return;
            }

            foreach (var @delegate in _module.PlayerDamageEventHandler.GetSubscriptions())
            {
                @delegate(player, attacker, weapon, damage);
            }
        }


        public static void OnPlayerDead(IntPtr playerPointer, IntPtr killerEntityPointer, uint weapon)
        {
            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var entity) || !(entity is IPlayer player))
            {
                return;
            }

            if (!_module.BaseEntityPool.GetOrCreate(killerEntityPointer, out var killer))
            {
                return;
            }

            foreach (var @delegate in _module.PlayerDeadEventHandler.GetSubscriptions())
            {
                @delegate(player, killer, weapon);
            }
        }

        public static void OnVehicleChangeSeat(IntPtr vehiclePointer, IntPtr playerPointer, sbyte oldSeat,
            sbyte newSeat)
        {
            if (!_module.VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in _module.VehicleChangeSeatEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, oldSeat, newSeat);
            }
        }

        public static void OnVehicleEnter(IntPtr vehiclePointer, IntPtr playerPointer, sbyte seat)
        {
            if (!_module.VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in _module.VehicleEnterEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, seat);
            }
        }

        public static void OnVehicleLeave(IntPtr vehiclePointer, IntPtr playerPointer, sbyte seat)
        {
            if (!_module.VehiclePool.GetOrCreate(vehiclePointer, out var vehicle))
            {
                return;
            }

            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in _module.VehicleLeaveEventHandler.GetSubscriptions())
            {
                @delegate(vehicle, player, seat);
            }
        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            foreach (var @delegate in _module.PlayerDisconnectEventHandler.GetSubscriptions())
            {
                @delegate(player, reason);
            }
        }

        public static void OnEntityRemove(IntPtr entityPointer)
        {
            if (!_module.BaseEntityPool.GetOrCreate(entityPointer, out var entity))
            {
                return;
            }

            foreach (var @delegate in _module.EntityRemoveEventHandler.GetSubscriptions())
            {
                @delegate(entity);
            }

            _module.BaseEntityPool.Remove(entityPointer);
        }

        public static void OnClientEvent(IntPtr playerPointer, string name, ref MValueArray args)
        {
            if (!_module.PlayerPool.GetOrCreate(playerPointer, out var player))
            {
                return;
            }

            MValue[] argArray = null;
            if (_module.EventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(player, _module.BaseEntityPool, argArray);
                }
            }

            if (_module.ClientEventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                var argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(_module.BaseEntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(player, argObjects);
                }
            }
        }

        public static void OnServerEvent(string name, ref MValueArray args)
        {
            MValue[] argArray = null;
            if (_module.EventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(_module.BaseEntityPool, argArray);
                }
            }

            if (_module.EventDelegateHandlers.TryGetValue(name, out var eventDelegates))
            {
                if (argArray == null)
                {
                    argArray = args.ToArray();
                }

                var length = argArray.Length;
                var argObjects = new object[length];
                for (var i = 0; i < length; i++)
                {
                    argObjects[i] = argArray[i].ToObject(_module.BaseEntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(argObjects);
                }
            }
        }
    }
}