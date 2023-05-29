using AltV.Net.Client.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Interfaces;

public interface ILocalPed : IPed
{
    new uint Model { get; set; }
    uint StreamingDistance { get; }
    bool Visible { get; set; }
    bool IsStreamedIn { get; }
}