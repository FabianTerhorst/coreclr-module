using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rotation : IEquatable<Rotation>
    {
        public static Rotation Zero = new Rotation(0, 0, 0);

        public static implicit operator Vector3(Rotation rotation)
        {
            return new Vector3
            {
                X = rotation.Roll,
                Y = rotation.Pitch,
                Z = rotation.Yaw
            };
        }

        public static implicit operator Rotation(Vector3 vector3)
        {
            return new Rotation
            {
                Roll = vector3.X,
                Pitch = vector3.Y,
                Yaw = vector3.Z
            };
        }

        public float Roll;
        public float Pitch;
        public float Yaw;

        public Rotation(float roll, float pitch, float yaw)
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }

        public override string ToString()
        {
            return $"Rotation(roll: {Roll}, pitch: {Pitch}, yaw: {Yaw})";
        }

        public override bool Equals(object obj)
        {
            return obj is Rotation other && Equals(other);
        }

        public bool Equals(Rotation other)
        {
            return Roll.Equals(other.Roll) && Pitch.Equals(other.Pitch) && Yaw.Equals(other.Yaw);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Roll.GetHashCode();
                hashCode = (hashCode * 397) ^ Pitch.GetHashCode();
                hashCode = (hashCode * 397) ^ Yaw.GetHashCode();
                return hashCode;
            }
        }
    }
}