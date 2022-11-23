using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AltV.Net.Host
{
    public interface IConfigNode
    {
        bool GetString(out string value);
        string? GetString();
        bool GetInt(out int value);
        int? GetInt();
        bool GetUInt(out uint value);
        uint? GetUInt();
        bool GetLong(out long value);
        long? GetLong();
        bool GetULong(out ulong value);
        ulong? GetULong();
        bool GetFloat(out float value);
        float? GetFloat();
        bool GetDouble(out double value);
        double? GetDouble();
        bool GetList(out ConfigNode[] value);
        ConfigNode[]? GetList();
        bool GetDict(out Dictionary<string, ConfigNode> value);
        Dictionary<string, ConfigNode>? GetDict();
        public ConfigNode.Type ElementType { get; }

        public ConfigNode Get(string key);
        public ConfigNode Get(int index);
        ConfigNode this[string key] { get; }
        ConfigNode this[int index] { get; }
    }

    public interface IConfig : IConfigNode, IDisposable
    {
    }

    public class ConfigNode : IConfigNode
    {
        public enum Type : byte
        {
            NONE,
            SCALAR,
            LIST,
            DICT,
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct ConfigNodeData
        {
            private readonly byte type;
            public readonly IntPtr strValue;
            public readonly int elements;
            public readonly IntPtr keys;
            public readonly IntPtr values;

            public Type Type => (Type) type;
        }

        private readonly ConfigNodeData data;

        internal ConfigNode(ConfigNodeData data)
        {
            this.data = data;
        }

        public Type ElementType => data.Type;

        public bool GetString(out string value)
        {
            if (data.Type != Type.SCALAR)
            {
                value = null;
                return false;
            }

            value = Marshal.PtrToStringUTF8(data.strValue)!;
            return true;
        }
        public string? GetString() => GetString(out var value) ? value : null;

        public bool GetInt(out int value)
        {
            if (!GetString(out var str))
            {
                value = default;
                return false;
            }

            value = int.Parse(str);
            return true;
        }
        public int? GetInt() => GetInt(out var value) ? value : null;

        public bool GetUInt(out uint value)
        {
            if (!GetString(out var str))
            {
                value = default;
                return false;
            }

            value = uint.Parse(str);
            return true;
        }
        public uint? GetUInt() => GetUInt(out var value) ? value : null;

        public bool GetLong(out long value)
        {
            if (!GetString(out var str))
            {
                value = default;
                return false;
            }

            value = long.Parse(str);
            return true;
        }
        public long? GetLong() => GetLong(out var value) ? value : null;

        public bool GetULong(out ulong value)
        {
            if (!GetString(out var str))
            {
                value = default;
                return false;
            }

            value = ulong.Parse(str);
            return true;
        }
        public ulong? GetULong() => GetULong(out var value) ? value : null;

        public bool GetFloat(out float value)
        {
            if (!GetString(out var str))
            {
                value = default;
                return false;
            }

            value = float.Parse(str);
            return true;
        }
        public float? GetFloat() => GetFloat(out var value) ? value : null;

        public bool GetDouble(out double value)
        {
            if (!GetString(out var str))
            {
                value = default;
                return false;
            }

            value = double.Parse(str);
            return true;
        }
        public double? GetDouble() => GetDouble(out var value) ? value : null;

        public bool GetList(out ConfigNode[] value)
        {
            if (data.Type != Type.LIST)
            {
                value = null;
                return false;
            }

            var valuesPtrs = new IntPtr[data.elements];
            Marshal.Copy(data.values, valuesPtrs, 0, data.elements);
            var values = new ConfigNode[data.elements];
            for (var i = 0; i < data.elements; i++)
            {
                values[i] = new ConfigNode(Marshal.PtrToStructure<ConfigNodeData>(valuesPtrs[i]));
            }

            value = values;
            return true;
        }
        public ConfigNode[]? GetList() => GetList(out var value) ? value : null;

        public bool GetBool(out bool value)
        {
            if (!GetString(out var str) || str is not ("yes" or "true" or "no" or "false"))
            {
                value = default;
                return false;
            }

            value = str == "yes" || str == "true";
            return true;
        }
        public bool? GetBool() => GetBool(out var value) ? value : null;
        
        public bool GetDict(out Dictionary<string, ConfigNode> value)
        {
            if (data.Type != Type.DICT)
            {
                value = null;
                return false;
            }

            var keysPtrs = new IntPtr[data.elements];
            Marshal.Copy(data.keys, keysPtrs, 0, data.elements);

            var valuesPtrs = new IntPtr[data.elements];
            Marshal.Copy(data.values, valuesPtrs, 0, data.elements);

            var pairs = new KeyValuePair<string, ConfigNode>[data.elements];
            for (var i = 0; i < data.elements; i++)
            {
                pairs[i] = new KeyValuePair<string, ConfigNode>(Marshal.PtrToStringUTF8(keysPtrs[i])!, new ConfigNode(Marshal.PtrToStructure<ConfigNodeData>(valuesPtrs[i])));
            }

            value = pairs.ToDictionary(e => e.Key, e => e.Value);
            return true;
        }
        public Dictionary<string, ConfigNode>? GetDict() => GetDict(out var value) ? value : null;

        public ConfigNode Get(int index)
        {
            if (data.Type != Type.LIST || index >= data.elements)
            {
                return new ConfigNode(default);
            }
            
            var valuesPtrs = new IntPtr[data.elements];
            Marshal.Copy(data.values, valuesPtrs, 0, data.elements);
            
            return new ConfigNode( Marshal.PtrToStructure<ConfigNodeData>(valuesPtrs[index]));
        }
        
        public ConfigNode Get(string key)
        {
            if (data.Type != Type.DICT)
            {
                return new ConfigNode(default);
            }
            
            var keysPtrs = new IntPtr[data.elements];
            Marshal.Copy(data.keys, keysPtrs, 0, data.elements);
            
            var foundIndex = -1;
            for (var i = 0; i < data.elements; i++)
            {
                var currentKey = Marshal.PtrToStringUTF8(keysPtrs[i]);
                if (key != currentKey) continue;
                foundIndex = i;
                break;
            }
            
            if (foundIndex == -1) return new ConfigNode(default);

            var valuesPtrs = new IntPtr[data.elements];
            Marshal.Copy(data.values, valuesPtrs, 0, data.elements);
            
            return new ConfigNode(Marshal.PtrToStructure<ConfigNodeData>(valuesPtrs[foundIndex]));
        }

        public ConfigNode this[int index] => Get(index);
        public ConfigNode this[string key] => Get(key);
    }

    public class Config : ConfigNode, IConfig
    {
        private IntPtr pointer;
        
        private unsafe delegate* unmanaged[Cdecl]<nint, void> ConfigDelete;

        public void Dispose()
        {
            unsafe
            {
                if (pointer == IntPtr.Zero) return;
                ConfigDelete(pointer);
            }
        }

        public Config(Dictionary<ulong, IntPtr> funcTable, IntPtr pointer) : base(Marshal.PtrToStructure<ConfigNodeData>(pointer))
        {
            unsafe
            {
                ConfigDelete = (delegate* unmanaged[Cdecl]<nint, void>) funcTable[Host.GetFnvHash("Config_Delete")];
                this.pointer = pointer;
            }
        }
    }
}