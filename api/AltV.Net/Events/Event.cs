using System;
using AltV.Net.Native;

namespace AltV.Net.Events
{
    public readonly struct Event
    {
        private readonly IntPtr nativePointer;

        public bool IsCanceled => AltNative.Event.Event_WasCancelled(nativePointer);

        public Event(IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
        }

        public void Cancel()
        {
            AltNative.Event.Event_Cancel(nativePointer);
        }
    }
}