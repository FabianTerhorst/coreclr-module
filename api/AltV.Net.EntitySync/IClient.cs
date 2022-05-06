using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    public interface IClient
    {
        string Token { get; }
        
        Vector3 Position { get; set; }
        
        int Dimension { get; set; }
        
        ClientDataSnapshot Snapshot { get; }
        
        bool Exists { get; }

        public bool TryGetDimensionAndPosition(out int dimension, ref Vector3 position);

        public void SetPositionOverride(Vector3 newPositionOverride);

        public void ResetPositionOverride();

        /// <summary>
        /// Tries to add a entity to the list of entities that this client got created.
        /// </summary>
        /// <param name="threadIndex"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool TryAddEntity(ulong threadIndex, IEntity entity);

        void RemoveEntity(ulong threadIndex, IEntity entity);

        void RemoveEntityFully(ulong threadIndex, IEntity entity);

        void AddCheck(ulong threadIndex, IEntity entity);

        void RemoveCheck(ulong threadIndex, IEntity entity);

        IDictionary<IEntity, bool> GetLastCheckedEntities(ulong threadIndex);

        Dictionary<IEntity, bool> GetEntities(ulong threadIndex);
    }
}