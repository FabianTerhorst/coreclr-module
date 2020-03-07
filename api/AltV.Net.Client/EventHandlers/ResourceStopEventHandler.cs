using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.EventHandlers
{
    internal class ResourceStopEventHandler : NativeEventHandler<ResourceStopEventDelegate, ResourceStopEventDelegate>
    {
        private readonly ResourceStopEventDelegate resourceStopEventDelegate;

        public ResourceStopEventHandler()
        {
            resourceStopEventDelegate = new ResourceStopEventDelegate(OnResourceStop);
        }

        private void OnResourceStop()
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
                Console.WriteLine("Exception in ResourceStopEventHandler:" + exception);
            }
        }

        public override ResourceStopEventDelegate GetNativeEventHandler()
        {
            return resourceStopEventDelegate;
        }
    }
}