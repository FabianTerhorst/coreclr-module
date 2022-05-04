namespace AltV.Net.Client.Elements.Data
{
    public class Voice
    {
        private readonly ICore core;

        internal Voice(ICore core)
        {
            this.core = core;
        }

        public ConsoleKey ActivationKey
        {
            get
            {
                unsafe
                {
                    return (ConsoleKey) core.Library.Client.Core_GetVoiceActivationKey(core.NativePointer);
                }
            }
        }

        public bool ActivityInputEnabled
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Core_IsVoiceActivityInputEnabled(core.NativePointer) == 1;
                }
            }
        }

        public bool MuteInput
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Core_GetVoiceInputMuted(core.NativePointer) == 1;
                }
            }

            set
            {
                unsafe
                {
                    core.Library.Client.Core_SetVoiceInputMuted(core.NativePointer, (byte) (value ? 1 : 0));
                }
            }
        }
    }
}