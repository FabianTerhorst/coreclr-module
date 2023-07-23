using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockWorldObject : WorldObject
    {
        public MockWorldObject(ICore core, IntPtr nativePointer, BaseObjectType type, uint id) : base(core, nativePointer, type, id)
        {
        }
    }
}