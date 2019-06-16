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

        /// <summary>
        /// Init col shape module, areaSize = 1 requires
        /// areaSize of 1 requires 10gb ram
        /// areaSize of 10 requires 100mb ram
        /// areaSize of 100 requires 1mb ram
        /// </summary>
        /// <param name="areaSize">Larger area size => more ram, less cpu usage</param>
        public static void Init(int areaSize = 100)
        {
            Init(new ColShapeModule(areaSize));
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