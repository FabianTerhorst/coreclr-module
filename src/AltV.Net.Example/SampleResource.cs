using AltV.Net.Elements.Entities;

namespace AltV.Net.Example
{
    public class SampleResource : IResource
    {
        public void OnStart()
        {
            Alt.On<string>("test", s => { Alt.Log("test=" + s); });
            Alt.On("test", args => { Alt.Log("args=" + args[0]); });
            Alt.Emit("test", "bla");
            Alt.On("bla", bla);
            Alt.On<string>("bla2", bla2);
            Alt.On<string, bool>("bla3", bla3);
            Alt.On<string, string>("bla4", bla4);

            Alt.OnPlayerConnect += OnPlayerConnect;
            Alt.OnPlayerDisconnect += OnPlayerDisconnect;
            Alt.OnEntityRemove += OnEntityRemove;
        }

        private void OnPlayerConnect(IPlayer player, string reason)
        {
        }

        private void OnPlayerDisconnect(IPlayer player, string reason)
        {
        }

        private void OnEntityRemove(IEntity entity)
        {
        }

        public void OnStop()
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