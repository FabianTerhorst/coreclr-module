using System;
using System.Threading;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static class AsyncContextExtensions
    {
        private static bool CheckIfExists(IBaseObject baseObject)
        {
            if (baseObject.Exists) return true;
            if (Alt.ThrowIfEntityDoesNotExist) throw new BaseObjectRemovedException(baseObject);
            return false;
        }
        private static bool CheckIfExistsOrCached(IBaseObject baseObject)
        {
            if (baseObject.Cached) return true;
            return CheckIfExists(baseObject);
        }
        
        public static bool CheckIfExistsNullable(this IAsyncContext context, IBaseObject baseObject)
        {
            if (context == null) return CheckIfExists(baseObject);
            return context.CheckIfExists(baseObject);
        }
        
        public static bool CheckIfExistsNullable(this IAsyncContext context, IWorldObject worldObject)
        {
            if (context == null) return CheckIfExists(worldObject);
            return context.CheckIfExists(worldObject);
        }
        
        public static bool CheckIfExistsNullable(this IAsyncContext context, IEntity entity)
        {
            if (context == null) return CheckIfExists(entity);
            return context.CheckIfExists(entity);
        }
        public static bool CheckIfExistsOrCachedNullable(this IAsyncContext context, IBaseObject baseObject)
        {
            if (context == null) return CheckIfExistsOrCached(baseObject);
            return context.CheckIfExistsOrCached(baseObject);
        }
        
        public static bool CheckIfExistsOrCachedNullable(this IAsyncContext context, IWorldObject worldObject)
        {
            if (context == null) return CheckIfExistsOrCached(worldObject);
            return context.CheckIfExistsOrCached(worldObject);
        }
        
        public static bool CheckIfExistsOrCachedNullable(this IAsyncContext context, IEntity entity)
        {
            if (context == null) return CheckIfExistsOrCached(entity);
            return context.CheckIfExistsOrCached(entity);
        }

        public static void RunOnMainThreadBlockingNullable(this IAsyncContext context, Action action)
        {
            if (context == null)
            {
                using var semaphore = new SemaphoreSlim(0, 1);
                AltAsync.RunOnMainThreadBlocking(action, semaphore);
                return;
            }
            
            context.RunOnMainThreadBlocking(action);
        }
    }
}