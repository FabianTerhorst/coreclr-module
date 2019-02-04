using System;

namespace AltV.Net.Native
{
    //TODO: maybe later when cancel is working
    public class CPlayerConnectEvent
    {
        private readonly IntPtr NativePointer;

        public CPlayerConnectEvent(IntPtr nativePointer)
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