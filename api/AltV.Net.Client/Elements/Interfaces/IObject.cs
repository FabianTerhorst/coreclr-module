using System.Numerics;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IObject : ISharedObject, IEntity
    {
        bool IsRemote { get; }
        bool IsStreamedIn { get; }
    }
}