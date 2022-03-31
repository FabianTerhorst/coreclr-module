using System.Collections.Specialized;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.CApi;
using AltV.Net.Client.Elements;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Client.Elements.Pools;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
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

        public IBaseEntityPool BaseEntityPool { get; }
        public override IBaseBaseObjectPool BaseBaseObjectPool { get; }

        public override INativeResource Resource { get; }
        public ILogger Logger { get; }

        public List<SafeTimer> RunningTimers { get; } = new();

        public Core(
            ILibrary library,
            IntPtr nativePointer,
            IntPtr resourcePointer,
            IPlayerPool playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<IWebView> webViewPool,
            IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool,
            INativeResourcePool nativeResourcePool,
            ILogger logger
        ) : base(nativePointer, library)
        {
            Library = library;
            NativePointer = nativePointer;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            BlipPool = blipPool;
            WebViewPool = webViewPool;
            Logger = logger;
            BaseBaseObjectPool = baseBaseObjectPool;
            BaseEntityPool = baseEntityPool;
            nativeResourcePool.GetOrCreate(this, resourcePointer, out var resource);
            Resource = resource;
        }

        #region Log

        public new void LogInfo(string message) => Logger.LogInfo(message);
        public new void LogWarning(string message) => Logger.LogWarning(message);
        public new void LogError(string message) => Logger.LogError(message);
        public new void LogDebug(string message) => Logger.LogDebug(message);

        #endregion

        // public bool GetEntityById(ushort id, [MaybeNullWhen(false)] out IEntity entity)
        // {
        //     unsafe
        //     {
        //         byte type = 0;
        //         entity = default;
        //         if (this.Core.Library.Entity_GetTypeByID(this.Core.NativePointer, id, &type) != 1) return false;
        //         
        //         switch ((BaseObjectType) type)
        //         {
        //             case BaseObjectType.Player:
        //             case BaseObjectType.LocalPlayer:
        //             {
        //                 entity = PlayerPool.Get(id);
        //                 return entity is not null;
        //             }
        //             case BaseObjectType.Vehicle:
        //             {
        //                 entity = VehiclePool.Get(id);
        //                 return entity is not null;
        //             }
        //             // todo
        //             default:
        //                 return false;
        //         }
        //     }
        // }

        public HandlingData? GetHandlingByModelHash(uint modelHash)
        {
            // unsafe
            // {
            //     var pointer = IntPtr.Zero;
            //     var success = Library.Vehicle_Handling_GetByModelHash(NativePointer, modelHash, &pointer);
            //     if (success == 0 || pointer == IntPtr.Zero) return null;
            //     return new HandlingData(this, pointer);
            // }
            return null;
            // todo
        }

        public IBlip CreatePointBlip(Position position)
        {
            unsafe
            {
                var ptr = Library.Client.Core_Client_CreatePointBlip(NativePointer, position);
                if (ptr == IntPtr.Zero) return null;
                return BlipPool.Create(this, ptr);
            }
        }

        public IBlip CreateRadiusBlip(Position position, float radius)
        {
            unsafe
            {
                var ptr = Library.Client.Core_Client_CreateRadiusBlip(NativePointer, position, radius);
                if (ptr == IntPtr.Zero) return null;
                return BlipPool.Create(this, ptr);
            }
        }

        public IBlip CreateAreaBlip(Position position, int width, int height)
        {
            unsafe
            {
                var ptr = Library.Client.Core_Client_CreateAreaBlip(NativePointer, position, width, height);
                if (ptr == IntPtr.Zero) return null;
                return BlipPool.Create(this, ptr);
            }
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
            unsafe
            {
                var ptr = CreateWebViewPtr(url, propHash, targetTexture);
                if (ptr == IntPtr.Zero) return null;
                return WebViewPool.Create(this, ptr);
            }
        }


        public void RemoveBlip(IBlip blip)
        {
            if (blip.Exists)
            {
                unsafe
                {
                    Library.Shared.Core_DestroyBaseObject(NativePointer, blip.BaseObjectNativePointer);
                }
            }
        }
    }
}