using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    public class NativeAreaBlip
    {
        private readonly JSObject areaBlip;

        private readonly Function constructor;

        public NativeAreaBlip(JSObject areaBlip)
        {
            this.areaBlip = areaBlip;
            constructor = (Function) areaBlip.GetObjectProperty("constructor");
        }

        public JSObject New(float x, float y, float z, float width, float height)
        {
            return (JSObject) constructor.Call(areaBlip, x, y, z, width, height);
        }
    }
}