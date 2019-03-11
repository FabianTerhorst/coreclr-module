using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class TickScheduler : TaskScheduler
    {
        private readonly Thread mainThread;

        public override int MaximumConcurrencyLevel { get; } = 1;

        private readonly Channel<Task> tasks = Channel.CreateUnbounded<Task>(new UnboundedChannelOptions
            {SingleReader = true});

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

        protected override IEnumerable<Task> GetScheduledTasks() => null;

        protected override void QueueTask(Task task) => writer.WriteAsync(task);

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) =>
            Thread.CurrentThread == mainThread && TryExecuteTask(task);

        internal void Tick()
        {
            taskAvailable = reader.TryRead(out currentTask);
            if (taskAvailable)
            {
                TryExecuteTask(currentTask);
            }
        }
    }
}