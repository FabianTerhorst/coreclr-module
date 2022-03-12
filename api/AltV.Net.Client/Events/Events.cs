using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Events
{
    public delegate void TickDelegate();
    public delegate void ConsoleCommandDelegate(string name, string[] args);
    public delegate void PlayerSpawnDelegate();
    public delegate void PlayerDisconnectDelegate();
    public delegate void PlayerEnterVehicleDelegate(IVehicle vehicle, byte seat);
    
    public delegate void ResourceErrorDelegate(string name);
    public delegate void ResourceStartDelegate(string name);
    public delegate void ResourceStopDelegate(string name);
    
    public delegate void KeyUpDelegate(ConsoleKey key);
    public delegate void KeyDownDelegate(ConsoleKey key);
}