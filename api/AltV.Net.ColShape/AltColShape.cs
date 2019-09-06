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

        /// <summary>
        /// Configures the ColShape module
        /// </summary>
        /// <param name="options"></param>
        public static void Configure(Action<ColShapeModuleOptions> options)
        {
            var defaultOptions = new ColShapeModuleOptions();
            options(defaultOptions);
            Init(new ColShapeModule(defaultOptions.AreaSize));
        }

        /// <summary>
        /// Only use init when you know what you are doing
        /// </summary>
        /// <param name="module"></param>
        public static void Init(ColShapeModule module)
        {
            Module = module;
        }

        public static IColShape Create(ulong id, int dimension, Position position, uint radius)
        {
            var colShape = new ColShape(id, dimension, position, radius);
            Add(colShape);
            return colShape;
        }

        public static void Add(IColShape colShape)
        {
            Module.Add(colShape);
        }
    }
}