using System.Collections.Generic;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape
{
    public interface IColShape
    {
        ulong Id { get; }

        int Dimension { get; }

        Position Position { get; }

        uint Radius { get; }

        IEnumerable<IWorldObject> WorldObjects { get; }

        IDictionary<IWorldObject, bool> LastChecked { get; }

        void AddWorldObject(IWorldObject worldObject);

        void RemoveWorldObject(IWorldObject worldObject);

        bool ContainsWorldObject(IWorldObject worldObject);

        bool IsPositionInside(in Position position);

        void SetCheck(IWorldObject worldObject);

        void ResetCheck(IWorldObject worldObject);

        void RemoveCheck(IWorldObject worldObject);

        bool HasCheck(IWorldObject worldObject);
    }
}