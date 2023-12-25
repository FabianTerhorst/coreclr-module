using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using AltV.Net.Data;
using AltV.Net.Elements.Args;
using AltV.Net.Native;
using AltV.Net.Shared.Utils;

namespace AltV.Net.Elements.Entities
{
    public class Checkpoint : ColShape, ICheckpoint
    {
        public IntPtr CheckpointNativePointer { get; }
        public override IntPtr NativePointer => CheckpointNativePointer;

        private static IntPtr GetColShapePointer(ICore core, IntPtr nativePointer)
        {
            unsafe
            {
                return core.Library.Shared.Checkpoint_GetColShape(nativePointer);
            }
        }

        public static uint GetId(IntPtr pedPointer)
        {
            unsafe
            {
                return Alt.Core.Library.Shared.Checkpoint_GetID(pedPointer);
            }
        }

        public byte CheckpointType
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_GetCheckpointType(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetCheckpointType(CheckpointNativePointer, value);
                }
            }
        }

        public float Height
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_GetHeight(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetHeight(CheckpointNativePointer, value);
                }
            }
        }

        public float Radius
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_GetRadius(CheckpointNativePointer);
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetRadius(CheckpointNativePointer, value);
                }
            }
        }

        public Rgba Color
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var color = Rgba.Zero;
                    Core.Library.Shared.Checkpoint_GetColor(CheckpointNativePointer, &color);
                    return color;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetColor(CheckpointNativePointer, value);
                }
            }
        }

        public Position NextPosition
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    var position = Vector3.Zero;
                    Core.Library.Shared.Checkpoint_GetNextPosition(CheckpointNativePointer, &position);
                    return position;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetNextPosition(CheckpointNativePointer, value);
                }
            }
        }

        public uint StreamingDistance
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_GetStreamingDistance(CheckpointNativePointer);
                }
            }
        }

        public Checkpoint(ICore core, IntPtr nativePointer, uint id) : base(core,
            GetColShapePointer(core, nativePointer), BaseObjectType.Checkpoint, id)
        {
            CheckpointNativePointer = nativePointer;
        }

        public bool Visible
        {
            get
            {
                unsafe
                {
                    CheckIfEntityExists();
                    return Core.Library.Shared.Checkpoint_IsVisible(CheckpointNativePointer) == 1;
                }
            }
            set
            {
                unsafe
                {
                    CheckIfEntityExists();
                    Core.Library.Shared.Checkpoint_SetVisible(CheckpointNativePointer, value ? (byte)1 : (byte)0);
                }
            }
        }

        public void SetStreamSyncedMetaData(Dictionary<string, object> metaData)
        {
            unsafe
            {
                var dataTemp = new Dictionary<IntPtr, MValueConst>();

                var keys = new IntPtr[metaData.Count];
                var values = new IntPtr[metaData.Count];

                for (var i = 0; i < metaData.Count; i++)
                {
                    var stringPtr = MemoryUtils.StringToHGlobalUtf8(metaData.ElementAt(i).Key);
                    Core.CreateMValue(out var mValue, metaData.ElementAt(i).Value);
                    keys[i] = stringPtr;
                    values[i] = mValue.nativePointer;
                    dataTemp.Add(stringPtr, mValue);
                }

                Core.Library.Server.Checkpoint_SetMultipleStreamSyncedMetaData(CheckpointNativePointer, keys, values, (uint)dataTemp.Count);

                foreach (var dataValue in dataTemp)
                {
                    dataValue.Value.Dispose();
                    Marshal.FreeHGlobal(dataValue.Key);
                }
            }
        }

        public void SetStreamSyncedMetaData(string key, in MValueConst value)
        {
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.Checkpoint_SetStreamSyncedMetaData(CheckpointNativePointer, stringPtr, value.nativePointer);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void DeleteStreamSyncedMetaData(string key)
        {
            CheckIfEntityExists();
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                Core.Library.Server.Checkpoint_DeleteStreamSyncedMetaData(CheckpointNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
            }
        }

        public void SetStreamSyncedMetaData(string key, object value)
        {
            CheckIfEntityExists();
            Alt.Core.CreateMValue(out var mValue, value);
            SetStreamSyncedMetaData(key, in mValue);
            mValue.Dispose();
        }

        public bool HasStreamSyncedMetaData(string key)
        {
            unsafe
            {
                CheckIfEntityExists();
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                var result = Core.Library.Server.Checkpoint_HasStreamSyncedMetaData(CheckpointNativePointer, stringPtr);
                Marshal.FreeHGlobal(stringPtr);
                return result == 1;
            }
        }

        public bool GetStreamSyncedMetaData<T>(string key, out T result)
        {
            CheckIfEntityExists();
            GetStreamSyncedMetaData(key, out MValueConst mValue);
            using (mValue)
            {

                try
                {
                    result = (T)Convert.ChangeType(mValue.ToObject(), typeof(T));
                    return true;
                }
                catch
                {
                    result = default;
                    return false;
                }
            }
        }

        public void GetStreamSyncedMetaData(string key, out MValueConst value)
        {
            CheckIfEntityExists();
            unsafe
            {
                var stringPtr = MemoryUtils.StringToHGlobalUtf8(key);
                value = new MValueConst(Core,
                    Core.Library.Server.Checkpoint_GetStreamSyncedMetaData(CheckpointNativePointer, stringPtr));
                Marshal.FreeHGlobal(stringPtr);
            }
        }
    }
}