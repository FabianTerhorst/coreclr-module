using System;

namespace AltV.Net
{
    public class Sample : IResource
    {
        public void onStart()
        {
            Alt.On<string>("test", s => { Alt.Server.LogInfo("test=" + s); });
            Alt.Server.TriggerServerEvent("test", "bla");
            Alt.On("bla", bla);
            Alt.On<string>("bla2", bla2);
            Alt.On<string, bool>("bla3", bla3);
            Alt.On<string, string>("bla4", bla4);
        }

        public void onStop()
        {
        }

        public void bla()
        {
        }

        public void bla2(string test)
        {
        }

        public bool bla3(string test)
        {
            return true;
        }

        public void bla4(string test, string test2)
        {
        }
    }
}