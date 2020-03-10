using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IWorldObject : IBaseObject
    {
        Vector3 Position { get; set; }
    }
}