using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;
using Entity;

namespace AltV.Net.NetworkingEntity
{
    public class EntityRepository
    {
        public event Action<Entity.Entity> EntityAddHandler;

        public event Action<ulong> EntityRemoveHandler;

        public event Action<ulong, Position> EntityPositionUpdateHandler;

        public event Action<ulong, string, MValue> EntityDataUpdateHandler;

        public event Action<Entity.Entity, IPlayer> EntityStreamInHandler;

        public event Action<Entity.Entity, IPlayer> EntityStreamOutHandler;

        public Action<Entity.Entity> OnEntityAdd
        {
            set => EntityAddHandler += value;
            get => EntityAddHandler;
        }

        public Action<ulong> OnEntityRemove
        {
            set => EntityRemoveHandler += value;
            get => EntityRemoveHandler;
        }

        public Action<ulong, Position> OnEntityPositionUpdate
        {
            set => EntityPositionUpdateHandler += value;
            get => EntityPositionUpdateHandler;
        }

        public Action<ulong, string, MValue> OnEntityDataUpdate
        {
            set => EntityDataUpdateHandler += value;
            get => EntityDataUpdateHandler;
        }

        public Action<Entity.Entity, IPlayer> OnEntityStreamIn
        {
            set => EntityStreamInHandler += value;
            get => EntityStreamInHandler;
        }

        public Action<Entity.Entity, IPlayer> OnEntityStreamOut
        {
            set => EntityStreamOutHandler += value;
            get => EntityStreamOutHandler;
        }

        public readonly Dictionary<ulong, Entity.Entity> Entities = new Dictionary<ulong, Entity.Entity>();

        private readonly Dictionary<ulong, HashSet<IPlayer>> streamedInPlayers =
            new Dictionary<ulong, HashSet<IPlayer>>();

        // Stores the version of the entity data to not transfer already transferred data
        private readonly Dictionary<IPlayer, Dictionary<ulong, ulong>> playerEntityDataSnapshotVersions =
            new Dictionary<IPlayer, Dictionary<ulong, ulong>>();

        // Stores the entities snapshot version, maybe wrap entity in own object so we get more control over creation ect. and don't need this dictionary
        private readonly Dictionary<ulong, ulong> entitiesSnapshotVersions =
            new Dictionary<ulong, ulong>();

        public void Add(Entity.Entity entity)
        {
            lock (Entities)
            {
                Entities[entity.Id] = entity;
                if (EntityAddHandler == null) return;
                EntityAddHandler(entity);
            }
        }

        public Entity.Entity Get(ulong id)
        {
            lock (Entities)
            {
                return Entities[id];
            }
        }

        public void Delete(ulong id)
        {
            lock (Entities)
            {
                if (!Entities.Remove(id)) return;
                if (EntityRemoveHandler == null) return;
                EntityRemoveHandler(id);
            }
        }

        public void UpdatePosition(ulong id, Position position)
        {
            lock (Entities)
            {
                var entity = Entities[id];
                entity.Position = position;
                if (EntityPositionUpdateHandler == null) return;
                EntityPositionUpdateHandler(id, position);
            }
        }

        public void UpdateData(ulong id, string key, MValue value)
        {
            lock (Entities)
            {
                //TODO: increase snapshot version
                var entity = Entities[id];
                entity.Data[key] = value;
                IncreaseEntitySnapshotVersion(id);
                if (EntityDataUpdateHandler == null) return;
                EntityDataUpdateHandler(id, key, value);
            }
        }

        public void StreamedIn(IPlayer player, ulong id)
        {
            lock (Entities)
            {
                if (!streamedInPlayers.TryGetValue(id, out var players))
                {
                    players = new HashSet<IPlayer>();
                    streamedInPlayers[id] = players;
                }

                if (!players.Add(player)) return;
                if (EntityStreamInHandler == null) return;
                if (Entities.TryGetValue(id, out var entity))
                {
                    EntityStreamInHandler(entity, player);
                }
            }
        }

        public void StreamedOut(IPlayer player, ulong id)
        {
            lock (Entities)
            {
                if (!streamedInPlayers.TryGetValue(id, out var players)) return;
                if (!players.Remove(player)) return;
                if (EntityStreamOutHandler == null) return;
                if (Entities.TryGetValue(id, out var entity))
                {
                    EntityStreamOutHandler(entity, player);
                }
            }
        }

        // Not thread safe, needs to be called in one of the listeners
        public HashSet<IPlayer> GetStreamedInPlayers(ulong id)
        {
            return streamedInPlayers.TryGetValue(id, out var players) ? players : null;
        }

        public IEnumerable<Entity.Entity> GetAll()
        {
            lock (Entities)
            {
                return new Dictionary<ulong, Entity.Entity>(Entities).Values;
            }
        }

        //TODO: handle overflow, needs another flag in entity, we need a own entity object now for sure
        private void IncreaseEntitySnapshotVersion(ulong id)
        {
            if (entitiesSnapshotVersions.TryGetValue(id, out var snapshotVersion))
            {
                entitiesSnapshotVersions[id] = ++snapshotVersion;
            }
            else
            {
                entitiesSnapshotVersions[id] = 1;
            }
        }

        //TODO: This method believes that the player will always receive newest snapshot after execution, this needs to change in the future
        //TODO: keep snapshot version of each entity data and when a data is removed, increase snapshot version because players needs to know updated value
        public bool DoesPlayerNeedsNewData(ulong id, IPlayer player)
        {
            Dictionary<ulong, ulong> snapshots;
            if (!playerEntityDataSnapshotVersions.TryGetValue(player, out snapshots))
            {
                snapshots = new Dictionary<ulong, ulong>();
                playerEntityDataSnapshotVersions[player] = snapshots;
            }

            if (snapshots.TryGetValue(id, out var currSnapshot))
            {
                if (entitiesSnapshotVersions.TryGetValue(id, out var entitySnapshot))
                {
                    snapshots[id] = entitySnapshot;
                    return entitySnapshot > currSnapshot;
                }
                else // entity doesn't has a snapshot anymore, so we remove player snapshot as well
                {
                    snapshots.Remove(id);
                    return true;
                }
            }
            else // player never received data, send it now
            {
                if (entitiesSnapshotVersions.TryGetValue(id, out var entitySnapshot))
                {
                    snapshots[id] = entitySnapshot;
                    return true;
                }
                else // Entity doesnt has a snapshot, so it has no data
                {
                    return false;
                }
            }
        }
    }
}