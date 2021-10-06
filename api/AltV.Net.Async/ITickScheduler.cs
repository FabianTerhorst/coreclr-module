using System;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    public interface ITickScheduler
    {
        void Tick();

        Task ScheduleTask(Action<object> action, object state);
        
        Task ScheduleTask(Action action);

        Task<TResult> ScheduleTask<TResult>(Func<object, TResult> action, object value);
        
        Task<TResult> ScheduleTask<TResult>(Func<TResult> action);
        
        void Schedule(Action action);
        
        void Schedule(Action<object> action, object state);

        void ScheduleBlocking(Action action, SemaphoreSlim semaphoreSlim);

        void ScheduleBlockingThrows(Action action, SemaphoreSlim semaphoreSlim);
    }
}