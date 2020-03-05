using AltV.Net.Client.Events;
using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client
{
    internal class NativeAlt
    {
        private readonly JSObject alt;

        private readonly Function log;

        private readonly Function on;

        private readonly Function off;

        private readonly Function onServer;

        private readonly Function offServer;

        private readonly Function emit;

        private readonly Function emitServer;

        private readonly Function everyTick;

        public NativeAlt(JSObject alt)
        {
            this.alt = alt;
            log = (Function) alt.GetObjectProperty("log");
            on = (Function) alt.GetObjectProperty("on");
            off = (Function) alt.GetObjectProperty("off");
            onServer = (Function) alt.GetObjectProperty("onServer");
            offServer = (Function) alt.GetObjectProperty("offServer");
            emit = (Function) alt.GetObjectProperty("emit");
            emitServer = (Function) alt.GetObjectProperty("emitServer");
            everyTick = (Function) alt.GetObjectProperty("everyTick");
        }

        public void Log(string message)
        {
            log.Call(alt, message);
        }

        public void On(string eventName, object eventHandler)
        {
            on.Call(alt, eventName, eventHandler);
        }

        public void Off(string eventName, object eventHandler)
        {
            off.Call(alt, eventName, eventHandler);
        }

        public void OnServer(string eventName, NativeEventDelegate serverEventDelegate)
        {
            onServer.Call(alt, eventName, serverEventDelegate);
        }
        
        public void OffServer(string eventName, NativeEventDelegate serverEventDelegate)
        {
            offServer.Call(alt, eventName, serverEventDelegate);
        }
        
        public void Emit(string eventName, params object[] args)
        {
            emit.Call(alt, eventName, args);
        }
        
        public void EmitServer(string eventName, params object[] args)
        {
            emitServer.Call(alt, eventName, args);
        }

        public void EveryTick(EveryTickEventDelegate everyTickEventDelegate)
        {
            everyTick.Call(alt, everyTickEventDelegate);
        }
    }
}