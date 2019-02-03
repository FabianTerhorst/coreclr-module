using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]

namespace AltV.Net
{
    internal static class ModuleWrapper
    {
        private static Module _module;

        public static void Main(IntPtr serverPointer)
        {
            _module = new Module(serverPointer);
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
            if (!_module.EventHandlers.TryGetValue(name, out var eventHandlers)) return;
            Server.Instance.LogInfo(eventHandlers.ToString());
            var argArray = args.ToArray();
            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Call(Server.Instance.EntityPool, argArray);
            }
        }
    }
}