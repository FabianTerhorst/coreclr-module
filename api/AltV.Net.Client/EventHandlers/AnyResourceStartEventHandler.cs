using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.EventHandlers
{
    internal class AnyResourceStartEventHandler : NativeEventHandler<AnyResourceStartEventDelegate, AnyResourceStartEventDelegate>
    {
        private readonly AnyResourceStartEventDelegate anyResourceStartEventDelegate;

        public AnyResourceStartEventHandler()
        {
            anyResourceStartEventDelegate = new AnyResourceStartEventDelegate(OnAnyResourceStart);
        }

        public void OnAnyResourceStart(string resourceName)
        {
            try
            {
                var scriptEventHandler = EventHandlers.First;
                while (scriptEventHandler != null)
                {
                    scriptEventHandler.Value(resourceName);
                    scriptEventHandler = scriptEventHandler.Next;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception in AnyResourceStartEventHandler:" + exception);
            }
        }

        public override AnyResourceStartEventDelegate GetNativeEventHandler()
        {
            return anyResourceStartEventDelegate;
        }
    }
}