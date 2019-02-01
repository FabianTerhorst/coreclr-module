using System.Runtime.InteropServices;

namespace AltV.Net.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rotation
    {
        public static Rotation Zero = new Rotation
        {
            roll = 0,
            pitch = 0,
            yaw = 0
        };

        public float roll;
        public float pitch;
        public float yaw;

        public Rotation(float roll, float pitch, float yaw)
        {
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;
        }
    }
}