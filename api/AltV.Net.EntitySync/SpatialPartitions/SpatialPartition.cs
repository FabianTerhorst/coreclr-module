using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    public abstract class SpatialPartition
    {
        public abstract void Add(IEntity entity);

        public abstract void Remove(IEntity entity);

        /// <summary>
        /// Updates the entity position, some algorithms might just call remove and add, depending on the possibilities
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="newPosition"></param>
        public abstract void UpdateEntityPosition(IEntity entity, in Vector3 newPosition);

        /// <summary>
        /// Updates the entity range, some algorithms might just call remove and add, depending on the possibilities
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="range"></param>
        public abstract void UpdateEntityRange(IEntity entity, uint range);
        
        /// <summary>
        /// Updates the entity dimension, some algorithms might just call remove and add, depending on the possibilities
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="dimension"></param>
        public abstract void UpdateEntityDimension(IEntity entity, int dimension);

        public abstract IEnumerable<IEntity> Find(Vector3 position, int dimension);
    }
}