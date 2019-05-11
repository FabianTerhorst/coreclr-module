using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class ChannelTickScheduler : TickScheduler
    {
        private readonly Thread mainThread;

        public override int MaximumConcurrencyLevel { get; } = 1;

        private readonly Channel<Task> tasks = Channel.CreateUnbounded<Task>(new UnboundedChannelOptions
            {SingleReader = true});

        private Task currentTask;

        private readonly ChannelReader<Task> reader;

        private readonly ChannelWriter<Task> writer;

        public ChannelTickScheduler(Thread mainThread)
        {
            this.mainThread = mainThread;
            reader = tasks.Reader;
            writer = tasks.Writer;
        }

        protected override IEnumerable<Task> GetScheduledTasks() => null;

        protected override void QueueTask(Task task) => writer.WriteAsync(task);

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) =>
            Thread.CurrentThread == mainThread && TryExecuteTask(task);

        public override void Tick()
        {
            if (reader.TryRead(out currentTask))
            {
                TryExecuteTask(currentTask);
            }
        }
    }
}