using System;
using AltV.Net.Client.Events;

namespace AltV.Net.Client.EventHandlers
{
    internal class ResourceStartEventHandler : NativeEventHandler<ResourceStartEventDelegate, ResourceStartEventDelegate>
    {
        private readonly ResourceStartEventDelegate resourceStartEventDelegate;

        public ResourceStartEventHandler()
        {
            resourceStartEventDelegate = new ResourceStartEventDelegate(OnResourceStart);
        }

        private void OnResourceStart(bool errored)
        {
            try
            {
                var scriptEventHandler = EventHandlers.First;
                while (scriptEventHandler != null)
                {
                    scriptEventHandler.Value(errored);
                    scriptEventHandler = scriptEventHandler.Next;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception in ResourceStartEventHandler:" + exception);
            }
        }

        public override ResourceStartEventDelegate GetNativeEventHandler()
        {
            return resourceStartEventDelegate;
        }
    }
}