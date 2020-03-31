using AltV.Net.Client.Elements.Entities;
using WebAssembly;

namespace AltV.Net.Client.Elements.Factories
{
    public class PlayerFactory : IBaseObjectFactory<IPlayer>
    {
        public IPlayer Create(JSObject jsObject)
        {
            return new Player(jsObject);
        }
    }
}