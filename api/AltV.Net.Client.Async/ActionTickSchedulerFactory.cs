namespace AltV.Net.Client.Async
{
    public class ActionTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new ActionTickScheduler();
        }
    }
}