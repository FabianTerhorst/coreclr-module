using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities
{
    public class WebView : BaseObject, IWebView
    {
        private static IntPtr GetBaseObjectPointer(ICore core, IntPtr webViewNativePointer)
        {
            unsafe
            {
                return core.Library.Client.WebView_GetBaseObject(webViewNativePointer);
            }
        }
        
        public IntPtr WebViewNativePointer { get; }
        
        public WebView(ICore core, IntPtr webViewNativePointer) : base(core, GetBaseObjectPointer(core, webViewNativePointer), BaseObjectType.Webview)
        {
            WebViewNativePointer = webViewNativePointer;
        }

        public bool Focused
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.WebView_IsFocused(WebViewNativePointer) == 1;
                }
            }
            
            set
            {
                if (value) this.Focus();
                else this.Unfocus();
            }
        }

        public bool Overlay
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.WebView_IsOverlay(WebViewNativePointer) == 1;
                }
            }
        }

        public bool Visible
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.WebView_IsVisible(WebViewNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    Core.Library.Client.WebView_SetIsVisible(WebViewNativePointer, (byte) (value ? 1 : 0));
                }
            }
        }

        public Vector2 Position
        {
            get
            {
                unsafe
                {
                    var vector = Vector2.Zero;
                    Core.Library.Client.WebView_GetPosition(WebViewNativePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    Core.Library.Client.WebView_SetPosition(WebViewNativePointer, value);
                }
            }
        }

        public Vector2 Size
        {
            get
            {
                unsafe
                {
                    var vector = Vector2.Zero;
                    Core.Library.Client.WebView_GetSize(WebViewNativePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    Core.Library.Client.WebView_SetSize(WebViewNativePointer, value);
                }
            }
        }

        public string Url
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Client.WebView_GetUrl(WebViewNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    var str = MemoryUtils.StringToHGlobalUtf8(value);
                    Core.Library.Client.WebView_SetUrl(WebViewNativePointer, str);
                    Marshal.FreeHGlobal(str);
                }
            }
        }

        public void SetExtraHeader(string key, string value)
        {
            unsafe
            {
                var keyPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var valuePtr = MemoryUtils.StringToHGlobalUtf8(value);
                Core.Library.Client.WebView_SetExtraHeader(WebViewNativePointer, keyPtr, valuePtr);
                Marshal.FreeHGlobal(keyPtr);
                Marshal.FreeHGlobal(valuePtr);
            }
        }

        public void SetZoomLevel(float zoomLevel)
        {
            unsafe
            {
                Core.Library.Client.WebView_SetZoomLevel(WebViewNativePointer, zoomLevel);
            }
        }

        public void Focus()
        {
            unsafe
            {
                Core.Library.Client.WebView_Focus(WebViewNativePointer);
            }
        }

        public void Unfocus()
        {
            unsafe
            {
                Core.Library.Client.WebView_Unfocus(WebViewNativePointer);
            }
        }
    }
}