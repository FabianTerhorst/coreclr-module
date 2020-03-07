using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.EventHandlers
{
    internal class AnyResourceErrorEventHandler : NativeEventHandler<AnyResourceErrorEventDelegate, AnyResourceErrorEventDelegate>
    {
        private readonly AnyResourceErrorEventDelegate anyResourceErrorEventDelegate;

        public AnyResourceErrorEventHandler()
        {
            anyResourceErrorEventDelegate = new AnyResourceErrorEventDelegate(OnAnyResourceError);
        }

        public void OnAnyResourceError(string resourceName)
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
                Console.WriteLine("Exception in disconnect handler:" + exception);
            }
        }

        public override AnyResourceErrorEventDelegate GetNativeEventHandler()
        {
            return anyResourceErrorEventDelegate;
        }
    }
}