using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.EventHandlers;
using AltV.Net.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using WebAssembly;
using WebAssembly.Core;

namespace AltV.Net.Client.Elements
{
    public class WebView : BaseObject, IWebView
    {
        private readonly IDictionary<string, NativeEventHandler<NativeEventDelegate, ServerEventDelegate>>  NativeEventHandlers = new Dictionary<string, NativeEventHandler<NativeEventDelegate, ServerEventDelegate>>();
        private readonly NativeWebView nativeWebView;

        public bool IsVisible
        {
            get => (bool)jsObject.GetObjectProperty("isVisible");
            set => jsObject.SetObjectProperty("isVisble", value);
        }
        public string Url
        {
            get => (string)jsObject.GetObjectProperty("url");
            set => jsObject.SetObjectProperty("url", value);
        }

        public WebView(JSObject jsObject) : base(jsObject)
        {
            nativeWebView = new NativeWebView(jsObject);
        }

        public override void Remove()
        {
            jsObject.Invoke("destroy");
        }

        public void Emit(string eventName, params object[] args) => nativeWebView.Emit(eventName, args);

        public void Focus() => nativeWebView.Focus();

        public void Unfocus() => nativeWebView.Unfocus();

        public void On(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (!NativeEventHandlers.TryGetValue(eventName, out var nativeEventHandler))
            {
                nativeEventHandler = new NativeServerEventHandler();
                nativeWebView.On(eventName, nativeEventHandler.GetNativeEventHandler());
                NativeEventHandlers[eventName] = nativeEventHandler;
            }

            nativeEventHandler.Add(serverEventDelegate);
        }

        public void Off(string eventName, ServerEventDelegate serverEventDelegate)
        {
            if (!NativeEventHandlers.TryGetValue(eventName, out var nativeEventHandler))
            {
                return;
            }
            nativeWebView.Off(eventName, nativeEventHandler.GetNativeEventHandler());
            nativeEventHandler.Remove(serverEventDelegate);
        }


    }
}
