using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net
{
    public interface IRefContext : IDisposable
    {
        public bool CheckIfExists(ISharedBaseObject baseObject);

        public bool CheckIfExists(IWorldObject worldObject);
        public bool CheckIfExists(IEntity entity);
        
        bool CreateRef(ISharedBaseObject baseObject, bool safe = false);
    }

    public class RefContext : IRefContext
    {
        public static IRefContext Create(bool throwOnExistsCheck = true)
        {
            return new RefContext(throwOnExistsCheck);
        }
        
        private readonly LinkedList<ISharedBaseObject> baseObjectRefs;

        private readonly bool throwOnExistsCheck;

        private RefContext(bool throwOnExistsCheck)
        {
            baseObjectRefs = new LinkedList<ISharedBaseObject>();
            this.throwOnExistsCheck = throwOnExistsCheck;
        }

        public bool CreateRef(ISharedBaseObject baseObject, bool safe)
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

            Alt.CoreImpl.CountUpRefForCurrentThread(baseObject);
            baseObjectRefs.AddLast(baseObject);
            return true;
        }

        public bool CheckIfExists(ISharedBaseObject baseObject)
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

                    Alt.CoreImpl.CountDownRefForCurrentThread(current.Value);
                    if (current == last) done = true;
                    current = current.Next;
                } while (!done && current != null);
            }

            baseObjectRefs.Clear();

            GC.SuppressFinalize(this);
        }
    }
}