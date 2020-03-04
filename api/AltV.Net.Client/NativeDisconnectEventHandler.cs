using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client
{
    internal class NativeDisconnectEventHandler : NativeEventHandler<DisconnectEventDelegate, DisconnectEventDelegate>
    {
        private readonly DisconnectEventDelegate disconnectEventDelegate;

        public NativeDisconnectEventHandler()
        {
            disconnectEventDelegate = new DisconnectEventDelegate(OnDisconnect);
        }

        public void OnDisconnect()
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
                Console.WriteLine("Exception in disconnect handler:" + exception);
            }
        }

        public override DisconnectEventDelegate GetNativeEventHandler()
        {
            return disconnectEventDelegate;
        }
    }
}