using System;
using AltV.Net.Client.Events;
using Array = WebAssembly.Core.Array;

namespace AltV.Net.Client.EventHandlers
{
    internal class KeyDownEventHandler : NativeEventHandler<KeyDownEventDelegate, KeyDownEventDelegate>
    {
        private readonly KeyDownEventDelegate keyDownEventDelegate;

        public KeyDownEventHandler()
        {
            keyDownEventDelegate = OnKeyDown;
        }

        private void OnKeyDown(int key)
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
                Console.WriteLine("Exception in KeyDownEventHandler:" + exception);
            }
        }

        public override KeyDownEventDelegate GetNativeEventHandler()
        {
            return keyDownEventDelegate;
        }
    }
}