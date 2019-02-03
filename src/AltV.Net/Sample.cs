using System;

namespace AltV.Net
{
    public class Sample : IResource
    {
        public void onStart()
        {
            Alt.On("test", Function.Create<Action<string>>(s => { Alt.Server.LogInfo("test=" + s); }));
            Alt.Server.TriggerServerEvent("test", "bla");
        }

        public void onStop()
        {
        }
    }
}