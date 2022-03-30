namespace AltV.Net.Client.Elements.Data
{
    public class Handling : HandlingData
    {
        private readonly ICore _core;
        private readonly IntPtr _vehiclePointer;
        private static IntPtr GetHandlingPointer(ICore core, IntPtr vehiclePointer)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                // core.Library.Vehicle_GetHandling(vehiclePointer, &pointer);
                // todo
                return pointer;
            }
        }

        internal Handling(ICore core, IntPtr vehiclePointer) : base(core, GetHandlingPointer(core, vehiclePointer))
        {
            _core = core;
            _vehiclePointer = vehiclePointer;
        }
        
        public void ResetHandling()
        {
            unsafe
            {
                // _core.Library.Vehicle_ResetHandling(_vehiclePointer);
                // todo
            }
        }

        public bool IsHandlingModified
        {
            get
            {
                unsafe
                {
                    // return _core.Library.Vehicle_IsHandlingModified(_vehiclePointer) == 1;
                    // todo
                    return false;
                }
            }
        }
        
        protected override void BeforeModified()
        {
            unsafe
            {
                // _core.Library.Vehicle_ReplaceHandling(_vehiclePointer);
                // todo
            }
        }
    }
}