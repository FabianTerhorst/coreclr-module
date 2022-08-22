using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Args
{
    public class MValueConstCached : IMValueConst
    {
        public MValueConstCached(object value, MValueType type)
        {
            _value = value;
            this.type = type;
        }
        
        private object _value;
        public MValueType type { get; }
        
        public bool GetBool()
        {
            return (bool) _value;
        }
        
        public long GetInt()
        {
            return (long) _value;
        }
        
        public ulong GetUint()
        {
            return (ulong) _value;
        }
        
        public double GetDouble()
        {
            return (double) _value;
        }
        
        public string GetString()
        {
            return (string) _value;
        }
        
        public IntPtr GetEntityPointer(ref BaseObjectType baseObjectType)
        {
            throw new NotImplementedException();
        }
        
        public ISharedBaseObject GetBaseObject()
        {
            throw new NotImplementedException();
        }
        
        public IMValueConst[] GetList()
        {
            return (IMValueConst[]) _value;
        }
        
        public Dictionary<string, IMValueConst> GetDictionary()
        {
            return (Dictionary<string, IMValueConst>) _value;
        }
        
        public Position GetVector3()
        {
            return (Vector3) _value;
        }
        
        public Rgba GetRgba()
        {
            return (Rgba) _value;
        }
        
        public byte[] GetByteArray()
        {
            return (byte[]) _value;
        }

        public MValueConstCached GetCached()
        {
            return this;
        }

        public void AddRef()
        {
        }
        
        public void RemoveRef()
        {
        }

        public void Dispose()
        {
        }
    }
}