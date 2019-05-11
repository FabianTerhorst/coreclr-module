using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class QueueTickScheduler : TickScheduler
    {
        private readonly Thread mainThread;

        public override int MaximumConcurrencyLevel { get; } = 1;

        private readonly ConcurrentQueue<Task> tasks = new ConcurrentQueue<Task>();

        private Task currentTask;

        private int runs;

        public QueueTickScheduler(Thread mainThread)
        {
            this.mainThread = mainThread;
        }

        protected override IEnumerable<Task> GetScheduledTasks() => null;

        protected override void QueueTask(Task task) => tasks.Enqueue(task);

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) =>
            Thread.CurrentThread == mainThread && TryExecuteTask(task);

        public override void Tick()
        {
            runs = tasks.Count;

            while (runs-- > 0 && tasks.TryDequeue(out currentTask))
            {
                TryExecuteTask(currentTask);
            }
        }
    }
}