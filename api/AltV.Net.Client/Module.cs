using System.Reflection;
using AltV.Net.Client.CApi.Events;
using AltV.Net.Client.Elements.Args;
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

        private Dictionary<string, HashSet<Function.Function>> ServerEventBus = new();

        internal readonly IEventHandler<TickDelegate> TickEventHandler =
            new HashSetEventHandler<TickDelegate>();
        
        public void OnServerEvent(string name, IntPtr[] args)
        {
            var mValues = MValueConst.CreateFrom(args);

            if (!ServerEventBus.ContainsKey(name)) return;
            foreach (var function in ServerEventBus[name])
            {
                try
                {
                    function.Call(mValues);
                }
                catch (TargetInvocationException exception)
                {
                    Alt.Log($"Exception at server event \"{name}\" handler: {exception.InnerException}");
                }
                catch (Exception exception)
                {
                    Alt.Log($"Exception at server event \"{name}\" handler: {exception}");
                }
            }
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
                    Alt.Log("Exception at event OnTick: " + exception.InnerException);
                }
                catch (Exception exception)
                {
                    Alt.Log("Exception at event OnTick: " + exception);
                }
            }
        }
        
        public Function.Function AddServerEventListener(string eventName, Function.Function function)
        {
            if (ServerEventBus.TryGetValue(eventName, out var eventHandlers))
            {
                eventHandlers.Add(function);
            }
            else
            {
                eventHandlers = new HashSet<Function.Function> {function};
                ServerEventBus[eventName] = eventHandlers;
            }

            return function;
        }
    }
}