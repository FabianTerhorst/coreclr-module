namespace AltV.Net.Async
{
    public abstract class AsyncResource : Resource
    {
        private readonly AltVAsync altVAsync = new AltVAsync();

        public override void OnTick()
        {
            altVAsync.Tick();
        }
    }
}