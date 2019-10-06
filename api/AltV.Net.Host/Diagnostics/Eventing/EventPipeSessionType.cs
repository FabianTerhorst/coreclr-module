namespace AltV.Net.Host.Diagnostics.Eventing
{
    /// <summary>
    /// Defines constants for EventPipe logging sessions.
    /// </summary>
    public enum EventPipeSessionType : uint
    {
        /// <summary>
        /// The events will be written to file at the end of the session.
        /// </summary>
        TraceToFile,

        /// <summary>
        /// Events will be passed to the EventListener.
        /// </summary>
        CallbackListener,

        /// <summary>
        /// Events will be sent out-of-proc by writing them to the underlying IPC stream implementation.
        /// </summary>
        TraceToStream
    }
}