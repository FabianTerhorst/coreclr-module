namespace AltV.Net
{
    public static partial class Alt
    {
        private static Module _module;

        public static Server Server => _module.Server;

        public static void On(string eventName, Function function)
        {
            _module.On(eventName, function);
        }
        
        internal static void Setup(Module module)
        {
            _module = module;
        }
    }
}