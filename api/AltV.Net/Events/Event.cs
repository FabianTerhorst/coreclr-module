using System;
using AltV.Net.Native;

namespace AltV.Net.Events
{
    public readonly struct Event
    {
        private readonly IntPtr nativePointer;

        public bool IsCanceled
        {
            get
            {
                unsafe
                {
                    return Alt.Server.Library.Event_WasCancelled(nativePointer) == 1;
                }
            }
        }

        public Event(IntPtr nativePointer)
        {
            this.nativePointer = nativePointer;
        }

        public void Cancel()
        {
            unsafe
            {
                Alt.Server.Library.Event_Cancel(nativePointer);
            }
        }
    }
}