namespace AltV.Net.Client.Async
{
    public class QueueTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new QueueTickScheduler(mainThread);
        }
    }
}