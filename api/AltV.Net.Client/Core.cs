using System.Collections.Specialized;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Native;
using AltV.Net.Shared;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Client
{
    public partial class Core : SharedCore, ICore
    {
        public ILibrary Library { get; }
        public IntPtr NativePointer { get; }
        

        public override IPlayerPool PlayerPool { get; }
        public override IEntityPool<IVehicle> VehiclePool { get; }
        public IBaseObjectPool<IBlip> BlipPool { get; }
        public IBaseObjectPool<IWebView> WebViewPool { get; }
        public IBaseObjectPool<IRmlDocument> RmlDocumentPool { get; }
        public IBaseObjectPool<IRmlElement> RmlElementPool { get; }

        public IBaseEntityPool BaseEntityPool { get; }
        public override IBaseBaseObjectPool BaseBaseObjectPool { get; }

        public override INativeResource Resource { get; }
        public ILogger Logger { get; }
        public INatives Natives { get; }
        
        public LocalStorage LocalStorage { get; }
        public Voice Voice { get; }

        public List<SafeTimer> RunningTimers { get; } = new();

        public Core(
            ILibrary library,
            IntPtr nativePointer,
            IntPtr resourcePointer,
            IPlayerPool playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<IWebView> webViewPool,
            IBaseObjectPool<IRmlDocument> rmlDocumentPool,
            IBaseObjectPool<IRmlElement> rmlElementPool,
            IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            INativeResourcePool nativeResourcePool,
            ILogger logger,
            INatives natives
        ) : base(nativePointer, library)
        {
            Library = library;
            NativePointer = nativePointer;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            BlipPool = blipPool;
            WebViewPool = webViewPool;
            RmlDocumentPool = rmlDocumentPool;
            RmlElementPool = rmlElementPool;
            Logger = logger;
            BaseBaseObjectPool = baseBaseObjectPool;
            BaseEntityPool = baseEntityPool;
            nativeResourcePool.GetOrCreate(this, resourcePointer, out var resource);
            Resource = resource;
            LocalStorage = new LocalStorage(this, GetLocalStoragePtr());
            Voice = new Voice(this);
            Natives = natives;
        }

        #region Log

        private IntPtr GetLocalStoragePtr()
        {
            unsafe
            {
                return this.Library.Client.Resource_GetLocalStorage(this.Resource.NativePointer);
            }
        }

        public new void LogInfo(string message) => Logger.LogInfo(message);
        public new void LogWarning(string message) => Logger.LogWarning(message);
        public new void LogError(string message) => Logger.LogError(message);
        public new void LogDebug(string message) => Logger.LogDebug(message);

        #endregion
        
        public new IEntity GetEntityById(ushort id)
        {
            return (IEntity) base.GetEntityById(id);
        }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                var success = Library.Client.Vehicle_Handling_GetByModelHash(NativePointer, modelHash, &pointer);
                if (success == 0 || pointer == IntPtr.Zero) return null;
                return new HandlingData(this, pointer);
            }
        }

        public DiscordUser? GetDiscordUser()
        {
            unsafe
            {
                var ptr = Library.Client.Core_GetDiscordUser(NativePointer);
                var structure = Marshal.PtrToStructure<DiscordUser>(ptr);
                Library.Client.Core_DeallocDiscordUser(ptr);
                return structure;
            }
        }

        #region Create
        public IntPtr CreatePointBlipPtr(Position position)
        {
            unsafe
            {
                return Library.Client.Core_Client_CreatePointBlip(NativePointer, position);
            }
        }

        public IBlip CreatePointBlip(Position position)
        {
            var ptr = CreatePointBlipPtr(position);
            if (ptr == IntPtr.Zero) return null;
            return BlipPool.Create(this, ptr);
        }

        public IntPtr CreateRadiusBlipPtr(Position position, float radius)
        {
            unsafe
            {
                return Library.Client.Core_Client_CreateRadiusBlip(NativePointer, position, radius);
            }
        }

        public IBlip CreateRadiusBlip(Position position, float radius)
        {
            var ptr = CreateRadiusBlipPtr(position, radius);
            if (ptr == IntPtr.Zero) return null;
            return BlipPool.Create(this, ptr);
        }

        public IntPtr CreateAreaBlipPtr(Position position, int width, int height)
        {
            unsafe
            {
                return Library.Client.Core_Client_CreateAreaBlip(NativePointer, position, width, height);
            }
        }

        public IBlip CreateAreaBlip(Position position, int width, int height)
        {
            var ptr = CreateAreaBlipPtr(position, width, height);
            if (ptr == IntPtr.Zero) return null;
            return BlipPool.Create(this, ptr);
        }

        public IntPtr CreateWebViewPtr(string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null)
        {
            pos ??= Vector2.Zero;
            size ??= Vector2.Zero;

            unsafe
            {
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateWebView(NativePointer, Resource.NativePointer, urlPtr, pos.Value, size.Value, (byte) (isOverlay ? 1 : 0));
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }   
        }

        public IWebView CreateWebView(string url, bool isOverlay = false, Vector2? pos = null, Vector2? size = null)
        {
            var ptr = CreateWebViewPtr(url, isOverlay, pos, size);
            if (ptr == IntPtr.Zero) return null;
            return WebViewPool.Create(this, ptr);
        }

        public IntPtr CreateWebViewPtr(string url, uint propHash, string targetTexture)
        {
            unsafe
            {
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var targetTexturePtr = MemoryUtils.StringToHGlobalUtf8(targetTexture);
                var ptr = Library.Client.Core_CreateWebView3D(NativePointer, Resource.NativePointer, urlPtr, propHash, targetTexturePtr);
                Marshal.FreeHGlobal(urlPtr);
                Marshal.FreeHGlobal(targetTexturePtr);
                return ptr;
            }
        }

        public IWebView CreateWebView(string url, uint propHash, string targetTexture)
        {
            var ptr = CreateWebViewPtr(url, propHash, targetTexture);
            if (ptr == IntPtr.Zero) return null;
            return WebViewPool.Create(this, ptr);
        }
        
        public IntPtr CreateRmlDocumentPtr(string url)
        {
            unsafe
            {
                var urlPtr = MemoryUtils.StringToHGlobalUtf8(url);
                var ptr = Library.Client.Core_CreateRmlDocument(NativePointer, Resource.NativePointer, urlPtr);
                Marshal.FreeHGlobal(urlPtr);
                return ptr;
            }
        }
        
        public IRmlDocument CreateRmlDocument(string url)
        {
            var ptr = CreateRmlDocumentPtr(url);
            if (ptr == IntPtr.Zero) return null;
            return RmlDocumentPool.Create(this, ptr);
        }
        #endregion
        
        public void ShowCursor(bool state)
        {
            unsafe
            {
                Library.Client.Core_ShowCursor(NativePointer, Resource.NativePointer, state);
            }
        }

        #region TriggerServerEvent
        public void TriggerServerEvent(string eventName, MValueConst[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, MValueConst[] args)
        {
            var size = args.Length;
            var mValuePointers = new IntPtr[size];
            for (var i = 0; i < size; i++)
            {
                mValuePointers[i] = args[i].nativePointer;
            }

            TriggerServerEvent(eventNamePtr, mValuePointers);
        }

        public void TriggerServerEvent(string eventName, IntPtr[] args)
        {
            var eventNamePtr = AltNative.StringUtils.StringToHGlobalUtf8(eventName);
            TriggerServerEvent(eventNamePtr, args);
            Marshal.FreeHGlobal(eventNamePtr);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void TriggerServerEvent(IntPtr eventNamePtr, IntPtr[] args)
        {
            unsafe
            {
                Library.Client.Core_TriggerServerEvent(NativePointer, eventNamePtr, args, args.Length);
            }
        }

        public void TriggerServerEvent(IntPtr eventNamePtr, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEvent(eventNamePtr, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }

        public void TriggerServerEvent(string eventName, params object[] args)
        {
            if (args == null) throw new ArgumentException("Arguments array should not be null.");
            var size = args.Length;
            var mValues = new MValueConst[size];
            CreateMValues(mValues, args);
            TriggerServerEvent(eventName, mValues);
            for (var i = 0; i < size; i++)
            {
                mValues[i].Dispose();
            }
        }
        #endregion
        
        public Vector2 WorldToScreen(Vector3 position)
        {
            unsafe
            {
                var result = Vector2.Zero;
                Library.Client.Core_WorldToScreen(NativePointer, position, &result);
                return result;
            }
        }
        
        public void LoadRmlFont(string path, string name, bool italic = false, bool bold = false)
        {
            unsafe
            {
                var pathPtr = MemoryUtils.StringToHGlobalUtf8(path);
                var namePtr = MemoryUtils.StringToHGlobalUtf8(name);
                Library.Client.Core_LoadRmlFont(NativePointer, Resource.NativePointer, pathPtr, namePtr, (byte) (italic ? 1 : 0), (byte) (bold ? 1 : 0));
                Marshal.FreeHGlobal(pathPtr);
                Marshal.FreeHGlobal(namePtr);
            }
        }
        
        public string[] MarshalStringArrayPtrAndFree(IntPtr ptr, uint size)
        {
            unsafe
            {
                var data = new IntPtr[size];
                Marshal.Copy(ptr, data, 0, (int) size);
                var arr = data.Select(e => Marshal.PtrToStringUTF8(e)).ToArray();
                this.Library.Shared.FreeStringArray(ptr, size);
                return arr;
            }
        }
    }
}