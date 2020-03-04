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
            var scriptEventHandler = EventHandlers.First;
            while (scriptEventHandler != null)
            {
                scriptEventHandler.Value();
                scriptEventHandler = scriptEventHandler.Next;
            }
        }

        public override DisconnectEventDelegate GetNativeEventHandler()
        {
            return disconnectEventDelegate;
        }
    }
}