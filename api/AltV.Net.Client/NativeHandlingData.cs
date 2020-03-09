using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    public class NativeHandlingData
    {
        private readonly JSObject handlingData;

        private readonly Function getForModel;

        public NativeHandlingData(JSObject handlingData)
        {
            this.handlingData = handlingData;
            getForModel = (Function) handlingData.GetObjectProperty("getForModel");
        }

        public JSObject GetForModel(uint modelHash)
        {
            return (JSObject) getForModel.Call(handlingData, modelHash);
        }
    }
}