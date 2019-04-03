using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Position
    {
        //TODO: migrate to System.Numerics.Vector3

        public static readonly float TOLERANCE = 0.013F; //0.01318359375F;

        public static Position Zero = new Position(0, 0, 0);
        
        public static implicit operator Vector3(Position position)
        {
            return new Vector3
            {
                X = position.X,
                Y = position.Y,
                Z = position.Z
            };
        }

        public static implicit operator Position(Vector3 vector3)
        {
            return new Position
            {
                X = vector3.X,
                Y = vector3.Y,
                Z = vector3.Z
            };
        }

        public float X;
        public float Y;
        public float Z;

        public Position(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public float GetMagnitude() => MathF.Sqrt(X * X + Y * Y + Z * Z);

        public float Distance(Position b) =>
            MathF.Sqrt((X - b.X) * (X - b.X) + (Y - b.Y) * (Y - b.Y) + (Z - b.Z) * (Z - b.Z));

        public static Position operator +(Position a, Position b) => new Position(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Position operator -(Position a, Position b) => new Position(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Position operator -(Position a) => new Position(-a.X, -a.Y, -a.Z);

        public static Position operator *(Position a, float d) => new Position(a.X * d, a.Y * d, a.Z * d);

        public static Position operator *(float d, Position a) => new Position(a.X * d, a.Y * d, a.Z * d);

        public static Position operator /(Position a, float d) => new Position(a.X / d, a.Y / d, a.Z / d);

        public static Position Cross(Position lhs, Position rhs) => new Position(
            lhs.Y * rhs.Z - lhs.Z * rhs.Y,
            lhs.Z * rhs.X - lhs.X * rhs.Z,
            lhs.X * rhs.Y - lhs.Y * rhs.X);

        public static Position Scale(Position a, Position b) => new Position(a.X * b.X, a.Y * b.Y, a.Z * b.Z);

        // Linearly interpolates between two positions without clamping the interpolant
        public static Position LerpUnclamped(Position a, Position b, float t) =>
            new Position(
                a.X + (b.X - a.X) * t,
                a.Y + (b.Y - a.Y) * t,
                a.Z + (b.Z - a.Z) * t
            );

        public static Position MoveTowards(Position current, Position target, float maxDistanceDelta)
        {
            var toVector = target - current;
            var dist = toVector.GetMagnitude();
            if (dist <= maxDistanceDelta || dist < float.Epsilon)
                return target;
            return current + toVector / dist * maxDistanceDelta;
        }

        public override string ToString()
        {
            return $"Position(x: {X}, y: {Y}, z: {Z})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Position position)
                return Math.Abs(position.X - X) < TOLERANCE && Math.Abs(position.Y - Y) < TOLERANCE &&
                       Math.Abs(position.Z - Z) < TOLERANCE;
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (Y.GetHashCode() << 2) ^ (Z.GetHashCode() >> 2);
        }
    }
}