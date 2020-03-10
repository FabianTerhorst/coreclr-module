using System;
using System.Collections.Generic;
using System.Text;
using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client.Elements
{
    internal class NativeWebView
    {
        private readonly JSObject webView;

        private readonly Function constructor;
        private readonly Function on;
        private readonly Function off;
        private readonly Function emit;

        public NativeWebView(JSObject webView)
        {
            this.webView = webView;
            constructor = (Function)webView.GetObjectProperty("constructor");
            on = (Function)webView.GetObjectProperty("on");
            off = (Function)webView.GetObjectProperty("off");
            emit = (Function)webView.GetObjectProperty("emit");
        }

        public JSObject New(string url, bool isOverlay = false)
        {
            return (JSObject)constructor.Call(webView, url, isOverlay);
        }

        public void On(string eventName, object eventHandler)
        {
            on.Call(webView, eventName, eventHandler);
        }

        public void Off(string eventName, object eventHandler)
        {
            off.Call(webView, eventName, eventHandler);
        }

        public void Emit(string eventName, params object[] args)
        {
            emit.Call(webView, eventName, args);
        }
    }
}
