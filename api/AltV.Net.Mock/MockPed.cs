using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock;

public class MockPed : Ped
{
    public MockPed(ICore core, IntPtr nativePointer, uint id): base(core, nativePointer, id)
    {
    }
}