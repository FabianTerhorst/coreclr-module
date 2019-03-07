using System;
using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockEntities
    {
        public static IntPtr Ptr = IntPtr.Zero;

        public static ushort Id = 0;

        public static readonly Dictionary<IntPtr, IBaseObject> Entities = new Dictionary<IntPtr, IBaseObject>();

        public static IntPtr GetNextPtr()
        {
            Ptr += 1;
            Id++;
            return Ptr;
        }

        public static void Insert(IBaseObject entity)
        {
            Entities[Ptr] = entity;
        }
    }
}