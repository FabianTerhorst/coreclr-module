namespace AltV.Net.Client.Elements.Data
{
    public class Handling : HandlingData
    {
        private readonly ICore core;
        private readonly IntPtr vehiclePointer;
        private static IntPtr GetHandlingPointer(ICore core, IntPtr vehiclePointer)
        {
            unsafe
            {
                var pointer = IntPtr.Zero;
                core.Library.Client.Vehicle_GetHandling(vehiclePointer, &pointer);
                return pointer;
            }
        }

        internal Handling(ICore core, IntPtr vehiclePointer) : base(core, GetHandlingPointer(core, vehiclePointer))
        {
            this.core = core;
            this.vehiclePointer = vehiclePointer;
        }
        
        public void ResetHandling()
        {
            unsafe
            {
                core.Library.Client.Vehicle_ResetHandling(vehiclePointer);
            }
        }

        public bool IsHandlingModified
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Vehicle_IsHandlingModified(vehiclePointer) == 1;
                }
            }
        }
        
        protected override void BeforeModified()
        {
            unsafe
            {
                core.Library.Client.Vehicle_ReplaceHandling(vehiclePointer);
            }
        }
    }
}