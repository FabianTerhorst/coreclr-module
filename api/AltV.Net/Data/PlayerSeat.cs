using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Data;

public struct InternalPlayerSeat
{
    public IntPtr PlayerPointer { get; set; }
    public byte Seat { get; set; }
}

public struct PlayerSeat
{
    public IPlayer Player { get; set; }
    public byte Seat { get; set; }
}