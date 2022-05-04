using System.Numerics;

namespace AltV.Net.Client.Elements.Interfaces
{
    public interface IWebView : IBaseObject
    {
        IntPtr WebViewNativePointer { get; }
        bool Focused { get; set; }
        bool Overlay { get; }
        bool Visible { get; set; }
        Vector2 Position { get; }
        Vector2 Size { get; set; }
        string Url { get; set; }

        void SetExtraHeader(string key, string value);
        void SetZoomLevel(float zoomLevel);
        void Focus();
        void Unfocus();
        void Emit(string eventName, params object[] args);
    }
}