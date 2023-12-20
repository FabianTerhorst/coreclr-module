using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities
{
    public class RmlDocument : RmlElement, IRmlDocument
    {
        private static IntPtr GetRmlElementPointer(ICore core, IntPtr rmlDocumentPointer)
        {
            unsafe
            {
                return core.Library.Client.RmlDocument_GetRmlElement(rmlDocumentPointer);
            }
        }

        public IntPtr RmlDocumentNativePointer { get; }
        public override IntPtr NativePointer => RmlDocumentNativePointer;

        public RmlDocument(ICore core, IntPtr rmlDocumentPointer, uint id) : base(core, GetRmlElementPointer(core, rmlDocumentPointer), BaseObjectType.RmlDocument, id)
        {
            RmlDocumentNativePointer = rmlDocumentPointer;
        }

        [Obsolete("Use Alt.CreateRmlDocument instead")]
        public RmlDocument(ICore core, string url) : this(core, core.CreateRmlDocumentPtr(out var id, url), id)
        {
            core.PoolManager.RmlDocument.Add(this);
        }

        public IRmlElement Body
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var ptr = Core.Library.Client.RmlDocument_GetBody(RmlDocumentNativePointer);
                    return Core.PoolManager.RmlElement.GetOrCreate(Core, ptr);
                }
            }
        }

        public string SourceUrl
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Client.RmlDocument_GetSourceUrl(RmlDocumentNativePointer, &size), size);
                }
            }
        }

        public bool IsModal
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.RmlDocument_IsModal(RmlDocumentNativePointer) == 1;
                }
            }
        }

        public bool IsVisible
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Client.RmlDocument_IsVisible(RmlDocumentNativePointer) == 1;
                }
            }
        }

        public string Title
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Client.RmlDocument_GetTitle(RmlDocumentNativePointer, &size), size);
                }
            }

            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var strPtr = MemoryUtils.StringToHGlobalUtf8(value);
                    Core.Library.Client.RmlDocument_SetTitle(RmlDocumentNativePointer, strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        public IRmlElement CreateElement(string tag)
        {
            unsafe
            {
                CheckIfEntityExists();
                var strPtr = MemoryUtils.StringToHGlobalUtf8(tag);
                uint id = default;
                var ptr = Core.Library.Client.RmlDocument_CreateElement(RmlDocumentNativePointer, strPtr, &id);
                Marshal.FreeHGlobal(strPtr);
                return Core.PoolManager.RmlElement.Create(Core, ptr, id);
            }
        }

        public IRmlElement CreateTextNode(string text)
        {
            unsafe
            {
                CheckIfEntityExists();
                var strPtr = MemoryUtils.StringToHGlobalUtf8(text);

                uint id = default;
                var ptr = Core.Library.Client.RmlDocument_CreateTextNode(RmlDocumentNativePointer, strPtr, &id);
                Marshal.FreeHGlobal(strPtr);
                return Core.PoolManager.RmlElement.Create(Core, ptr, id);
            }
        }

        public void Hide()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.RmlDocument_Hide(RmlDocumentNativePointer);
            }
        }

        public void Show(bool isModal = false, bool focused = true)
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.RmlDocument_Show(RmlDocumentNativePointer, (byte) (isModal ? 1 : 0), (byte) (focused ? 1 : 0));
            }
        }

        public void Update()
        {
            unsafe
            {
                CheckIfEntityExists();
                Core.Library.Client.RmlDocument_Update(RmlDocumentNativePointer);
            }
        }
    }
}