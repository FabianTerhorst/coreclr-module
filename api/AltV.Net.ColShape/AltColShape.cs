using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape
{
    public static class AltColShape
    {
        internal static ColShapeModule Module;

        public static Action<IWorldObject, IColShape> OnEntityEnterColShape
        {
            set => Module.OnEntityEnterColShape += value;
        }

        public static Action<IWorldObject, IColShape> OnEntityExitColShape
        {
            set => Module.OnEntityExitColShape += value;
        }

        public static void Init(ColShapeModule module)
        {
            Module = module;
        }

        public static void Create(ulong id, int dimension, Position position, uint radius)
        {
            Add(new ColShape(id, dimension, position, radius));
        }

        public static void Add(IColShape colShape)
        {
            Module.Add(colShape);
        }
    }
}