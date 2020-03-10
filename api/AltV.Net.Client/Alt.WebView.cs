using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Entities;

namespace AltV.Net.Client
{
    public static partial class Alt
    {
        public static IWebView CreateWebView(string url, bool isOverlay = false)
        {
            return new WebView(WebView.New(url, isOverlay));
        }

        public static IWebView CreateWebView(string url, uint propHash, string targetTexture)
        {
            return new WebView(WebView.New(url, propHash, targetTexture));
        }
    }
}