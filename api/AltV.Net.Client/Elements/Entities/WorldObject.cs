using System.Numerics;
using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class WorldObject : BaseObject, IWorldObject
    {
        public Vector3 Position
        {
            get
            {
                var vector3Obj = (JSObject) jsObject.GetObjectProperty("pos");
                return new Vector3((float) vector3Obj.GetObjectProperty("x"), (float) vector3Obj.GetObjectProperty("y"),(float) vector3Obj.GetObjectProperty("z"));
            }
            set
            {
                var vector3Obj = Runtime.NewJSObject();
                vector3Obj.SetObjectProperty("x", value.X);
                vector3Obj.SetObjectProperty("y", value.Y);
                vector3Obj.SetObjectProperty("z", value.Z);
                jsObject.SetObjectProperty("pos", vector3Obj);
            }
        }

        public WorldObject(JSObject jsObject): base(jsObject)
        {
            
        }
    }
}