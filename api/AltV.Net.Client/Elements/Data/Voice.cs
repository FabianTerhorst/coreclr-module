using AltV.Net.Client.Exceptions;

namespace AltV.Net.Client.Elements.Data
{
    public class Voice
    {
        private readonly ICore core;

        internal Voice(ICore core)
        {
            this.core = core;
        }

        public Key ActivationKey
        {
            get
            {
                unsafe
                {
                    return (Key) core.Library.Client.Core_GetVoiceActivationKey(core.NativePointer);
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
            set
            {
                unsafe
                {
                    var permissionState = (PermissionState) core.Library.Client.Core_ToggleVoiceActivation(core.NativePointer, value ? (byte)1 : (byte)0);
                    if (permissionState != PermissionState.Allowed) throw new PermissionException(Permission.ExtendVoiceApi, permissionState);
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

        public void ToggleInput(bool state)
        {
            unsafe
            {
                var permissionState = (PermissionState) core.Library.Client.Core_ToggleVoiceInput(core.NativePointer, state ? (byte)1 : (byte)0);
                if (permissionState != PermissionState.Allowed) throw new PermissionException(Permission.ExtendVoiceApi, permissionState);
            }
        }

        public float ActivationLevel
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Core_GetVoiceActivationLevel(core.NativePointer);
                }
            }

            set
            {
                unsafe
                {
                    var permissionState = (PermissionState) core.Library.Client.Core_SetVoiceActivationLevel(core.NativePointer, value);
                    if (permissionState != PermissionState.Allowed) throw new PermissionException(Permission.ExtendVoiceApi, permissionState);
                }
            }
        }

        public bool NoiseSuppressionEnabled
        {
            get
            {
                unsafe
                {
                    return core.Library.Client.Core_IsNoiseSuppressionEnabled(core.NativePointer) == 1;
                }
            }

            set
            {
                unsafe
                {
                    var permissionState = (PermissionState) core.Library.Client.Core_ToggleNoiseSuppression(core.NativePointer, value ? (byte)1 : (byte)0);
                    if (permissionState != PermissionState.Allowed) throw new PermissionException(Permission.ExtendVoiceApi, permissionState);
                }
            }
        }
    }
}