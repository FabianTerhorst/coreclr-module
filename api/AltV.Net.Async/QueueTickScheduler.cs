using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class QueueTickScheduler : TaskScheduler, ITickScheduler
    {
        private readonly Thread mainThread;

        public override int MaximumConcurrencyLevel { get; } = 1;

        private readonly ConcurrentQueue<Task> tasks = new ConcurrentQueue<Task>();

        private Task currentTask;

        private int runs;

        private readonly TaskFactory taskFactory;

        public QueueTickScheduler(Thread mainThread)
        {
            this.mainThread = mainThread;
            taskFactory = new TaskFactory(
                CancellationToken.None, TaskCreationOptions.DenyChildAttach,
                TaskContinuationOptions.None, this);
        }

        protected override IEnumerable<Task> GetScheduledTasks() => null;

        protected override void QueueTask(Task task) => tasks.Enqueue(task);

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) =>
            Thread.CurrentThread == mainThread && TryExecuteTask(task);

        public void Schedule(Action action)
        {
            taskFactory.StartNew(action);
        }
        
        public void ScheduleBlocking(Action action, SemaphoreSlim semaphoreSlim)
        {
            taskFactory.StartNew(() =>
            {
                try
                {
                    action();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                semaphoreSlim.Release();
            });
            semaphoreSlim.Wait();
        }
        
        public void ScheduleBlockingThrows(Action action, SemaphoreSlim semaphoreSlim)
        {
            Exception exception = null;
            taskFactory.StartNew(() =>
            {
                try
                {
                    action();
                }
                catch (Exception innerException)
                {
                    exception = innerException;
                }

                semaphoreSlim.Release();
            });
            semaphoreSlim.Wait();
            if (exception != null)
            {
                throw exception;
            }
        }

        public void Schedule(Action<object> action, object state)
        {
            taskFactory.StartNew(action, state);
        }

        public Task ScheduleTask(Action action)
        {
            return taskFactory.StartNew(action);
        }

        public Task ScheduleTask(Action<object> action, object state)
        {
            return taskFactory.StartNew(action, state);
        }

        public Task<TResult> ScheduleTask<TResult>(Func<TResult> action)
        {
            return taskFactory.StartNew(action);
        }

        public Task<TResult> ScheduleTask<TResult>(Func<object, TResult> action, object value)
        {
            return taskFactory.StartNew(action, value);
        }

        public void Tick()
        {
            runs = tasks.Count;

            while (runs-- > 0 && tasks.TryDequeue(out currentTask))
            {
                TryExecuteTask(currentTask);
            }
        }
    }
}