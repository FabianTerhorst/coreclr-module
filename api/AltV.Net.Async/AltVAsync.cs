﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class AltVAsync
    {
        private readonly TaskFactory taskFactory;
        private readonly TickScheduler scheduler;
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
            taskFactory = new TaskFactory(
                CancellationToken.None, TaskCreationOptions.DenyChildAttach,
                TaskContinuationOptions.None, scheduler);
            AltAsync.Setup(this);
            TickDelegate = FirstTick;
        }

        private void FirstTick()
        {
            TickThread = Thread.CurrentThread;
            TickDelegate = Tick;
        }

        private void Tick()
        {
            scheduler.Tick();
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

            return taskFactory.StartNew(action);
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

            return taskFactory.StartNew(action);
        }
    }
}