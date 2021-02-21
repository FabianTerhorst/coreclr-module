namespace AltV.Net
{
    public partial class Alt
    {
        public static void StartResource(string name) => Module.Server.StartResource(name);

        public static void StopResource(string name) => Module.Server.StopResource(name);

        public static void RestartResource(string name) => Module.Server.RestartResource(name);

        public static INativeResource GetResource(string name) => Module.Server.GetResource(name);

        public static INativeResource Resource => Module.Server.Resource;
    }
}