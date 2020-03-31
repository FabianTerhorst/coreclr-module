using System;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Events;
using WebAssembly;

namespace AltV.Net.Client.EventHandlers
{
    internal class SyncedMetaChangeEventHandler : NativeEventHandler<NativeSyncedMetaChangeEventDelegate, SyncedMetaChangeEventDelegate>
    {
        private readonly NativeSyncedMetaChangeEventDelegate nativeSyncedMetaChangeEventDelegate;

        public SyncedMetaChangeEventHandler()
        {
            nativeSyncedMetaChangeEventDelegate = new NativeSyncedMetaChangeEventDelegate(OnSyncedMetaChange);
        }

        private void OnSyncedMetaChange(JSObject nativeEntity, string key, object value)
        {
            try
            {
                var type = (int) nativeEntity.GetObjectProperty("type");
                IEntity entity;
                switch (type)
                {
                    case (int) EntityType.Player:
                        entity = new Player(nativeEntity);
                        break;
                    case (int) EntityType.Vehicle:
                        entity = new Vehicle(nativeEntity);
                        break;
                    default:
                        Console.WriteLine("Unknown stream in entity type:" + type);
                        return;
                }
                var scriptEventHandler = EventHandlers.First;
                while (scriptEventHandler != null)
                {
                    scriptEventHandler.Value(entity, key, value);
                    scriptEventHandler = scriptEventHandler.Next;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception in GameEntityCreateEventHandler:" + exception);
            }
        }

        public override NativeSyncedMetaChangeEventDelegate GetNativeEventHandler()
        {
            return nativeSyncedMetaChangeEventDelegate;
        }
    }
}