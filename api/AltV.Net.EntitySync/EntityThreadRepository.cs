using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Channels;

namespace AltV.Net.EntitySync
{
    public class EntityThreadRepository : IEntityThreadRepository
    {
        private readonly ConcurrentDictionary<(ulong, ulong), IEntity> entities =
            new ConcurrentDictionary<(ulong, ulong), IEntity>();

        private readonly Channel<(IEntity, byte)> entitiesChannel =
            Channel.CreateUnbounded<(IEntity, byte)>(new UnboundedChannelOptions {SingleReader = true});

        internal readonly ChannelReader<(IEntity, byte)> EntitiesChannelReader;

        private readonly ChannelWriter<(IEntity, byte)> entitiesChannelWriter;

        private readonly Channel<(IEntity, string, object, bool)> entitiesDataChannel =
            Channel.CreateUnbounded<(IEntity, string, object, bool)>(new UnboundedChannelOptions {SingleReader = true});

        internal readonly ChannelReader<(IEntity, string, object, bool)> EntitiesDataChannelReader;

        private readonly ChannelWriter<(IEntity, string, object, bool)> entitiesDataChannelWriter;

        public EntityThreadRepository()
        {
            EntitiesDataChannelReader = entitiesDataChannel.Reader;
            entitiesDataChannelWriter = entitiesDataChannel.Writer;

            EntitiesChannelReader = entitiesChannel.Reader;
            entitiesChannelWriter = entitiesChannel.Writer;
        }

        public void Add(IEntity entity)
        {
            if (!entities.TryAdd(entity.HashKey, entity)) return;
            entitiesChannelWriter.TryWrite((entity, 0));
        }

        public void Remove(IEntity entity)
        {
            if (!entities.Remove(entity.HashKey, out _)) return;
            entitiesChannelWriter.TryWrite((entity, 1));
        }
        
        public void Remove(ulong id, ulong type)
        {
            if (!entities.Remove((id, type), out var entity)) return;
            entitiesChannelWriter.TryWrite((entity, 1));
        }

        public void Remove(IList<IEntity> entities)
        {
            for (int i = 0, length = entities.Count; i < length; i++)
            {
                var entity = entities[i];
                if (!this.entities.Remove(entity.HashKey, out _)) return;
                entitiesChannelWriter.TryWrite((entity, 1));
            }
        }

        public void Update(IEntity entity)
        {
            entitiesChannelWriter.TryWrite((entity, 2));
        }

        public void UpdateData(IEntity entity, string key, object value)
        {
            entitiesDataChannelWriter.TryWrite((entity, key, value, true));
        }

        public void ResetData(IEntity entity, string key)
        {
            entitiesDataChannelWriter.TryWrite((entity, key, null, false));
        }

        public bool TryGet(ulong id, ulong type, out IEntity entity)
        {
            return entities.TryGetValue((id, type), out entity);
        }

        public IEnumerable<IEntity> GetAll()
        {
            foreach (var (_, entity) in entities)
            {
                yield return entity;
            }
        }
    }
}