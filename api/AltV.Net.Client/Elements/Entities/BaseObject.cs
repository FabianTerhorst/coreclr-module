namespace AltV.Net.Client.Elements.Entities
{
    public class BaseObject : IBaseObject
    {
        protected ICore Core { get; }
        public IntPtr BaseObjectNativePointer { get; }
        
        public BaseObject(ICore core, IntPtr baseObjectPointer)
        {
            Core = core;
            BaseObjectNativePointer = baseObjectPointer;
        }
    }
}