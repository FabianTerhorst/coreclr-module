using System.Runtime.InteropServices;
using System.Text;
using AltV.Net.CApi;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Shared
{
    public abstract class SharedCore : ISharedCore
    {
        public IntPtr NativePointer { get; }

        public ILibrary Library { get; }

        public SharedCore(IntPtr nativePointer, ILibrary library)
        {         
            NativePointer = nativePointer;
            Library = library;
        }
        
        public abstract IReadOnlyEntityPool<ISharedPlayer> PlayerPool { get; }
        public abstract IReadOnlyEntityPool<ISharedVehicle> VehiclePool { get; }
        public abstract IReadOnlyBaseBaseObjectPool BaseBaseObjectPool { get; }

        private string? version;
        public string Version
        {
            get
            {
                unsafe
                {
                    if (version != null) return version;
                    var size = 0;
                    version = PtrToStringUtf8AndFree(
                        Library.Shared.Core_GetVersion(NativePointer, &size), size);

                    return version;
                }
            }
        }
        
        private string? branch;
        public string Branch
        {
            get
            {
                unsafe
                {
                    if (branch != null) return branch;
                    var size = 0;
                    branch = PtrToStringUtf8AndFree(
                        Library.Shared.Core_GetBranch(NativePointer, &size), size);

                    return branch;
                }
            }
        }
        
        private bool? isDebug;
        public bool IsDebug
        {
            get
            {
                unsafe
                {
                    if (isDebug.HasValue) return isDebug.Value;
                    isDebug = Library.Shared.Core_IsDebug(NativePointer) == 1;
                    return isDebug.Value;
                }
            }
        }

        public uint Hash(string stringToHash)
        {
            if (string.IsNullOrEmpty(stringToHash)) return 0;

            var characters = Encoding.UTF8.GetBytes(stringToHash.ToLower());

            uint hash = 0;

            foreach (var c in characters)
            {
                hash += c;
                hash += hash << 10;
                hash ^= hash >> 6;
            }

            hash += hash << 3;
            hash ^= hash >> 11;
            hash += hash << 15;

            return hash;
        }
        
        public void LogInfo(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Shared.Core_LogInfo(NativePointer, messagePtr);
            }
        }

        public void LogDebug(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Shared.Core_LogDebug(NativePointer, messagePtr);
            }
        }

        public void LogWarning(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Shared.Core_LogWarning(NativePointer, messagePtr);
            }
        }

        public void LogError(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Shared.Core_LogError(NativePointer, messagePtr);
            }
        }

        public void LogColored(IntPtr messagePtr)
        {
            unsafe
            {
                Library.Shared.Core_LogColored(NativePointer, messagePtr);
            }
        }

        public void LogInfo(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                Library.Shared.Core_LogInfo(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogDebug(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                Library.Shared.Core_LogDebug(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogWarning(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                Library.Shared.Core_LogWarning(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogError(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                Library.Shared.Core_LogError(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }

        public void LogColored(string message)
        {
            unsafe
            {
                var messagePtr = MemoryUtils.StringToHGlobalUtf8(message);
                Library.Shared.Core_LogColored(NativePointer, messagePtr);
                Marshal.FreeHGlobal(messagePtr);
            }
        }
        
        public string PtrToStringUtf8AndFree(nint str, int size)
        {
            unsafe
            {
                var stringResult = Marshal.PtrToStringUTF8(str, size);
                Library.Shared.FreeString(str);
                return stringResult;
            }
        }
    }
}