using System;
using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape
{
    public static class AltColShape
    {
        internal static ColShapeModule Module;

        public static Action<IWorldObject, ColShape> OnEntityEnterColShape
        {
            set => Module.OnEntityEnterColShape += value;
        }

        public static Action<IWorldObject, ColShape> OnEntityExitColShape
        {
            set => Module.OnEntityExitColShape += value;
        }
        
        public static void Init(ColShapeModule module)
        {
            Module = module;
        }

        public static void Create(Position position, uint radius)
        {
            Module.Add(new ColShape
            {
                Id = 1,
                Position = position,
                Radius = radius,
                WorldObjects = new HashSet<IWorldObject>()
            });
        }
    }
}