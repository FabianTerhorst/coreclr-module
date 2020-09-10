using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    //TODO: add another algorithm for area grids
    //TODO: that algorithm has a min and max area size and has multiple depths of areas with each deps having more or less areas depending on there size
    //TODO: this is needed to support global entities and entities with a large range
    
    //TODO: use e.g. aabb checks instead of distance for none limited grids
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

        public abstract IList<IEntity> Find(Vector3 position, int dimension);
    }
}