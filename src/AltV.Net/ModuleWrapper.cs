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
            var vehicleFactory = resource.GetVehicleFactory();
            var entityPool = new EntityPool(vehicleFactory);
            var server = new Server(serverPointer, entityPool, vehicleFactory);
            _module = new Module(server, entityPool);
            _resourceLoader.Start();
        }

        public static void OnStop()
        {
            _resourceLoader.Stop();
        }

        public static void OnPlayerConnect(IntPtr playerPointer, string reason)
        {
            if (!_module.EntityPool.Get(playerPointer, out var entity) || !(entity is IPlayer player))
            {
                return;
            }

            foreach (var @delegate in _module.PlayerConnectEventHandler.GetSubscriptions())
            {
                @delegate(player, reason);
            }
        }

        public static void OnPlayerDisconnect(IntPtr playerPointer, string reason)
        {
            if (!_module.EntityPool.Get(playerPointer, out var entity) || !(entity is IPlayer player))
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
            if (!_module.EntityPool.Get(entityPointer, out var entity))
            {
                return;
            }

            foreach (var @delegate in _module.EntityRemoveEventHandler.GetSubscriptions())
            {
                @delegate(entity);
            }

            _module.EntityPool.Remove(entityPointer);
        }

        public static void OnServerEvent(string name, ref MValueArray args)
        {
            MValue[] argArray = null;
            if (_module.EventHandlers.TryGetValue(name, out var eventHandlers))
            {
                argArray = args.ToArray();
                foreach (var eventHandler in eventHandlers)
                {
                    eventHandler.Call(_module.EntityPool, argArray);
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
                    argObjects[i] = argArray[i].ToObject(_module.EntityPool);
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(argObjects);
                }
            }
        }
    }
}