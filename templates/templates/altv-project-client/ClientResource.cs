using AltV.Net.Client;

namespace Template.Client;

public class ClientResource : Resource
{
    public override void OnStart()
    {
        Console.WriteLine("Resource started!");
    }
    
    public override void OnStop()
    {
        Console.WriteLine("Resource stopped!");
    }
}