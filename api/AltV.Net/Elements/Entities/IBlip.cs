using System;
using System.Collections.Generic;
using System.Numerics;
using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Net.Elements.Entities
{
    public interface IBlip : IWorldObject, ISharedBlip
    {

        /// <summary>
        /// If the blip is attached.
        /// </summary>
        bool IsAttached { get; }

        /// <summary>
        /// Get the current entity the blip is attached to.
        /// </summary>
        IEntity AttachedTo { get; }

        /// <summary>
        /// Get the type of blip.
        /// </summary>
        new byte BlipType { get; set; }

        /// <summary>
        /// If the blip is global.
        /// </summary>
        new bool IsGlobal { get; set; }

        void AddTargetPlayer(IPlayer player);
        void RemoveTargetPlayer(IPlayer player);
        IReadOnlyCollection<IPlayer> GetTargets();
    }
}
