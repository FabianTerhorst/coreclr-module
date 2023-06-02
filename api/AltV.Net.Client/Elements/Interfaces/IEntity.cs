using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IEntity : ISharedEntity, IWorldObject
    {
        new IPlayer? NetworkOwner { get; }
        uint ScriptId { get; }
        bool Spawned { get; }

        new Position Position { get; set; }
        new Rotation Rotation { get; set; }
    }
}