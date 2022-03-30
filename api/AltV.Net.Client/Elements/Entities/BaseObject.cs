using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities
{
    public class BaseObject : SharedBaseObject, IBaseObject
    {
        public override IntPtr BaseObjectNativePointer { get; }
        public override IntPtr NativePointer => BaseObjectNativePointer;
        public override ICore Core { get; }
        public override BaseObjectType Type { get; }

        public BaseObject(ICore core, IntPtr baseObjectPointer, BaseObjectType type)
        {
            Core = core;
            BaseObjectNativePointer = baseObjectPointer;
            Type = type;

            if (baseObjectPointer == IntPtr.Zero)
            {
                throw new BaseObjectRemovedException(this);
            }
            
            exists = true;
        }
    }
}