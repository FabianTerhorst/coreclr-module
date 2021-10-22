using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public interface IAsyncRefContext : IDisposable
    {
        public bool CheckIfExists(IBaseObject baseObject);

        public bool CheckIfExists(IWorldObject worldObject);
        public bool CheckIfExists(IEntity entity);
        
        bool CreateRef(IBaseObject baseObject, bool safe = false);
    }

    public class AsyncRefContext : IAsyncRefContext
    {
        public static IAsyncRefContext Create(bool throwOnExistsCheck = true)
        {
            return new AsyncRefContext(throwOnExistsCheck);
        }
        
        private readonly LinkedList<IBaseObject> baseObjectRefs;

        private readonly bool throwOnExistsCheck;

        private AsyncRefContext(bool throwOnExistsCheck)
        {
            baseObjectRefs = new LinkedList<IBaseObject>();
            this.throwOnExistsCheck = throwOnExistsCheck;
        }

        public bool CreateRef(IBaseObject baseObject, bool safe)
        {
            if (baseObject == null) return false;
            try
            {
                if (!baseObject.AddRef())
                {
                    // Check safe to prevent throw on TryToAsync calls
                    if (!safe && throwOnExistsCheck)
                    {
                        throw baseObject switch
                        {
                            IEntity entity => new EntityRemovedException(entity),
                            IWorldObject worldObject => new WorldObjectRemovedException(worldObject),
                            _ => new BaseObjectRemovedException(baseObject)
                        };
                    }

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

        public void Dispose()
        {
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

            GC.SuppressFinalize(this);
        }
    }
}