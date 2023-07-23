using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Object = AltV.Net.Elements.Entities.Object;

namespace AltV.Net.Mock;

public class MockObject : Object
{
    public MockObject(ICore core, IntPtr nativePointer, uint id): base(core, nativePointer, id)
    {
    }
}