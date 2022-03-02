using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;

namespace AltV.Net.Client
{
    public class Resource : IResource
    {
        public virtual void OnStart()
        {
            //
        }
        
        public virtual void OnStop()
        {
            //
        }
        
        public virtual IEntityFactory<IPlayer> GetPlayerFactory()
        {
            return new PlayerFactory();
        }
    }
}