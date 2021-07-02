using System;
using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Native;

namespace AltV.Net
{
    public class NativeResource : INativeResource
    {
        private readonly ILibrary library;
        
        private readonly IntPtr corePointer;
        
        internal readonly IntPtr NativePointer;

        public IntPtr ResourceImplPtr
        {
            get
            {
                unsafe
                {
                    return library.Resource_GetImpl(NativePointer);
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
                        new CSharpResourceImpl(library, library.Resource_GetCSharpImpl(NativePointer));
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
                    library.Resource_GetPath(NativePointer, &ptr);
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
                    library.Resource_GetName(NativePointer, &ptr);
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
                    library.Resource_GetMain(NativePointer, &ptr);
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
                    library.Resource_GetType(NativePointer, &ptr);
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
                    return library.Resource_IsStarted(NativePointer);
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
                    var size = library.Resource_GetDependenciesSize(NativePointer);
                    var pointers = new IntPtr[size];
                    library.Resource_GetDependencies(NativePointer, pointers, size);
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
                    var size = library.Resource_GetDependantsSize(NativePointer);
                    var pointers = new IntPtr[size];
                    library.Resource_GetDependants(NativePointer, pointers, size);
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

        internal NativeResource(ILibrary library, IntPtr corePointer, IntPtr nativePointer)
        {
            this.library = library;
            this.corePointer = corePointer;
            NativePointer = nativePointer;
        }

        public void SetExport(string key, object value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                Alt.Server.CreateMValue(out var mValue, value);
                library.Resource_SetExport(corePointer, NativePointer, stringPtr, mValue.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
                mValue.Dispose();
            }
        }

        public void SetExport(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                library.Resource_SetExport(corePointer, NativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public object GetExport(string key)
        {
            unsafe
            {
                var ptr = AltNative.StringUtils.StringToHGlobalUtf8(key);
                var mValue = new MValueConst(library.Resource_GetExport(NativePointer, ptr));
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
                mValue = new MValueConst(library.Resource_GetExport(NativePointer, ptr));
                Marshal.FreeHGlobal(ptr);
                return mValue.type != MValueConst.Type.Nil;
            }
        }

        public void Start()
        {
            unsafe
            {
                library.Resource_Start(NativePointer);
            }
        }

        public void Stop()
        {
            unsafe
            {
                library.Resource_Stop(NativePointer);
            }
        }
    }
}