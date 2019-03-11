using System;
using System.Threading.Tasks;
using AltV.Net.Events;

namespace AltV.Net.Async
{
    internal class AsyncEventHandler<TEvent> : HashSetEventHandler<TEvent>
    {
        public void CallAsync(Func<TEvent, Task> func)
        {
            Task.Run(() =>
            {
                foreach (var value in GetEvents())
                {
                    ExecuteEventAsync(value, func);
                }
            });
        }

        public static async void ExecuteEventAsync(TEvent subscription, Func<TEvent, Task> callback)
        {
            try
            {
                await callback(subscription).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Alt.Log($"Execution of {typeof(TEvent)} threw an error" + e);
            }
        }
    }
}