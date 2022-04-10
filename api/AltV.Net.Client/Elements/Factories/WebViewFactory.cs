using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Factories
{
    public class WebViewFactory : IBaseObjectFactory<IWebView>
    {
        public IWebView Create(ICore core, IntPtr blipPointer)
        {
            return new WebView(core, blipPointer);
        }
    }
}