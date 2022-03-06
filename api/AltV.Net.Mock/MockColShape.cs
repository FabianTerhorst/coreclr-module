using System;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

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