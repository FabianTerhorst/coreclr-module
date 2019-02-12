using System;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class AsyncEventHandler<TEvent> : EventHandler<TEvent>
    {
        public void CallAsync(Func<TEvent, Task> callback)
        {
            Task.Run(() =>
            {
                foreach (var subscription in GetSubscriptions())
                {
                    ExecuteSubscriptionAsync(subscription, callback);
                }
            });
        }

        public static async void ExecuteSubscriptionAsync(TEvent subscription, Func<TEvent, Task> callback)
        {
            try
            {
                await callback(subscription).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Alt.Log($"An error occured during execution of event {typeof(TEvent)}:" + e);
            }
        }
    }
}