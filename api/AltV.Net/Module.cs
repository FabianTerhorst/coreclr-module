using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Events;
using AltV.Net.FunctionParser;
using AltV.Net.Native;
using AltV.Net.Shared.Events;
using AltV.Net.Types;

namespace AltV.Net
{
    public class Module : IDisposable
    {
        internal readonly ICore Core;

        private readonly WeakReference<AssemblyLoadContext> assemblyLoadContext;

        internal readonly INativeResource ModuleResource;

        internal readonly IBaseBaseObjectPool BaseBaseObjectPool;

        internal readonly IBaseEntityPool BaseEntityPool;

        internal readonly IEntityPool<IPlayer> PlayerPool;

        internal readonly IEntityPool<IVehicle> VehiclePool;

        internal readonly IBaseObjectPool<IBlip> BlipPool;

        internal readonly IBaseObjectPool<ICheckpoint> CheckpointPool;

        internal readonly IBaseObjectPool<IVoiceChannel> VoiceChannelPool;

        internal readonly IBaseObjectPool<IColShape> ColShapePool;

        internal readonly INativeResourcePool NativeResourcePool;

        internal IEnumerable<Assembly> Assemblies => !assemblyLoadContext.TryGetTarget(out var target)
            ? new List<Assembly>()
            : target.Assemblies;
        
        internal readonly IDictionary<string, Function> functionExports = new Dictionary<string, Function>();

        internal readonly LinkedList<GCHandle> functionExportHandles = new LinkedList<GCHandle>();

        private readonly IDictionary<int, IDictionary<IRefCountable, ulong>> threadRefCount =
            new Dictionary<int, IDictionary<IRefCountable, ulong>>();

        public Module(ICore core, AssemblyLoadContext assemblyLoadContext,
            INativeResource moduleResource, IBaseBaseObjectPool baseBaseObjectPool,
            IBaseEntityPool baseEntityPool, IEntityPool<IPlayer> playerPool,
            IEntityPool<IVehicle> vehiclePool,
            IBaseObjectPool<IBlip> blipPool,
            IBaseObjectPool<ICheckpoint> checkpointPool,
            IBaseObjectPool<IVoiceChannel> voiceChannelPool,
            IBaseObjectPool<IColShape> colShapePool,
            INativeResourcePool nativeResourcePool)
        {
            Alt.Init(this);
            Core = core;
            this.assemblyLoadContext = new WeakReference<AssemblyLoadContext>(assemblyLoadContext);
            ModuleResource = moduleResource;
            BaseBaseObjectPool = baseBaseObjectPool;
            BaseEntityPool = baseEntityPool;
            PlayerPool = playerPool;
            VehiclePool = vehiclePool;
            BlipPool = blipPool;
            CheckpointPool = checkpointPool;
            VoiceChannelPool = voiceChannelPool;
            ColShapePool = colShapePool;
            NativeResourcePool = nativeResourcePool;
        }

        [Conditional("DEBUG")]
        public void CountUpRefForCurrentThread(IRefCountable baseObject)
        {
            if (baseObject == null) return;
            var currThread = Thread.CurrentThread.ManagedThreadId;
            lock (threadRefCount)
            {
                if (!threadRefCount.TryGetValue(currThread, out var baseObjectRefCount))
                {
                    baseObjectRefCount = new Dictionary<IRefCountable, ulong>();
                    threadRefCount[currThread] = baseObjectRefCount;
                }

                if (!baseObjectRefCount.TryGetValue(baseObject, out var count))
                {
                    count = 0;
                }

                baseObjectRefCount[baseObject] = count + 1;
            }
        }

        [Conditional("DEBUG")]
        public void CountDownRefForCurrentThread(IRefCountable baseObject)
        {
            if (baseObject == null) return;
            var currThread = Thread.CurrentThread.ManagedThreadId;
            lock (threadRefCount)
            {
                if (!threadRefCount.TryGetValue(currThread, out var baseObjectRefCount))
                {
                    return;
                }

                if (!baseObjectRefCount.TryGetValue(baseObject, out var count))
                {
                    return;
                }

                if (count == 1)
                {
                    baseObjectRefCount.Remove(baseObject);
                    return;
                }

                baseObjectRefCount[baseObject] = count - 1;
            }
        }

        public bool HasRefForCurrentThread(IRefCountable baseObject)
        {
            var currThread = Thread.CurrentThread.ManagedThreadId;
            lock (threadRefCount)
            {
                if (!threadRefCount.TryGetValue(currThread, out var baseObjectRefCount))
                {
                    return false;
                }

                if (!baseObjectRefCount.TryGetValue(baseObject, out var count))
                {
                    return false;
                }

                return count > 0;
            }
        }

        public Assembly LoadAssemblyFromName(AssemblyName assemblyName)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromAssemblyName(assemblyName);
        }

        public Assembly LoadAssemblyFromStream(Stream stream)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromStream(stream);
        }

        public Assembly LoadAssemblyFromStream(Stream stream, Stream assemblySymbols)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromStream(stream, assemblySymbols);
        }

        public Assembly LoadAssemblyFromPath(string path)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromAssemblyPath(path);
        }

        public Assembly LoadAssemblyFromNativeImagePath(string nativeImagePath, string assemblyPath)
        {
            if (!assemblyLoadContext.TryGetTarget(out var target)) return null;
            return target.LoadFromNativeImagePath(nativeImagePath, assemblyPath);
        }

        public WeakReference<AssemblyLoadContext> GetAssemblyLoadContext()
        {
            return assemblyLoadContext;
        }

        public void OnCreatePlayer(IntPtr playerPointer, ushort playerId)
        {
            PlayerPool.Create(Core, playerPointer, playerId);
        }

        public void OnRemovePlayer(IntPtr playerPointer)
        {
            PlayerPool.Remove(playerPointer);
        }

        public void OnCreateVehicle(IntPtr vehiclePointer, ushort vehicleId)
        {
            VehiclePool.Create(Core, vehiclePointer, vehicleId);
        }

        public void OnCreateVoiceChannel(IntPtr channelPointer)
        {
            VoiceChannelPool.Create(Core, channelPointer);
        }

        public void OnCreateColShape(IntPtr colShapePointer)
        {
            ColShapePool.Create(Core, colShapePointer);
        }

        public void OnRemoveVehicle(IntPtr vehiclePointer)
        {
            VehiclePool.Remove(vehiclePointer);
        }

        public void OnCreateBlip(IntPtr blipPointer)
        {
            BlipPool.Create(Core, blipPointer);
        }

        public void OnRemoveBlip(IntPtr blipPointer)
        {
            BlipPool.Remove(blipPointer);
        }

        public void OnCreateCheckpoint(IntPtr checkpointPointer)
        {
            CheckpointPool.Create(Core, checkpointPointer);
        }

        public void OnRemoveCheckpoint(IntPtr checkpointPointer)
        {
            CheckpointPool.Remove(checkpointPointer);
        }

        public void OnRemoveVoiceChannel(IntPtr channelPointer)
        {
            VoiceChannelPool.Remove(channelPointer);
        }

        public void OnRemoveColShape(IntPtr colShapePointer)
        {
            ColShapePool.Remove(colShapePointer);
        }

        public void OnModulesLoaded(IModule[] modules)
        {
            foreach (var module in modules)
            {
                OnModuleLoaded(module);
            }
        }

        public virtual void OnModuleLoaded(IModule module)
        {
        }

        public void SetExport(string key, Function function)
        {
            unsafe
            {
                if (function == null) return;
                functionExports[key] = function;
                MValueFunctionCallback callDelegate = function.Call;
                functionExportHandles.AddFirst(GCHandle.Alloc(callDelegate));
                Core.CreateMValueFunction(out var mValue,
                    Core.Library.Shared.Invoker_Create(ModuleResource.ResourceImplPtr, callDelegate));
                ModuleResource.SetExport(key, in mValue);
                mValue.Dispose();
            }
        }

        public void Dispose()
        {
            functionExports.Clear();
            foreach (var handle in functionExportHandles)
            {
                handle.Free();
            }

            functionExportHandles.Clear();
            assemblyLoadContext.SetTarget(null);
        }
    }
}