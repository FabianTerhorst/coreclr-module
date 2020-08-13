using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AltV.Net.Async
{
    internal class ActionTickScheduler : ITickScheduler
    {
        private readonly struct ActionContainer
        {
            private readonly Action action;

            public ActionContainer(Action action)
            {
                this.action = action;
            }

            public void Run()
            {
                action();
            }
        }
        
        private readonly struct ActionContainer2
        {
            private readonly Action<object> action;

            private readonly object state;

            public ActionContainer2(Action<object> action, object state)
            {
                this.action = action;
                this.state = state;
            }

            public void Run()
            {
                action(state);
            }
        }
        
        private readonly struct ActionContainer3<TResult>
        {
            private readonly Func<object, TResult> func;

            private readonly object state;

            private readonly TaskCompletionSource<TResult> result;

            public ActionContainer3(Func<object, TResult> func, object state, TaskCompletionSource<TResult> result)
            {
                this.func = func;
                this.state = state;
                this.result = result;
            }

            public void Run()
            {
                result.SetResult(func(state));
            }
        }
        
        private readonly struct ActionContainer4<TResult>
        {
            private readonly Func<TResult> func;

            private readonly TaskCompletionSource<TResult> result;

            public ActionContainer4(Func<TResult> func, TaskCompletionSource<TResult> result)
            {
                this.func = func;
                this.result = result;
            }

            public void Run()
            {
                result.SetResult(func());
            }
        }
        
        private readonly struct ActionContainer5
        {
            private readonly Action action;

            private readonly TaskCompletionSource<bool> result;

            public ActionContainer5(Action action, TaskCompletionSource<bool> result)
            {
                this.action = action;
                this.result = result;
            }

            public void Run()
            {
                action();
                result.SetResult(true);
            }
        }
        
        private readonly struct ActionContainer6
        {
            private readonly Action<object> action;

            private readonly object state;

            private readonly TaskCompletionSource<bool> result;

            public ActionContainer6(Action<object> action, object state,TaskCompletionSource<bool> result)
            {
                this.action = action;
                this.state = state;
                this.result = result;
            }

            public void Run()
            {
                action(state);
                result.SetResult(true);
            }
        }

        private int runs;

        private readonly ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();

        public ActionTickScheduler()
        {
        }

        public void Schedule(Action action)
        {
            actions.Enqueue(new ActionContainer(action).Run);
        }

        public void Schedule(Action<object> action, object state)
        {
            actions.Enqueue(new ActionContainer2(action, state).Run);
        }

        public Task ScheduleTask(Action action)
        {
            var completionSource = new TaskCompletionSource<bool>();
            actions.Enqueue(new ActionContainer5(action, completionSource).Run);
            return completionSource.Task;
        }

        public Task ScheduleTask(Action<object> action, object state)
        {
            var completionSource = new TaskCompletionSource<bool>();
            actions.Enqueue(new ActionContainer6(action, state, completionSource).Run);
            return completionSource.Task;
        }

        public Task<TResult> ScheduleTask<TResult>(Func<TResult> action)
        {
            var completionSource = new TaskCompletionSource<TResult>();
            actions.Enqueue(new ActionContainer4<TResult>(action, completionSource).Run);
            return completionSource.Task;
        }

        public Task<TResult> ScheduleTask<TResult>(Func<object, TResult> action, object value)
        {
            var completionSource = new TaskCompletionSource<TResult>();
            actions.Enqueue(new ActionContainer3<TResult>(action, value, completionSource).Run);
            return completionSource.Task;
        }

        public void Tick()
        {
            runs = actions.Count;

            while (runs-- > 0 && actions.TryDequeue(out var currentActionContainer))
            {
                currentActionContainer();
            }
        }
    }
}