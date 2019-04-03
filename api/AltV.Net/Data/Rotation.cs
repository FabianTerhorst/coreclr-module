using System.Numerics;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rotation
    {
        public static Rotation Zero = new Rotation
        {
            Roll = 0,
            Pitch = 0,
            Yaw = 0
        };

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
    }
}