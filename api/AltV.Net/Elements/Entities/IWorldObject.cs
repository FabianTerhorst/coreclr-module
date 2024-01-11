using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface IWorldObject : ISharedWorldObject, IBaseObject
    {
        void SetPosition((float X, float Y, float Z) position);

        void SetPosition(float x, float y, float z);

        (float X, float Y, float Z) GetPosition();
    }
}