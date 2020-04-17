using AltV.Net.EntitySync.ServerEvent;
using AltV.Net.EntitySync.SpatialPartitions;

namespace AltV.Net.EntitySync.Entities
{
    public class AltEntitySyncEntities : IModule
    {
        public void OnScriptsStarted(IScript[] scripts)
        {
            AltEntitySync.Init(5, 100,
                (repository, threadCount) => new ServerEventNetworkLayer(repository, threadCount),
                (entity, threadCount) => entity.Type,
                (entityId, entityType, threadCount) => entityType,
                (threadId) =>
                {
                    if (threadId == 0) // objects
                        return new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 350);
                    if (threadId == 1) // peds
                        return new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 125);
                    if (threadId == 2) // text labels
                        return new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 125);
                    if (threadId == 3) // marker
                        return new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 125);
                    if (threadId == 4) // blip
                        return new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 125);
                    return null;
                },
                new IdProvider());
        }

        public void OnStop()
        {
            AltEntitySync.Stop();
        }
    }
}