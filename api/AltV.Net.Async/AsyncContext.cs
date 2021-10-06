using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public interface IAsyncContext : IAsyncDisposable
    {
        void Enqueue(Action action);

        void RunOnMainThreadBlocking(Action action);

        void RunAll();

        bool CheckIfExists(IBaseObject baseObject);

        bool CheckIfExists(IWorldObject worldObject);

        bool CheckIfExists(IEntity entity);

        bool CreateRef(IBaseObject baseObject);
    }
    
    public class AsyncContext : IAsyncContext
    {
        public static IAsyncContext Create(bool throwOnExistsCheck = true, bool createRefAutomatically = true)
        {
            return new AsyncContext(throwOnExistsCheck, createRefAutomatically);
        }

        private readonly LinkedList<Action> actions;

        private readonly LinkedList<IBaseObject> baseObjectRefs;

        private readonly SemaphoreSlim semaphoreSlim;

        private readonly bool throwOnExistsCheck;

        private readonly bool createRefAutomatically;

        private AsyncContext(bool throwOnExistsCheck, bool createRefAutomatically)
        {
            actions = new LinkedList<Action>();
            baseObjectRefs = new LinkedList<IBaseObject>();
            semaphoreSlim = new SemaphoreSlim(0, 1);
            this.throwOnExistsCheck = throwOnExistsCheck;
            this.createRefAutomatically = createRefAutomatically;
        }

        public void Enqueue(Action action)
        {
            actions.AddLast(action);
        }

        public bool CreateRef(IBaseObject baseObject)
        {
            if (!createRefAutomatically) return true;
            try
            {
                if (!baseObject.AddRef())
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }

            Alt.Module.CountUpRefForCurrentThread(baseObject);
            baseObjectRefs.AddLast(baseObject);
            return true;
        }

        public void RunOnMainThreadBlocking(Action action)
        {
            if (throwOnExistsCheck)
            {
                AltAsync.RunOnMainThreadBlockingThrows(action, semaphoreSlim);
            }
            else
            {
                AltAsync.RunOnMainThreadBlocking(action, semaphoreSlim);
            }
        }

        public bool CheckIfExists(IBaseObject baseObject)
        {
            if (baseObject.Exists) return true;
            if (throwOnExistsCheck)
            {
                throw new BaseObjectRemovedException(baseObject);
            }
            return false;
        }
        
        public bool CheckIfExists(IWorldObject worldObject)
        {
            if (worldObject.Exists) return true;
            if (throwOnExistsCheck)
            {
                throw new WorldObjectRemovedException(worldObject);
            }

            return false;
        }
        
        public bool CheckIfExists(IEntity entity)
        {
            if (entity.Exists) return true;
            if (throwOnExistsCheck)
            {
                throw new EntityRemovedException(entity);
            }

            return false;
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
            // Thread safe linked list loop
            var first = baseObjectRefs.First;
            var current = first;
            var last = baseObjectRefs.Last;
            var done = false;
            if (current != null) // check if empty
            {
                do
                {
                    try
                    {
                        current.Value.RemoveRef();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }

                    Alt.Module.CountDownRefForCurrentThread(current.Value);
                    if (current == last) done = true;
                    current = current.Next;
                } while (!done && current != null);
            }

            baseObjectRefs.Clear();
            actions.Clear();
            semaphoreSlim.Dispose();

            GC.SuppressFinalize(this);
            return ValueTask.CompletedTask;
        }
    }
}