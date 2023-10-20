using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Elements.Data;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Shared
{
    public abstract class SharedNativeResource : ISharedNativeResource
    {
        protected readonly ISharedCore core;

        public IntPtr NativePointer { get; }

        public abstract ISharedCSharpResourceImpl CSharpResourceImpl { get; }

        public IntPtr ResourceImplPtr
        {
            get
            {
                unsafe
                {
                    return core.Library.Shared.Resource_GetImpl(NativePointer);
                }
            }
        }

        private string? name;
        public string Name
        {
            get
            {
                if (name != null) return name;

                unsafe
                {
                    var size = 0;
                    name = core.PtrToStringUtf8AndFree(core.Library.Shared.Resource_GetName(NativePointer, &size), size);
                    return name;
                }
            }
        }

        private string? type;
        public string Type
        {
            get
            {
                if (type != null) return type;

                unsafe
                {
                    var size = 0;
                    type = core.PtrToStringUtf8AndFree(core.Library.Shared.Resource_GetType(NativePointer, &size), size);
                    return type;
                }
            }
        }

        public bool IsStarted
        {
            get
            {
                unsafe
                {
                    return core.Library.Shared.Resource_IsStarted(NativePointer) == 1;
                }
            }
        }

        private string[] dependencies;

        public string[] Dependencies
        {
            get
            {
                unsafe
                {
                    if (dependencies != null) return dependencies;
                    var size = core.Library.Shared.Resource_GetDependenciesSize(NativePointer);
                    var pointers = new IntPtr[size];
                    core.Library.Shared.Resource_GetDependencies(NativePointer, pointers, size);
                    var strings = new string[size];
                    for (var i = 0; i < size; i++)
                    {
                        strings[i] = Marshal.PtrToStringUTF8(pointers[i]);
                    }
                    dependencies = strings;

                    return strings;
                }
            }
        }

        private string[] dependants;

        public string[] Dependants
        {
            get
            {
                unsafe
                {
                    if (dependants != null) return dependants;
                    var size = core.Library.Shared.Resource_GetDependantsSize(NativePointer);
                    var pointers = new IntPtr[size];
                    core.Library.Shared.Resource_GetDependants(NativePointer, pointers, size);
                    var strings = new string[size];
                    for (var i = 0; i < size; i++)
                    {
                        strings[i] = Marshal.PtrToStringUTF8(pointers[i]);
                    }
                    dependants = strings;
                    return strings;
                }
            }
        }

        internal SharedNativeResource(ISharedCore core, IntPtr nativePointer)
        {
            this.core = core;
            NativePointer = nativePointer;
        }

        public void SetExport(string key, object value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                core.CreateMValue(out var mValue, value);
                core.Library.Shared.Resource_SetExport(core.NativePointer, NativePointer, stringPtr, mValue.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
                mValue.Dispose();
            }
        }

        public void SetExport(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                core.Library.Shared.Resource_SetExport(core.NativePointer, NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public object GetExport(string key)
        {
            unsafe
            {
                var ptr = MemoryUtils.StringToHGlobalUtf8(key);
                var mValue = new MValueConst(core, core.Library.Shared.Resource_GetExport(NativePointer, ptr));
                var obj = mValue.ToObject();
                mValue.Dispose();
                Marshal.FreeHGlobal(ptr);
                return obj;
            }
        }

        public bool GetExport(string key, out MValueConst mValue)
        {
            unsafe
            {
                var ptr = MemoryUtils.StringToHGlobalUtf8(key);
                mValue = new MValueConst(core, core.Library.Shared.Resource_GetExport(NativePointer, ptr));
                Marshal.FreeHGlobal(ptr);
                return mValue.type != MValueConst.Type.Nil;
            }
        }

        public IConfig GetConfig()
        {
            unsafe
            {
                return new Config(core, core.Library.Shared.Resource_GetConfig(NativePointer));
            }
        }
    }
}