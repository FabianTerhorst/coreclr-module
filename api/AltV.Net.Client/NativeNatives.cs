using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    public class NativeNatives
    {
        private readonly JSObject native;

        private readonly Function drawRect;

        public NativeNatives(JSObject native)
        {
            this.native = native;
            drawRect = (Function) native.GetObjectProperty("drawRect");
        }

        //export function drawRect(x: number, y: number, width: number, height: number, r: number, g: number, b: number, a: number, p8: boolean): void;
        public void DrawRect(double x, double y, double width, double height, double r, double g, double b, double a,
            bool p8 = false)
        {
            drawRect.Call(native, x, y, width, height, r, g, b, a, p8);
        }
    }
}