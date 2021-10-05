using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    public interface IAsyncContext : IAsyncDisposable
    {
        void Enqueue(Action action);

        void RunOnMainThreadBlocking(Action action);

        void RunAll();
    }
    
    public class AsyncContext : IAsyncContext
    {
        public static IAsyncContext Create()
        {
            return new AsyncContext();
        }
        
        private readonly LinkedList<Action> actions;

        private readonly SemaphoreSlim semaphoreSlim;

        private AsyncContext()
        {
            actions = new LinkedList<Action>();
            semaphoreSlim = new SemaphoreSlim(0, 1);
        }

        public void Enqueue(Action action)
        {
            actions.AddLast(action);
        }

        public void RunOnMainThreadBlocking(Action action)
        {
            AltAsync.RunOnMainThreadBlocking(action, semaphoreSlim);
        }

        public void RunAll()
        {
            if (actions.Count == 0) return;
            RunOnMainThreadBlocking(() =>
            {
                // Thread safe linked list loop
                var first = actions.First;
                var current = first;
                var last = actions.Last;
                var done = false;
                if (current == null) return; //empty list
                do
                {
                    current.Value();
                    if (current == last) done = true;
                    current = current.Next;
                } while (!done && current != null);
            });
        }
        
        public ValueTask DisposeAsync()
        {
            RunAll();
            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }
    }
}