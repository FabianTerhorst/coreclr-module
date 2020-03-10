using System;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Events;
using WebAssembly;

namespace AltV.Net.Client.EventHandlers
{
    internal class GameEntityDestroyEventHandler : NativeEventHandler<NativeGameEntityDestroyEventDelegate, GameEntityDestroyEventDelegate>
    {
        private readonly NativeGameEntityDestroyEventDelegate gameEntityDestroyEventDelegate;

        public GameEntityDestroyEventHandler()
        {
            gameEntityDestroyEventDelegate = new NativeGameEntityDestroyEventDelegate(OnGameEntityDestroy);
        }

        private void OnGameEntityDestroy(JSObject nativeEntity)
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
                    scriptEventHandler.Value(entity);
                    scriptEventHandler = scriptEventHandler.Next;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception in GameEntityDestroyEventHandler:" + exception);
            }
        }

        public override NativeGameEntityDestroyEventDelegate GetNativeEventHandler()
        {
            return gameEntityDestroyEventDelegate;
        }
    }
}