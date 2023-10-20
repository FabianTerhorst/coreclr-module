namespace AltV.Net
{
    public partial class Alt
    {
        public static void StartResource(string name) => Core.StartResource(name);

        public static void StopResource(string name) => Core.StopResource(name);

        public static void RestartResource(string name) => Core.RestartResource(name);

        public static INativeResource GetResource(string name) => Core.GetResource(name);
        public static INativeResource[] GetAllResources() => Core.GetAllResources();

        public static INativeResource Resource => Core.Resource;
    }
}