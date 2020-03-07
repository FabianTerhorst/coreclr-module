using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class Player
    {
        public static Player Local()
        {
            return new Player(Alt.Player.Local());
        }
        
        private readonly JSObject jsObject;
        
        public int Id => Alt.Player.Id(jsObject);

        public string Name => Alt.Player.Name(jsObject);

        private Player(JSObject jsObject)
        {
            this.jsObject = jsObject;
        }
    }
}