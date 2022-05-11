namespace AltV.Net.Client.Async
{
    public class ChannelTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new ChannelTickScheduler(mainThread);
        }
    }
}