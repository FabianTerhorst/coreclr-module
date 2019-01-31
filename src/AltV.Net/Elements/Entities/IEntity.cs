using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace AltV.Net.Elements.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// Get the internal entity pointer.
        ///
        /// WARNING: Do NOT use this.
        /// </summary>
        IntPtr NativePointer { get; }

        /// <summary>
        /// Get current entity existance
        ///
        /// WARNING: Do NOT use this.
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Get the entity id.
        /// </summary>
        ushort Id { get; }

        /// <summary>
        /// Get the entity type.
        /// </summary>
        EntityType Type { get; }
    }
}