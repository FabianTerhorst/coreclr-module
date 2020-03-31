using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AltV.Net.Client.Elements
{
    public interface IWebView : IBaseObject
    {
        bool IsVisible { get; set; }
        string Url { get; set; }

        void Emit(string eventNaame, params object[] args);
        void On(string eventName, ServerEventDelegate serverEventDelegate);
        void Off(string eventName, ServerEventDelegate serverEventDelegate);

        void Focus();
        void Unfocus();


    }
}
