using System.Numerics;

namespace AltV.Net.Client.Elements.Entities
{
    public interface IWorldObject : IBaseObject
    {
        public IntPtr WorldObjectNativePointer { get; }
        public Vector3 Position { get; }
    }
}