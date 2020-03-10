using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.EventHandlers
{
    internal class AnyResourceStopEventHandler : NativeEventHandler<AnyResourceStopEventDelegate, AnyResourceStopEventDelegate>
    {
        private readonly AnyResourceStopEventDelegate anyResourceStopEventDelegate;

        public AnyResourceStopEventHandler()
        {
            anyResourceStopEventDelegate = new AnyResourceStopEventDelegate(OnAnyResourceStop);
        }

        public void OnAnyResourceStop(string resourceName)
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
                Console.WriteLine("Exception in AnyResourceStopEventHandler:" + exception);
            }
        }

        public override AnyResourceStopEventDelegate GetNativeEventHandler()
        {
            return anyResourceStopEventDelegate;
        }
    }
}