namespace AltV.Net.Host.Diagnostics.Eventing
{
    /// <summary>
    /// Different diagnostic message types that are handled by the runtime.
    /// </summary>
    public enum DiagnosticsMessageType : uint
    {
        /// <summary>
        /// Initiates core dump generation 
        /// </summary>
        GenerateCoreDump = 1,
        /// <summary>
        /// Starts an EventPipe session that writes events to a file when the session is stopped or the application exits.
        /// </summary>
        StartEventPipeTracing = 1024,
        /// <summary>
        /// Stops an EventPipe session.
        /// </summary>
        StopEventPipeTracing,
        /// <summary>
        /// Starts an EventPipe session that sends events out-of-proc through IPC.
        /// </summary>
        CollectEventPipeTracing,
        /// <summary>
        /// Attaches a profiler to an existing process
        /// </summary>
        AttachProfiler = 2048,
    }
}