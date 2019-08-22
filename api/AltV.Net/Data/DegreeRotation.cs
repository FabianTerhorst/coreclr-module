using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DegreeRotation
    {
        public static DegreeRotation Zero = new DegreeRotation
        {
            Roll = 0,
            Pitch = 0,
            Yaw = 0
        };

        public float Roll;
        public float Pitch;
        public float Yaw;

        public DegreeRotation(float roll, float pitch, float yaw)
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }

        public override string ToString()
        {
            return $"DegreeRotation(roll: {Roll}°, pitch: {Pitch}°, yaw: {Yaw}°)";
        }

        public static implicit operator Rotation(DegreeRotation rotation)
        {
            return new Rotation
            {
                Roll = DegreeToRadian(rotation.Roll),
                Pitch = DegreeToRadian(rotation.Pitch),
                Yaw = DegreeToRadian(rotation.Yaw)
            };
        }

        public static implicit operator DegreeRotation(Rotation rotation)
        {
            return new DegreeRotation
            {
                Roll = RadianToDegree(rotation.Roll),
                Pitch = RadianToDegree(rotation.Pitch),
                Yaw = RadianToDegree(rotation.Yaw)
            };
        }

        private static float DegreeToRadian(float angle)
        {
            return MathF.PI * angle / 180f;
        }

        private static float RadianToDegree(float angle)
        {
            return angle * (180f / MathF.PI);
        }
    }
}