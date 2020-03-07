using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.EventHandlers
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
                Console.WriteLine("Exception in everyTick handler:" + exception);
            }
        }

        public override EveryTickEventDelegate GetNativeEventHandler()
        {
            return everyTickEventDelegate;
        }
    }
}