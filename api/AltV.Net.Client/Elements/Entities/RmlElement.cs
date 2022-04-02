using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Entities
{
    public class RmlElement : BaseObject, IRmlElement
    {
        private static IntPtr GetBaseObjectPointer(ICore core, IntPtr rmlElementPointer)
        {
            unsafe
            {
                return core.Library.Client.RmlElement_GetBaseObject(rmlElementPointer);
            }
        }
        
        public IntPtr RmlElementNativePointer { get; }
        public override IntPtr NativePointer => RmlElementNativePointer;

        public RmlElement(ICore core, IntPtr rmlElementPointer) : base(core, GetBaseObjectPointer(core, rmlElementPointer), BaseObjectType.RmlDocument)
        {
            RmlElementNativePointer = rmlElementPointer;
        }
        
        public RmlElement(ICore core, IntPtr rmlElementPointer, BaseObjectType baseObjectType) : base(core, GetBaseObjectPointer(core, rmlElementPointer), baseObjectType)
        {
            RmlElementNativePointer = rmlElementPointer;
        }

        public float AbsoluteLeft
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetAbsoluteLeft(RmlElementNativePointer);
                }
            }
        }

        public float AbsoluteTop
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetAbsoluteTop(RmlElementNativePointer);
                }
            }
        }
        
        public Vector2 AbsoluteOffset
        {
            get
            {
                unsafe
                {
                    var vector = Vector2.Zero;
                    Core.Library.Client.RmlElement_GetAbsoluteOffset(RmlElementNativePointer, &vector);
                    return vector;
                }
            }
        }
        
        public float Baseline
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetBaseline(RmlElementNativePointer);
                }
            }
        }
        
        public float ChildCount
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetChildCount(RmlElementNativePointer);
                }
            }
        }

        public IRmlElement[] ChildNodes
        {
            get
            {
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    uint size = 0;
                    Core.Library.Client.RmlElement_GetChildNodes(RmlElementNativePointer, &ptr, &size);
                    var data = new IntPtr[size];
                    Marshal.Copy(ptr, data, 0, (int) size);
                    var arr = data.Select(e => Core.RmlElementPool.GetOrCreate(Core, e)).ToArray();
                    Core.Library.Client.FreeRmlElementArray(ptr);
                    return arr;
                }
            }
        }
        
        public float ClientTop
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetClientTop(RmlElementNativePointer);
                }
            }
        }
        
        public float ClientLeft
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetClientLeft(RmlElementNativePointer);
                }
            }
        }
        
        public float ClientWidth
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetClientWidth(RmlElementNativePointer);
                }
            }
        }
        
        public float ClientHeight
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetClientHeight(RmlElementNativePointer);
                }
            }
        }
        
        public Vector2 ContainingBlockSize
        {
            get
            {
                unsafe
                {
                    var vector = Vector2.Zero;
                    Core.Library.Client.RmlElement_GetContainingBlock(RmlElementNativePointer, &vector);
                    return vector;
                }
            }
        }
        
        public IRmlElement FirstChild
        {
            get
            {
                unsafe
                {
                    var ptr = Core.Library.Client.RmlElement_GetFirstChild(RmlElementNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    return Core.RmlElementPool.GetOrCreate(Core, ptr);
                }
            }
        }
        
        public IRmlElement FocusedElement
        {
            get
            {
                unsafe
                {
                    var ptr = Core.Library.Client.RmlElement_GetFocusedElement(RmlElementNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    return Core.RmlElementPool.GetOrCreate(Core, ptr);
                }
            }
        }
        
        public bool HasChildren
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_HasChildren(RmlElementNativePointer) == 1;
                }
            }
        }
        
        public string Id
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Client.RmlElement_GetId(RmlElementNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    var strPtr = MemoryUtils.StringToHGlobalUtf8(value);
                    Core.Library.Client.RmlElement_SetId(RmlElementNativePointer, strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }
        
        public string InnerRml
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Client.RmlElement_GetInnerRml(RmlElementNativePointer, &size), size);
                }
            }
            set
            {
                unsafe
                {
                    var strPtr = MemoryUtils.StringToHGlobalUtf8(value);
                    Core.Library.Client.RmlElement_SetInnerRml(RmlElementNativePointer, strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        public bool IsOwned
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_IsOwned(RmlElementNativePointer) == 1;
                }
            }
        }
        
        public bool IsVisible
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_IsVisible(RmlElementNativePointer) == 1;
                }
            }
        }
        
        public IRmlElement LastChild
        {
            get
            {
                unsafe
                {
                    var ptr = Core.Library.Client.RmlElement_GetLastChild(RmlElementNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    return Core.RmlElementPool.GetOrCreate(Core, ptr);
                }
            }
        }
        
        public IRmlElement NextSibling
        {
            get
            {
                unsafe
                {
                    var ptr = Core.Library.Client.RmlElement_GetNextSibling(RmlElementNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    return Core.RmlElementPool.GetOrCreate(Core, ptr);
                }
            }
        }
        
        public IRmlElement PreviousSibling
        {
            get
            {
                unsafe
                {
                    var ptr = Core.Library.Client.RmlElement_GetPreviousSibling(RmlElementNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    return Core.RmlElementPool.GetOrCreate(Core, ptr);
                }
            }
        }
        
        public float OffsetTop
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetOffsetTop(RmlElementNativePointer);
                }
            }
        }
        
        public float OffsetLeft
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetOffsetLeft(RmlElementNativePointer);
                }
            }
        }
        
        public float OffsetWidth
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetOffsetWidth(RmlElementNativePointer);
                }
            }
        }
        
        public float OffsetHeight
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetOffsetHeight(RmlElementNativePointer);
                }
            }
        }

        public IRmlDocument OwnerDocument
        {
            get
            {
                unsafe
                {
                    return Core.RmlDocumentPool.GetOrCreate(Core, Core.Library.Client.RmlElement_GetOwnerDocument(RmlElementNativePointer));
                }
            }
        }
        
        public IRmlElement Parent 
        {
            get
            {
                unsafe
                {
                    var ptr = Core.Library.Client.RmlElement_GetParent(RmlElementNativePointer);
                    if (ptr == IntPtr.Zero) return null;
                    return Core.RmlElementPool.GetOrCreate(Core, ptr);
                }
            }
        }
        
        public float ScrollHeight
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetScrollHeight(RmlElementNativePointer);
                }
            }
        }
        
        public float ScrollWidth
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetScrollWidth(RmlElementNativePointer);
                }
            }
        }
        
        public float ScrollTop
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetScrollTop(RmlElementNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Core.Library.Client.RmlElement_SetScrollTop(RmlElementNativePointer, value);
                }
            }
        }

        public float ScrollLeft
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetScrollLeft(RmlElementNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    Core.Library.Client.RmlElement_SetScrollLeft(RmlElementNativePointer, value);
                }
            }
        }
        
        public string TagName
        {
            get
            {
                unsafe
                {
                    var size = 0;
                    return Core.PtrToStringUtf8AndFree(Core.Library.Client.RmlElement_GetTagName(RmlElementNativePointer, &size), size);
                }
            }
        }
        
        public float ZIndex
        {
            get
            {
                unsafe
                {
                    return Core.Library.Client.RmlElement_GetZIndex(RmlElementNativePointer);
                }
            }
        }

        public void AddClass(string name)
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(name);
                Core.Library.Client.RmlElement_AddClass(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }
        
        public void AddPseudoClass(string name)
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(name);
                Core.Library.Client.RmlElement_AddPseudoClass(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }
        
        public void AppendChild(IRmlElement element)
        {
            unsafe
            {
                Core.Library.Client.RmlElement_AppendChild(RmlElementNativePointer, element.RmlElementNativePointer);
            }
        }

        public void Blur()
        {
            unsafe
            {
                Core.Library.Client.RmlElement_Blur(RmlElementNativePointer);
            }
        }

        public void Click()
        {
            unsafe
            {
                Core.Library.Client.RmlElement_Click(RmlElementNativePointer);
            }
        }
        
        public IRmlElement GetClosest(string selector) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(selector);
                var result = Core.Library.Client.RmlElement_GetClosest(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                if (result == IntPtr.Zero) return null;
                return Core.RmlElementPool.GetOrCreate(Core, result);
            }
        }
        
        public void Focus()
        {
            unsafe
            {
                Core.Library.Client.RmlElement_Focus(RmlElementNativePointer);
            }
        }
        
        public string GetAttribute(string name) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(name);
                var size = 0;
                var result = Core.Library.Client.RmlElement_GetAttribute(RmlElementNativePointer, strPtr, &size);
                Marshal.FreeHGlobal(strPtr);
                return Core.PtrToStringUtf8AndFree(result, size);
            }
        }

        public Dictionary<string, string> GetAttributes()
        {
            unsafe
            {
                uint size = 0;
                var keysPtr = IntPtr.Zero;
                var valuesPtr = IntPtr.Zero;
                Core.Library.Client.RmlElement_GetAttributes(RmlElementNativePointer, &keysPtr, &valuesPtr, &size);
                var keys = Core.MarshalStringArrayPtrAndFree(keysPtr, size);
                var values = Core.MarshalStringArrayPtrAndFree(valuesPtr, size);
                return keys
                    .Select((e, i) => new KeyValuePair<string, string>(e, values[i]))
                    .ToDictionary(e => e.Key, e => e.Value);
            }
        }

        public string[] GetClassList()
        {
            unsafe
            {
                uint size = 0;
                var ptr = IntPtr.Zero;
                Core.Library.Client.RmlElement_GetClassList(RmlElementNativePointer, &ptr, &size);
                return Core.MarshalStringArrayPtrAndFree(ptr, size);
            }
        }
        
        public IRmlElement GetElementById(string id) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(id);
                var result = Core.Library.Client.RmlElement_GetElementById(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                if (result == IntPtr.Zero) return null;
                return Core.RmlElementPool.GetOrCreate(Core, result);
            }
        }

        public IRmlElement[] GetElementsByClassName(string className)
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(className);
                uint size = 0;
                var ptr = IntPtr.Zero;
                Core.Library.Client.RmlElement_GetElementsByClassName(RmlElementNativePointer, strPtr, &ptr, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => Core.RmlElementPool.GetOrCreate(Core, e)).ToArray();
                Marshal.FreeHGlobal(strPtr);
                Core.Library.Client.FreeRmlElementArray(ptr);
                return arr;
            }
        }

        public IRmlElement[] GetElementsByTagName(string tagName)
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(tagName);
                uint size = 0;
                var ptr = IntPtr.Zero;
                Core.Library.Client.RmlElement_GetElementsByTagName(RmlElementNativePointer, strPtr, &ptr, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => Core.RmlElementPool.GetOrCreate(Core, e)).ToArray();
                Marshal.FreeHGlobal(strPtr);
                Core.Library.Client.FreeRmlElementArray(ptr);
                return arr;
            }
        }
        
        public string GetLocalProperty(string key) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var size = 0;
                var result = Core.Library.Client.RmlElement_GetLocalProperty(RmlElementNativePointer, strPtr, &size);
                Marshal.FreeHGlobal(strPtr);
                return Core.PtrToStringUtf8AndFree(result, size);
            }
        }
        
        public string GetProperty(string key) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var size = 0;
                var result = Core.Library.Client.RmlElement_GetProperty(RmlElementNativePointer, strPtr, &size);
                Marshal.FreeHGlobal(strPtr);
                return Core.PtrToStringUtf8AndFree(result, size);
            }
        }
        
        public float GetPropertyAbsoluteValue(string key) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Client.RmlElement_GetPropertyAbsoluteValue(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result;
            }
        }
        
        public string[] GetPseudoClassList()
        {
            unsafe
            {
                uint size = 0;
                var ptr = IntPtr.Zero;
                Core.Library.Client.RmlElement_GetPseudoClassList(RmlElementNativePointer, &ptr, &size);
                return Core.MarshalStringArrayPtrAndFree(ptr, size);
            }
        }

        public bool HasAttribute(string attribute)
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(attribute);
                var result = Core.Library.Client.RmlElement_HasAttribute(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public bool HasClass(string className)
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(className);
                var result = Core.Library.Client.RmlElement_HasClass(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public bool HasLocalProperty(string key) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Client.RmlElement_HasLocalProperty(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public bool HasProperty(string key) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Client.RmlElement_HasProperty(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public bool HasPseudoClass(string className)
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(className);
                var result = Core.Library.Client.RmlElement_HasPseudoClass(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public void InsertBefore(IRmlElement child, IRmlElement adjacent) 
        {
            unsafe
            {
                Core.Library.Client.RmlElement_InsertBefore(RmlElementNativePointer, child.RmlElementNativePointer, adjacent.RmlElementNativePointer);
            }
        }

        public bool IsPointWithinElement(Vector2 point)
        {
            unsafe
            {
                var result = Core.Library.Client.RmlElement_IsPointWithinElement(RmlElementNativePointer, point);
                return result == 1;
            }
        }
        
        public IRmlElement QuerySelector(string selector) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(selector);
                var result = Core.Library.Client.RmlElement_QuerySelector(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                if (result == IntPtr.Zero) return null;
                return Core.RmlElementPool.GetOrCreate(Core, result);
            }
        }
        
        public IRmlElement[] QuerySelectorAll(string selector) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(selector);
                uint size = 0;
                var ptr = IntPtr.Zero;
                Core.Library.Client.RmlElement_QuerySelectorAll(RmlElementNativePointer, strPtr, &ptr, &size);
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => Core.RmlElementPool.GetOrCreate(Core, e)).ToArray();
                Core.Library.Client.FreeRmlElementArray(ptr);
                return arr;
            }
        }
        
        public bool RemoveAttribute(string attribute) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(attribute);
                var result = Core.Library.Client.RmlElement_RemoveAttribute(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public void RemoveChild(IRmlElement child) 
        {
            unsafe
            {
                Core.Library.Client.RmlElement_RemoveChild(RmlElementNativePointer, child.RmlElementNativePointer);
            }
        }
        
        public bool RemoveClass(string className) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(className);
                var result = Core.Library.Client.RmlElement_RemoveClass(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public bool RemoveProperty(string key) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Client.RmlElement_RemoveProperty(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public bool RemovePseudoClass(string className) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(className);
                var result = Core.Library.Client.RmlElement_RemovePseudoClass(RmlElementNativePointer, strPtr);
                Marshal.FreeHGlobal(strPtr);
                return result == 1;
            }
        }
        
        public void ReplaceChild(IRmlElement newChild, IRmlElement oldChild) 
        {
            unsafe
            {
                Core.Library.Client.RmlElement_ReplaceChild(RmlElementNativePointer, newChild.RmlElementNativePointer, oldChild.RmlElementNativePointer);
            }
        }
        
        public void ScrollIntoView(bool alignWithTop = true) 
        {
            unsafe
            {
                Core.Library.Client.RmlElement_ScrollIntoView(RmlElementNativePointer, (byte) (alignWithTop ? 1 : 0));
            }
        }
        
        public void SetAttribute(string attribute, string value) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(attribute);
                var strPtr2 = MemoryUtils.StringToHGlobalUtf8(value);
                Core.Library.Client.RmlElement_SetAttribute(RmlElementNativePointer, strPtr, strPtr2);
                Marshal.FreeHGlobal(strPtr);
                Marshal.FreeHGlobal(strPtr2);
            }
        }
        
        public void SetOffset(IRmlElement element, Vector2 offset, bool isFixed = false) 
        {
            unsafe
            {
                Core.Library.Client.RmlElement_SetOffset(RmlElementNativePointer, element.RmlElementNativePointer, offset, (byte) (isFixed ? 1 : 0));
            }
        }
        
        public void SetProperty(string key, string value) 
        {
            unsafe
            {
                var strPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var strPtr2 = MemoryUtils.StringToHGlobalUtf8(value);
                Core.Library.Client.RmlElement_SetProperty(RmlElementNativePointer, strPtr, strPtr2);
                Marshal.FreeHGlobal(strPtr);
                Marshal.FreeHGlobal(strPtr2);
            }
        }
    }
}