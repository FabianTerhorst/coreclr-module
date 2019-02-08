using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IPlayerFactory
    {
        IPlayer Create(IntPtr playerPointer);
    }
}