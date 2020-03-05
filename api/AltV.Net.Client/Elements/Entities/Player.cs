using WebAssembly;

namespace AltV.Net.Client.Elements.Entities
{
    public class Player
    {
        private static JSObject player;

        private static JSObject prototype;

        internal static void Init(JSObject alt)
        {
            player = (JSObject) alt.GetObjectProperty("Player");
            prototype = (JSObject) player.GetObjectProperty("prototype");
        }
    }
}