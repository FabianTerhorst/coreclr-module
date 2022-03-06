using System;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockWorldObject : WorldObject
    {
        public MockWorldObject(IServer server, IntPtr nativePointer, BaseObjectType type) : base(server, nativePointer, type)
        {
        }
    }
}