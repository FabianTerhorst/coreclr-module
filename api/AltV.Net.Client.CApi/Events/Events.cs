namespace AltV.Net.Client.CApi.Events
{
    public delegate void TickDelegate();
        
    public delegate void ServerEventDelegate(string name, IntPtr args, ulong size);
}