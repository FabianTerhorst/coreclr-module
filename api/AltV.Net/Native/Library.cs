using System.Runtime.InteropServices;
using AltV.Net.Data;

namespace AltV.Net.Native
{
    public unsafe interface ILibrary
    {
        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetNetworkOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, Position*, void> Player_GetPosition { get; }
    }
    
    public unsafe class Library : ILibrary
    {
        private const string DllName = "csharp-module";

        public delegate* unmanaged[Cdecl]<nint, ushort> Player_GetID { get; }
        public delegate* unmanaged[Cdecl]<nint, nint> Player_GetNetworkOwner { get; }
        public delegate* unmanaged[Cdecl]<nint, uint> Player_GetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, uint, void> Player_SetModel { get; }
        public delegate* unmanaged[Cdecl]<nint, Position*, void> Player_GetPosition { get; }

        public Library()
        {
            var handle = NativeLibrary.Load(DllName);
            Player_GetID = (delegate* unmanaged[Cdecl]<nint, ushort>) NativeLibrary.GetExport(handle, "Player_GetID");
            Player_GetNetworkOwner = (delegate* unmanaged[Cdecl]<nint, nint>) NativeLibrary.GetExport(handle, "Player_GetNetworkOwner");
            Player_GetModel = (delegate* unmanaged[Cdecl]<nint, uint>) NativeLibrary.GetExport(handle, "Player_GetModel");
            Player_SetModel = (delegate* unmanaged[Cdecl]<nint, uint, void>) NativeLibrary.GetExport(handle, "Player_SetModel");
            Player_GetPosition = (delegate* unmanaged[Cdecl]<nint, Position*, void>) NativeLibrary.GetExport(handle, "Player_GetPosition");
        }
    }
}