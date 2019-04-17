namespace AltV.Net.Executable.Example
{
    class MyResource : Resource
    {
        public override void OnStart()
        {
            Alt.OnServerEvent += (name, args) =>
            {
                Alt.Log(name + " " + args.Length);
            };
            Alt.Emit("test");
        }

        public override void OnStop()
        {
        }
    }
}