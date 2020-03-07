using System;
using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    internal class NativePlayer
    {
        private readonly JSObject player;

        private readonly Function local;

        private readonly Function id;

        private readonly Function name;

        public NativePlayer(JSObject player)
        {
            this.player = player;
            
            /*var vector3 = (JSObject) alt.GetObjectProperty("Vector3");
            var vector3Prototype = (JSObject) vector3.GetObjectProperty("prototype");
            var vector3Instance2 = (JSObject) vector3Prototype.Invoke("constructor",1.0, 2.0, 3.0);
            Console.WriteLine(vector3Instance2?.GetType().Name);
            Console.WriteLine(vector3Instance2?.GetObjectProperty("x"));
            Console.WriteLine(vector3Instance2?.GetObjectProperty("y"));
            Console.WriteLine(vector3Instance2?.GetObjectProperty("z"));
            var vector3Constructor = (Function) vector3Prototype.GetObjectProperty("constructor");
            var vector3Instance = (JSObject) vector3Constructor.Call(null, 1.0, 2.0, 3.0);
            Console.WriteLine(vector3Instance?.GetType().Name);
            Console.WriteLine(vector3Instance.GetObjectProperty("x"));
            Console.WriteLine(vector3Instance.GetObjectProperty("y"));
            Console.WriteLine(vector3Instance.GetObjectProperty("z"));*/
            //local = (Function) ((JSObject)player.GetObjectProperty("constructor")).GetObjectProperty("local");
            //local = (Function) player.GetObjectProperty("local");
            //id = (Function) player.GetObjectProperty("id");
            //name = (Function) player.GetObjectProperty("name");
        }

        public JSObject Local()
        {
            return (JSObject) player.GetObjectProperty("local");
        }

        public int Id(JSObject instance)
        {
            return (int) instance.GetObjectProperty("id");
        }

        public string Name(JSObject instance)
        {
            return (string) instance.GetObjectProperty("name");
        }
    }
}