using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    public class NativePointBlip
    {
        private readonly JSObject pointBlip;

        private readonly Function constructor;

        public NativePointBlip(JSObject pointBlip)
        {
            this.pointBlip = pointBlip;
            constructor = (Function) pointBlip.GetObjectProperty("constructor");
        }

        public JSObject New(float x, float y, float z)
        {
            return (JSObject) constructor.Call(pointBlip, x, y, z);
        }
    }
}