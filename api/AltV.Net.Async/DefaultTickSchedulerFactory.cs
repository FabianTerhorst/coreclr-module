using System.Threading;

namespace AltV.Net.Async
{
    public class DefaultTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new QueueTickScheduler(mainThread);
        }
    }
}