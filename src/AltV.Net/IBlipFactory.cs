using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface IBlipFactory
    {
        IBlip Create(IntPtr blipPointer);
    }
}