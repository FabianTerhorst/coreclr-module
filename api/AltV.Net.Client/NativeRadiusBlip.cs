using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    public class NativeRadiusBlip
    {
        private readonly JSObject radiusBlip;

        private readonly Function constructor;

        public NativeRadiusBlip(JSObject radiusBlip)
        {
            this.radiusBlip = radiusBlip;
            constructor = (Function) radiusBlip.GetObjectProperty("constructor");
        }

        public JSObject New(float x, float y, float z, float radius)
        {
            return (JSObject) constructor.Call(radiusBlip, x, y, z, radius);
        }
    }
}