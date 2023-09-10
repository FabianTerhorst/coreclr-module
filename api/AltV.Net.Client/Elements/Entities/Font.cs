using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class Font : BaseObject, IFont
{
    public static IntPtr GetBaseObjectNativePointer(ICore core, IntPtr fontNativePointer)
    {
        unsafe
        {
            return core.Library.Client.Font_GetBaseObject(fontNativePointer);
        }
    }

    public Font(ICore core, IntPtr fontNativePointer, uint id) : base(core, GetBaseObjectNativePointer(core, fontNativePointer), BaseObjectType.Font, id)
    {
        FontNativePointer = fontNativePointer;
    }

    public IntPtr FontNativePointer { get; }
    public override IntPtr NativePointer => FontNativePointer;
}