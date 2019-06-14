using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape
{
    public struct ColShape
    {
        public ulong Id;

        public Position Position;

        public uint Radius;

        public HashSet<IWorldObject> WorldObjects;
    }
}