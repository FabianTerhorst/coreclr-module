namespace AltV.Net.Client.Async
{
    public class DefaultTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new ActionTickScheduler();
        }
    }
}