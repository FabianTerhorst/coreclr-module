using System;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockVirtualEntityGroup : MockWorldObject, IVirtualEntityGroup
    {
        public MockVirtualEntityGroup(ICore core, IntPtr nativePointer, uint id) : base(core, nativePointer, BaseObjectType.VirtualEntityGroup, id)
        {
        }

        public IntPtr VirtualEntityGroupNativePointer { get; }
        public uint MaxEntitiesInStream { get; }
    }
}