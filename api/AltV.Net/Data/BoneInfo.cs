using System.Runtime.InteropServices;

namespace AltV.Net.Data;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct BoneInfo
{
    public ushort Id;
    public ushort Index;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string Name;
}
