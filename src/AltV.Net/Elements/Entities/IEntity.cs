using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using AltV.Net.Native;

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
        /// Get current entity existence
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

        /// <summary>
        /// Get or set position of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Position Position { get; set; }

        /// <summary>
        /// Get or set rotation of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Rotation Rotation { get; set; }

        /// <summary>
        /// Get or set dimension of the entity.
        /// </summary>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        ushort Dimension { get; set; }

        void SetPosition(float x, float y, float z);

        void SetRotation(float roll, float pitch, float yaw);

        void SetMetaData(string key, MValue value);

        MValue GetMetaData(string key);

        void SetData(string key, object value);

        bool GetData<T>(string key, out T result);
    }
}