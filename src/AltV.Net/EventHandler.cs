using System.Collections.Generic;

namespace AltV.Net
{
    public class EventHandler<TEvent>
    {
        private readonly HashSet<TEvent> subscriptions = new HashSet<TEvent>();

        public void Subscribe(TEvent callback)
        {
            if (callback == null) return;
            subscriptions.Add(callback);
        }

        public void Unsubscribe(TEvent callback)
        {
            if (callback == null) return;
            subscriptions.Remove(callback);
        }

        public HashSet<TEvent> GetSubscriptions()
        {
            return subscriptions;
        }
        
        public bool HasSubscriptions()
        {
            return subscriptions.Count != 0;
        }
    }
}