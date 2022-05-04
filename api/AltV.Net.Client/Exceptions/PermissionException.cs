using AltV.Net.Client.Elements.Data;

namespace AltV.Net.Client.Exceptions
{
    public class PermissionException : Exception
    {
        public Permission Permission { get; }
        public PermissionState PermissionState { get; }

        public PermissionException(Permission permission, PermissionState permissionState)
        {
            Permission = permission;
            PermissionState = permissionState;
        }

        public override string Message
        {
            get
            {
                return PermissionState switch
                {
                    PermissionState.Denied => $"Permission {Permission} is denied",
                    PermissionState.Unspecified => $"Permission {Permission} is not specified",
                    _ => $"Permission {Permission} check failed"
                };
            }
        }
    }
}