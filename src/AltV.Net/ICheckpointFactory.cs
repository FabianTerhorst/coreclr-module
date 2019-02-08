using System;
using AltV.Net.Elements.Entities;

namespace AltV.Net
{
    public interface ICheckpointFactory
    {
        ICheckpoint Create(IntPtr checkpointPointer);
    }
}