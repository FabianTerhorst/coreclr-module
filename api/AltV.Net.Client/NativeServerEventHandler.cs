using AltV.Net.Client.Events;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    internal class NativeServerEventHandler : NativeEventHandler<NativeEventDelegate, ServerEventDelegate>
    {
        private readonly NativeEventDelegate nativeEventDelegate;

        public NativeServerEventHandler()
        {
            nativeEventDelegate = new NativeEventDelegate(OnNativeEvent);
        }

        public void OnNativeEvent(Array nativeArgs)
        {
            var scriptEventHandler = EventHandlers.First;
            var length = nativeArgs.Length;
            var args = new object[length];
            for (var i = 0; i < length; i++)
            {
                args[i] = nativeArgs[i];
            }
            while (scriptEventHandler != null)
            {
                scriptEventHandler.Value(args);
                scriptEventHandler = scriptEventHandler.Next;
            }
        }

        public override NativeEventDelegate GetNativeEventHandler()
        {
            return nativeEventDelegate;
        }
    }
}