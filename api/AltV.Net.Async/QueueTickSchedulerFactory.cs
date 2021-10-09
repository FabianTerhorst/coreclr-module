using System.Threading;

namespace AltV.Net.Async
{
    public class QueueTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new QueueTickScheduler(mainThread);
        }
    }
}