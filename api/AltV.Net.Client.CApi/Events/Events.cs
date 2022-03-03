using System.Runtime.InteropServices;

namespace AltV.Net.Client.CApi.Events
{
    public delegate void TickModuleDelegate();
        
    public delegate void ClientEventModuleDelegate(string name, IntPtr args, ulong size);
    public delegate void ServerEventModuleDelegate(string name, IntPtr args, ulong size);
    public delegate void ConsoleCommandModuleDelegate(string name, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] string[] args, int argsSize);
    
    public delegate void CreatePlayerModuleDelegate(IntPtr pointer, ushort id);
    public delegate void RemovePlayerModuleDelegate(ushort id);
    
    public delegate void CreateVehicleModuleDelegate(IntPtr pointer, ushort id);
    public delegate void RemoveVehicleModuleDelegate(ushort id);
}