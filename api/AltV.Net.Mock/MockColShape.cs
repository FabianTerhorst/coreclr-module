using System;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Mock
{
    public class MockColShape : MockWorldObject, IColShape
    {
        public MockColShape(ICore core, IntPtr nativePointer) : base(core, nativePointer, BaseObjectType.ColShape)
        {
        }

        public IntPtr ColShapeNativePointer { get; }
        public ColShapeType ColShapeType { get; }

        public bool IsPlayersOnly { get; set; }

        public bool IsEntityIn(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            Alt.Core.RemoveColShape(this);
        }
        public bool IsEntityIn(ISharedEntity entity)
        {
            throw new NotImplementedException();
        }
        public bool IsPointIn(Vector3 point)
        {
            throw new NotImplementedException();
        }

        public bool IsPlayerIn(IPlayer entity)
        {
            throw new NotImplementedException();
        }

        public bool IsVehicleIn(IVehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}