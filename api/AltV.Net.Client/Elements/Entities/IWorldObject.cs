using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IWorldObject : IBaseObject
    {
        public Vector3 Position { get; }
    }
}