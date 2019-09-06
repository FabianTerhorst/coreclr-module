using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AltV.Net.Events;

namespace AltV.Net.Async
{
    internal class AsyncEventHandler<TEvent> : HashSetEventHandler<TEvent>
    {
        public async Task CallAsync(Func<TEvent, Task> func)
        {
            var events = GetEvents();
            var tasks = new List<Task>(events.Count);
            foreach (var value in events)
            {
                tasks.Add(ExecuteEventAsync(value, func));
            }

            await Task.WhenAll(tasks);
        }

        public async void CallAsyncWithoutTask(Func<TEvent, Task> callback)
        {
            var events = GetEvents();
            foreach (var value in events)
            {
                await ExecuteEventAsync(value, callback);
            }
        }

        public static async Task ExecuteEventAsync(TEvent subscription, Func<TEvent, Task> callback)
        {
            try
            {
                await callback(subscription).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                AltAsync.Log($"Execution of {typeof(TEvent)} threw an error: {e}");
            }
        }
        
        public static async void ExecuteEventAsyncWithoutTask(TEvent subscription, Func<TEvent, Task> callback)
        {
            try
            {
                await callback(subscription).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                AltAsync.Log($"Execution of {typeof(TEvent)} threw an error: {e}");
            }
        }
    }
}