using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class Player : Entity, IPlayer
    {
        public static Player Local()
        {
            return new Player(Alt.Player.Local());
        }

        public bool IsTalking => (bool) jsObject.GetObjectProperty("isTalking");
        
        public int MicLevel => (int) jsObject.GetObjectProperty("micLevel");
        
        public string Name => Alt.Player.Name(jsObject);

        public IVehicle Vehicle
        {
            get
            {
                var vehicleObj = (JSObject) jsObject.GetObjectProperty("vehicle");
                return vehicleObj == null ? null : new Vehicle(vehicleObj);
            }
        }

        internal Player(JSObject jsObject):base(jsObject)
        {
        }
    }
}