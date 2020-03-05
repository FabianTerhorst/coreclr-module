using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.EventHandlers
{
    internal class NativeConnectionCompleteEventHandler : NativeEventHandler<ConnectionCompleteEventDelegate, ConnectionCompleteEventDelegate>
    {
        private readonly ConnectionCompleteEventDelegate connectionCompleteEventDelegate;

        public NativeConnectionCompleteEventHandler()
        {
            connectionCompleteEventDelegate = new ConnectionCompleteEventDelegate(OnConnectionComplete);
        }

        public void OnConnectionComplete()
        {
            try
            {
                var scriptEventHandler = EventHandlers.First;
                while (scriptEventHandler != null)
                {
                    scriptEventHandler.Value();
                    scriptEventHandler = scriptEventHandler.Next;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception in connectionComplete handler:" + exception);
            }
        }

        public override ConnectionCompleteEventDelegate GetNativeEventHandler()
        {
            return connectionCompleteEventDelegate;
        }
    }
}