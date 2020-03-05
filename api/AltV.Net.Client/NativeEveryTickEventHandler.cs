using AltV.Net.Client.Events;

namespace AltV.Net.Client
{
    internal class NativeEveryTickEventHandler : NativeEventHandler<EveryTickEventDelegate, EveryTickEventDelegate>
    {
        private readonly EveryTickEventDelegate everyTickEventDelegate;

        public NativeEveryTickEventHandler()
        {
            everyTickEventDelegate = new EveryTickEventDelegate(OnEveryTick);
        }

        public void OnEveryTick()
        {
            var scriptEventHandler = EventHandlers.First;
            while (scriptEventHandler != null)
            {
                scriptEventHandler.Value();
                scriptEventHandler = scriptEventHandler.Next;
            }
        }

        public override EveryTickEventDelegate GetNativeEventHandler()
        {
            return everyTickEventDelegate;
        }
    }
}