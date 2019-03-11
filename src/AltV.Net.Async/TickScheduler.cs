using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    /*internal class TickScheduler : TaskScheduler
    {
        private readonly Thread mainThread;

        public override int MaximumConcurrencyLevel { get; } = 1;

        private readonly Channel<Task> tasks = Channel.CreateUnbounded<Task>(new UnboundedChannelOptions
            {AllowSynchronousContinuations = true});

        private Task currentTask;

        private bool taskAvailable;

        private readonly ChannelReader<Task> reader;

        private readonly ChannelWriter<Task> writer;

        public TickScheduler()
        {
            mainThread = Thread.CurrentThread;
            reader = tasks.Reader;
            writer = tasks.Writer;
        }

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return null;
        }

        protected override void QueueTask(Task task)
        {
            writer.WriteAsync(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return Thread.CurrentThread == mainThread && TryExecuteTask(task);
        }

        internal void Tick()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            taskAvailable = reader.TryRead(out currentTask);
            if (taskAvailable)
            {
                Alt.Log("taskAvailable");
                TryExecuteTask(currentTask);
            }

            watch.Stop();
            
            long microseconds = watch.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L));
            long nanoseconds = watch.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L*1000L));
            
            var elapsedMs = watch.ElapsedMilliseconds;
            Alt.Log("ms:" + elapsedMs);
            Alt.Log("micro:" + microseconds);
            Alt.Log("nano:" + nanoseconds);
        }
    }*/

    internal class TickScheduler : TaskScheduler
    {
        private readonly Thread mainThread;

        public override int MaximumConcurrencyLevel { get; } = 1;

        private readonly ConcurrentQueue<Task> tasks = new ConcurrentQueue<Task>();

        private Task currentTask;

        private int tasksCount;

        public TickScheduler(Thread mainThread)
        {
            this.mainThread = mainThread;
        }

        protected override IEnumerable<Task> GetScheduledTasks() => tasks;

        protected override void QueueTask(Task task) => tasks.Enqueue(task);

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) =>
            Thread.CurrentThread == mainThread && TryExecuteTask(task);

        internal void Tick()
        {
            tasksCount = tasks.Count;

            while (tasksCount-- > 0 && tasks.TryDequeue(out currentTask))
            {
                TryExecuteTask(currentTask);
            }
        }
    }
}