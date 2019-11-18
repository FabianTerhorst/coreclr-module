using System.Collections.Generic;
using System.Numerics;
using AltV.Net.NetworkingEntity;
using Entity;

namespace AltV.Net.Networking.Example
{
    public class ObjectEntity : NetworkingEntity.Elements.Entities.NetworkingEntity
    {
        public ObjectEntity(IEntityStreamer entityStreamer, Entity.Entity streamedEntity) : base(entityStreamer,
            streamedEntity)
        {
        }

        public ObjectEntity(Position position, int dimension, float range, ulong model, Vector3 rotation) : base(
            position, dimension, range, new Dictionary<string, object>()
            {
                ["model"] = model,
                ["rotation"] = new Dictionary<string, object>()
                {
                    ["roll"] = rotation.X,
                    ["pitch"] = rotation.Y,
                    ["yaw"] = rotation.Z,
                }
            }, StreamingType.DataStreaming)
        {
        }
    }
}