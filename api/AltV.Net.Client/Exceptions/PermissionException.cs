using AltV.Net.Client.Elements.Data;

namespace AltV.Net.Client.Exceptions
{
    public class PermissionException : Exception
    {
        public Permission Permission { get; }

        public PermissionException(Permission permission)
        {
            Permission = permission;
        }

        public override string Message => $"Permission {Permission} is denied";
    }
}