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
    }
}