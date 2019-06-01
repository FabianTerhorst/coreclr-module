using System;
using System.Collections.Concurrent;
using System.Threading;

namespace AltV.Net.Async
{
    class TickSynchronizationContext : SynchronizationContext
    {
        private static readonly ConcurrentQueue<Action> Tasks = new ConcurrentQueue<Action>();

        public override void Post(SendOrPostCallback d, object state)
        {
            Tasks.Enqueue(() => d(state));
        }

        private static int _runs;

        private static Action _currentTask;

        public static void Tick()
        {
            _runs = Tasks.Count;

            while (_runs-- > 0 && Tasks.TryDequeue(out _currentTask))
            {
                try
                {
                    _currentTask();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception during executing of tick in TickSynchronizationContext: {e}");
                }
            }
        }

        public override SynchronizationContext CreateCopy()
        {
            return this;
        }
    }
}