using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AltV.Net.VehicleData
{
    public class VehicleData
    {
        public class VehicleModel
        {
        }

        public readonly struct ModKit
        {
            public readonly uint Id;
            public readonly string Name;
            public readonly Dictionary<byte, byte[]> Mods;

            public ModKit(uint id, string name, Dictionary<byte, byte[]> mods)
            {
                Id = id;
                Name = name;
                Mods = mods;
            }
        }

        public List<ModKit> Parse(string fileName)
        {
            var modKits = new List<ModKit>();
            using var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
            var version = reader.ReadUInt16();
            var stream = reader.BaseStream;
            while (stream.Position < stream.Length)
            {
                var modKitId = reader.ReadUInt16();
                var nameLen = reader.ReadUInt16();
                var name = Encoding.UTF8.GetString(reader.ReadBytes(nameLen));
                var modsCount = reader.ReadByte();
                var mods = new Dictionary<byte, byte[]>();
                for (var i = 0; i < modsCount; i++)
                {
                    var category = reader.ReadByte();
                    var count = reader.ReadByte();
                    var components = new byte[count];
                    for (var j = 0; j < count; j++)
                    {
                        components[i] = reader.ReadByte();
                    }

                    mods[category] = components;
                }
                var modKit = new ModKit(modKitId, name, mods);
                modKits.Add(modKit);
            }

            return modKits;
        }
    }
}