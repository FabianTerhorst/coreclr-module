namespace AltV.Net.Client.Events
{
    public readonly struct RuntimeEvent
    {
        private readonly IntPtr _nativePointer;

        public bool IsCanceled
        {
            get
            {
                unsafe
                {
                    return Alt.Core.Library.Event_WasCancelled(_nativePointer) == 1;
                }
            }
        }

        public RuntimeEvent(IntPtr nativePointer)
        {
            _nativePointer = nativePointer;
        }

        public void Cancel()
        {
            unsafe
            {
                Alt.Core.Library.Event_Cancel(_nativePointer);
            }
        }
    }
}