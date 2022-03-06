namespace AltV.Net
{
    public partial class Alt
    {
        public static void StartResource(string name) => Module.Core.StartResource(name);

        public static void StopResource(string name) => Module.Core.StopResource(name);

        public static void RestartResource(string name) => Module.Core.RestartResource(name);

        public static INativeResource GetResource(string name) => Module.Core.GetResource(name);

        public static INativeResource Resource => Module.Core.Resource;
    }
}