using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class WebViewPool : BaseObjectPool<IWebView>
    {
        public WebViewPool(IBaseObjectFactory<IWebView> webViewFactory) : base(webViewFactory)
        {
        }

        public override uint GetId(IntPtr entityPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.WebView_GetID(entityPointer);
            }
        }
    }
}