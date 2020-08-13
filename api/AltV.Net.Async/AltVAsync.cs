using System;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class AltVAsync
    {
        private readonly ITickScheduler scheduler;
        private readonly Thread mainThread;
        internal Thread TickThread;

        public Action TickDelegate;

        public AltVAsync(ITickSchedulerFactory tickSchedulerFactory)
        {
            mainThread = Thread.CurrentThread;
            if (mainThread.Name == "")
            {
                mainThread.Name = "main";
            }

            scheduler = tickSchedulerFactory.Create(mainThread);
            AltAsync.Setup(this);
            TickDelegate = FirstTick;
        }

        private void FirstTick()
        {
            TickThread = Thread.CurrentThread;
            TickDelegate = scheduler.Tick;
        }

        internal Task Schedule(Action action)
        {
            if (Thread.CurrentThread == mainThread)
            {
                try
                {
                    action();
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
            }

            return scheduler.ScheduleTask(action);
        }

        internal Task Schedule(Action<object> action, object value)
        {
            if (Thread.CurrentThread == mainThread)
            {
                try
                {
                    action(value);
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    return Task.FromException(ex);
                }
            }

            return scheduler.ScheduleTask(action, value);
        }

        internal Task<TResult> Schedule<TResult>(Func<TResult> action)
        {
            if (Thread.CurrentThread == mainThread)
            {
                try
                {
                    return Task.FromResult(action());
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
            }

            return scheduler.ScheduleTask(action);
        }

        internal Task<TResult> Schedule<TResult>(Func<object, TResult> action, object value)
        {
            if (Thread.CurrentThread == mainThread)
            {
                try
                {
                    return Task.FromResult(action(value));
                }
                catch (Exception ex)
                {
                    return Task.FromException<TResult>(ex);
                }
            }

            return scheduler.ScheduleTask(action, value);
        }

        internal void ScheduleNoneTask(Action action)
        {
            if (Thread.CurrentThread == mainThread)
            {
                action();
                return;
            }

            scheduler.Schedule(action);
        }

        internal void ScheduleNoneTask(Action<object> action, object value)
        {
            if (Thread.CurrentThread == mainThread)
            {
                action(value);
                return;
            }

            scheduler.Schedule(action, value);
        }
    }
}