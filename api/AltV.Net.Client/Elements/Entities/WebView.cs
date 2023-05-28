using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
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
        public override IntPtr NativePointer => WebViewNativePointer;

        public WebView(ICore core, IntPtr webViewNativePointer, uint id) : base(core, GetBaseObjectPointer(core, webViewNativePointer), BaseObjectType.Webview, id)
        {
            WebViewNativePointer = webViewNativePointer;
        }

        [Obsolete("Use Alt.CreateWebView instead")]
        public WebView(ICore core, string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null)
            : this(core, core.CreateWebViewPtr(out var id, url, isOverlay, pos, size), id)
        {
            core.PoolManager.WebView.Add(this);
        }

        [Obsolete("Use Alt.CreateWebView instead")]
        public WebView(ICore core, string url, uint propHash, string targetTexture)
            : this(core, core.CreateWebViewPtr(out var id,url, propHash, targetTexture), id)
        {
            core.PoolManager.WebView.Add(this);
        }

        public bool Focused
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    return Core.Library.Client.WebView_IsVisible(WebViewNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    var vector = Vector2.Zero;
                    Core.Library.Client.WebView_GetPosition(WebViewNativePointer, &vector);
                    return vector;
                }
            }
        }

        public Vector2 Size
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var vector = Vector2.Zero;
                    Core.Library.Client.WebView_GetSize(WebViewNativePointer, &vector);
                    return vector;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                    CheckIfEntityExists();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(
                        Core.Library.Client.WebView_GetUrl(WebViewNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
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
                CheckIfEntityExists();
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
                CheckIfEntityExists();
                Core.Library.Client.WebView_SetZoomLevel(WebViewNativePointer, zoomLevel);
            }
        }

        public void Focus()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.WebView_Focus(WebViewNativePointer);
            }
        }

        public void Unfocus()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.WebView_Unfocus(WebViewNativePointer);
            }
        }

        #region Webview Emit

        private void TriggerWebviewEvent(string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerWebviewEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        private void TriggerWebviewEvent(IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerWebviewEvent(eventNamePtr, mValuePointers);
        }

        private void TriggerWebviewEvent(string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerWebviewEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void TriggerWebviewEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.Core_TriggerWebViewEvent(Core.NativePointer, WebViewNativePointer, eventNamePtr, args, args.Length);
            }
        }
        public void Emit(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            Core.CreateMValues(mValues, args);
            TriggerWebviewEvent(eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        #endregion

    }
}