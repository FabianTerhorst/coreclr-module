using System;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public class NativeResource : INativeResource
    {
        private readonly ICore core;

        internal readonly IntPtr NativePointer;

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

        private CSharpResourceImpl cSharpResourceImpl;

        public CSharpResourceImpl CSharpResourceImpl
        {
            get
            {
                unsafe
                {
                    return cSharpResourceImpl ??=
                        new CSharpResourceImpl(core, core.Library.Server.Resource_GetCSharpImpl(NativePointer));
                }
            }
        }

        public string Path
        {
            get
            {
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    core.Library.Server.Resource_GetPath(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
        }

        public string Name
        {
            get
            {
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    core.Library.Shared.Resource_GetName(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
        }

        public string Main
        {
            get
            {
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    core.Library.Server.Resource_GetMain(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
                }
            }
        }

        public string Type
        {
            get
            {
                unsafe
                {
                    var ptr = IntPtr.Zero;
                    core.Library.Shared.Resource_GetType(NativePointer, &ptr);
                    return Marshal.PtrToStringUTF8(ptr);
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

        internal NativeResource(ICore core, IntPtr nativePointer)
        {
            this.core = core;
            NativePointer = nativePointer;
        }

        public void SetExport(string key, object value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Alt.Core.CreateMValue(out var mValue, value);
                core.Library.Shared.Resource_SetExport(core.NativePointer, NativePointer, stringPtr, mValue.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
                mValue.Dispose();
            }
        }

        public void SetExport(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                core.Library.Shared.Resource_SetExport(core.NativePointer, NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public object GetExport(string key)
        {
            unsafe
            {
                var ptr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var mValue = new MValueConst(core.Library.Shared.Resource_GetExport(NativePointer, ptr));
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
                var ptr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                mValue = new MValueConst(core.Library.Shared.Resource_GetExport(NativePointer, ptr));
                Marshal.FreeHGlobal(ptr);
                return mValue.type != MValueConst.Type.Nil;
            }
        }

        public void Start()
        {
            unsafe
            {
                core.Library.Server.Resource_Start(NativePointer);
            }
        }

        public void Stop()
        {
            unsafe
            {
                core.Library.Server.Resource_Stop(NativePointer);
            }
        }
    }
}