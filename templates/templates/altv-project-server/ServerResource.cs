using AltV.Net;

namespace Template.Server;

public class ServerResource : Resource
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