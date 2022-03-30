using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IEntity : ISharedEntity, IWorldObject
    {
        new IPlayer? NetworkOwner { get; }
        int ScriptId { get; }
    }
}