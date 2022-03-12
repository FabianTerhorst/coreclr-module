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

    public delegate void PlayerSpawnModuleDelegate();
    public delegate void PlayerDisconnectModuleDelegate();
    public delegate void PlayerEnterVehicleModuleDelegate(ushort id, byte seat);

    public delegate void ResourceErrorModuleDelegate(string name);
    public delegate void ResourceStartModuleDelegate(string name);
    public delegate void ResourceStopModuleDelegate(string name);
    
    public delegate void KeyDownModuleDelegate(uint key);
    public delegate void KeyUpModuleDelegate(uint key);
}