using System.Numerics;

namespace AltV.Net.EntitySync.Entities
{
    public static class EntitySyncBlip
    {
        public static BlipEntity Create(Vector3 position, int dimension, uint range)
        {
            var entity = new BlipEntity(position, dimension, range);
            AltEntitySync.AddEntity(entity);
            return entity;
        }
    }
}