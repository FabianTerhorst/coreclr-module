using System.Runtime.InteropServices;

namespace AltV.Net.Host.Diagnostics.Eventing
{
    /// <summary>
    /// Message header used to send commands to the .NET Core runtime through IPC.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MessageHeader
    {
        /// <summary>
        /// Request type.
        /// </summary>
        public DiagnosticsMessageType RequestType;

        /// <summary>
        /// Remote process Id.
        /// </summary>
        public uint Pid;
    }
}