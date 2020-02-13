namespace AltV.Net.EntitySync.SpatialPartitions
{
    public class GridEntity
    {
        public readonly IEntity Entity;

        public GridEntity Prev;

        public GridEntity Next;

        public GridEntity(IEntity entity, GridEntity prev, GridEntity next)
        {
            Entity = entity;
            Prev = prev;
            Next = next;
        }
    }
}