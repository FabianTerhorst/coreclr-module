using System;

namespace AltV.Net.Native
{
    //TODO: maybe later when cancel is working
    internal class CPlayerConnectEvent
    {
        private readonly IntPtr NativePointer;

        internal CPlayerConnectEvent(IntPtr nativePointer)
        {
            NativePointer = nativePointer;
        }

        private IntPtr GetTarget()
        {
            return IntPtr.Zero;
        }

        private string GetReason()
        {
            return null;
        }

        public void Cancel(string reason)
        {
            
        }
    }
}