namespace AltV.Net.Client.CApi.Events
{
    public delegate void TickDelegate();
        
    public delegate void ServerEventDelegate(string name, IntPtr args, ulong size);
    
    public delegate void CreatePlayerDelegate(IntPtr pointer, ushort id);
    public delegate void RemovePlayerDelegate(ushort id);
    
    public delegate void CreateVehicleDelegate(IntPtr pointer, ushort id);
    public delegate void RemoveVehicleDelegate(ushort id);
}