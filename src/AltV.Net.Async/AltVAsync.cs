using System;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class AltVAsync
    {
        internal readonly TaskFactory TaskFactory;
        private readonly TickScheduler scheduler;

        public AltVAsync()
        {
            scheduler = new TickScheduler();
            TaskFactory = new TaskFactory(
                CancellationToken.None, TaskCreationOptions.DenyChildAttach,
                TaskContinuationOptions.None, scheduler);
            AltAsync.Setup(this);
        }

        internal void Tick()
        {
            scheduler.Tick();
        }

        internal async Task Schedule(Action action)
        {
            await TaskFactory.StartNew(action);
        }

        internal async Task<TResult> Schedule<TResult>(Func<TResult> action)
        {
            return await TaskFactory.StartNew(action);
        }
    }
}