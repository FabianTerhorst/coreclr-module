using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Args;
using AltV.Net.Shared.Elements.Entities;
using AltV.Net.Types;

namespace AltV.Net.Elements.Args
{
    public interface IMValueConst : IDisposable
    {
        bool GetBool();
        long GetInt();
        ulong GetUint();
        double GetDouble();
        string GetString();
        ISharedBaseObject GetBaseObject();
        IMValueConst[] GetList();
        Dictionary<string, IMValueConst> GetDictionary();
        Position GetVector3();
        Rgba GetRgba();
        byte[] GetByteArray();

        string ToString();
        
        void AddRef();
        void RemoveRef();
        MValueType type { get; }

        MValueConstCached GetCached();

        [Obsolete]
        object ToObject()
        {
            return null!;
        }
    }
}