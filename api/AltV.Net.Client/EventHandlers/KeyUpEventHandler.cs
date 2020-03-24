using System;
using AltV.Net.Client.Events;
using Array = WebAssembly.Core.Array;

namespace AltV.Net.Client.EventHandlers
{
    internal class KeyUpEventHandler : NativeEventHandler<KeyUpEventDelegate, KeyUpEventDelegate>
    {
        private readonly KeyUpEventDelegate keyUpEventDelegate;

        public KeyUpEventHandler()
        {
            keyUpEventDelegate = OnKeyUp;
        }

        private void OnKeyUp(int key)
        {
            try
            {
                var scriptEventHandler = EventHandlers.First;
                while (scriptEventHandler != null)
                {
                    scriptEventHandler.Value(key);
                    scriptEventHandler = scriptEventHandler.Next;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception in KeyUpEventHandler:" + exception);
            }
        }

        public override KeyUpEventDelegate GetNativeEventHandler()
        {
            return keyUpEventDelegate;
        }
    }
}