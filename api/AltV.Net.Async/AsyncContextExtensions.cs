using System;
using System.Threading;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Async
{
    public static class AsyncContextExtensions
    {
        public static bool CheckIfExistsNullable(this IAsyncContext context, IBaseObject baseObject)
        {
            if (context == null) return baseObject.Exists;
            return context.CheckIfExists(baseObject);
        }
        
        public static bool CheckIfExistsNullable(this IAsyncContext context, IWorldObject worldObject)
        {
            if (context == null) return worldObject.Exists;
            return context.CheckIfExists(worldObject);
        }
        
        public static bool CheckIfExistsNullable(this IAsyncContext context, IEntity entity)
        {
            if (context == null) return entity.Exists;
            return context.CheckIfExists(entity);
        }
        public static bool CheckIfExistsOrCachedNullable(this IAsyncContext context, IBaseObject baseObject)
        {
            if (context == null) return baseObject.Cached || baseObject.Exists;
            return context.CheckIfExistsOrCached(baseObject);
        }
        
        public static bool CheckIfExistsOrCachedNullable(this IAsyncContext context, IWorldObject worldObject)
        {
            if (context == null) return worldObject.Cached || worldObject.Exists;
            return context.CheckIfExistsOrCached(worldObject);
        }
        
        public static bool CheckIfExistsOrCachedNullable(this IAsyncContext context, IEntity entity)
        {
            if (context == null) return entity.Cached || entity.Exists;
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