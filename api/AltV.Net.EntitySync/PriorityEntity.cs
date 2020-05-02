using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync
{
    public class PriorityEntity : Entity, IPriorityEntity
    {
        public bool IsHighPriority { get; set; }
        
        public PriorityEntity(ulong type, Vector3 position, int dimension, uint range) : base(type, position, dimension,
            range)
        {
        }

        public PriorityEntity(ulong type, Vector3 position, int dimension, uint range, IDictionary<string, object> data)
            : base(type, position, dimension, range, data)
        {
        }

        internal PriorityEntity(ulong id, ulong type, Vector3 position, int dimension, uint range,
            IDictionary<string, object> data) : base(id, type, position, dimension, range, data)
        {
        }
    }
}