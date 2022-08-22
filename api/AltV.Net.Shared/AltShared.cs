using System.IO.Compression;
using System.Numerics;
using System.Runtime.CompilerServices;
using AltV.Net.Elements.Args;
using AltV.Net.Shared.Serialization.Providers;

[assembly: InternalsVisibleTo("AltV.Net")]
[assembly: InternalsVisibleTo("AltV.Net.Mock")]
[assembly: InternalsVisibleTo("AltV.Net.Async")]
[assembly: InternalsVisibleTo("AltV.Net.Client")]

namespace AltV.Net.Shared
{
    public static class AltShared
    {
        public static ISharedCore Core { get; set; }
        public static uint Hash(string key) => Core.Hash(key);
        public static void EmitLocal(string eventName, params object[] args) => Core.TriggerLocalEvent(eventName, args);
        
        public static MValueConst SerializeMValue<T>(T value)
        {
            return Core.SerializerRegistry.GetSerializer<T>().Serialize(value);
        }
    
        public static T DeserializeMValue<T>(MValueConst mvalue)
        {
            return Core.SerializerRegistry.GetSerializer<T>().Deserialize(mvalue);
        }

        public static void Test()
        {
            Core.SerializerRegistry.RegisterSerializationProvider(new PrimitivesSerializationProvider());
            Core.SerializerRegistry.RegisterSerializationProvider(new CollectionsSerializationProvider());
            var mvalue = SerializeMValue(new Dictionary<string, int>()
            {
                ["x"] = 0,
                ["y"] = 1,
                ["z"] = 2
            });
            var value = DeserializeMValue<Vector3>(mvalue);
            Console.WriteLine(value);
        }
    }
}