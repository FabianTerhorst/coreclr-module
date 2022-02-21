using System.Reflection;
using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Events;

namespace AltV.Net.Client
{
    public class Module
    {
        internal readonly IClient Client;
    
        public Module(IClient client)
        {
            Alt.Init(this);
            Client = client;
        }
        
        internal readonly IEventHandler<TickDelegate> TickEventHandler =
            new HashSetEventHandler<TickDelegate>();
        
        public void OnServerEvent(string name, IntPtr[] args)
        {
            // todo
        }
        
        public void OnTick()
        {
            foreach (var @delegate in TickEventHandler.GetEvents())
            {
                try
                {
                    @delegate();
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDamageEvent" + ":" + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("exception at event:" + "OnPlayerDamageEvent" + ":" + exception);
                }
            }
        }
    }
}