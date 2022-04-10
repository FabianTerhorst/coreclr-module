using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class WebViewPool : BaseObjectPool<IWebView>
    {
        public WebViewPool(IBaseObjectFactory<IWebView> webViewFactory) : base(webViewFactory)
        {
        }
    }
}