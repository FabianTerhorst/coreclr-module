using System.Runtime.InteropServices;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client.Elements.Data
{
    public class LocalStorage
    {
        private readonly ICore core;
        private readonly IntPtr nativePointer;

        internal LocalStorage(ICore core, IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
            this.core = core;
        }

        public void Get(string key, out MValueConst value)
        {
            unsafe
            {
                if (string.IsNullOrEmpty(key))
                {
                    value = MValueConst.Nil;
                    return;
                }
                
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(core, core.Library.Client.LocalStorage_GetKey(nativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void Set(string key, in MValueConst value)
        {
            unsafe
            {
                if (string.IsNullOrEmpty(key))
                {
                    return;
                }

                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                core.Library.Client.LocalStorage_SetKey(nativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void Delete(string key)
        {
            unsafe
            {
                if (string.IsNullOrEmpty(key))
                {
                    return;
                }
                
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                core.Library.Client.LocalStorage_DeleteKey(nativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void Set(string key, object value)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            core.CreateMValue(out var mValue, value);
            Set(key, in mValue);
            mValue.Dispose();
        }

        public bool Get(string key, out int result)
        {
            Get(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Int)
                {
                    result = default;
                    return false;
                }

                result = (int) mValue.GetInt();
            }

            return true;
        }

        public bool Get(string key, out uint result)
        {
            Get(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Uint)
                {
                    result = default;
                    return false;
                }

                result = (uint) mValue.GetUint();
            }

            return true;
        }

        public bool Get(string key, out float result)
        {
            Get(key, out MValueConst mValue);
            using (mValue)
            {
                if (mValue.type != MValueConst.Type.Double)
                {
                    result = default;
                    return false;
                }

                result = (float) mValue.GetDouble();
            }

            return true;
        }

        public void Save()
        {
            unsafe
            {
                core.Library.Client.LocalStorage_Save(nativePointer);
            }
        }

        public void Clear()
        {
            unsafe
            {
                core.Library.Client.LocalStorage_Clear(nativePointer);
            }
        }

        public bool Get<T>(string key, out T result)
        {
            Get(key, out MValueConst mValue);
            using (mValue)
            {
                if (!(mValue.ToObject() is T cast))
                {
                    result = default;
                    return false;
                }

                result = cast;
            }

            return true;
        }

    }
}