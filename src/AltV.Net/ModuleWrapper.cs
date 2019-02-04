using System;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

namespace AltV.Net
{
    internal static class ModuleWrapper
    {
        private static Module _module;

        public static void Main(IntPtr serverPointer, string resourceName, string entryPoint)
        {
            _module = new Module(serverPointer, resourceName, entryPoint);
            _module.ResourceLoader.Prepare();
            _module.ResourceLoader.Start();
        }

        public static void OnStop()
        {
            _module.ResourceLoader.Stop();
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
                    argObjects[i] = argArray[i].ToObject();
                }

                foreach (var eventHandler in eventDelegates)
                {
                    eventHandler(argObjects);
                }
            }
        }
    }
}