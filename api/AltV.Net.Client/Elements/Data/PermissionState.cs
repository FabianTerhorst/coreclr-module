namespace AltV.Net.Client.Elements.Data
{
    public enum PermissionState : byte
    {
        // Permission is allowed by the user
        Allowed,
        // Permission is denied by the user
        Denied,
        // When a permission has not been specified by any of the resources
        Unspecified,
        // When an action requiring permission fails
        Failed
    };
}