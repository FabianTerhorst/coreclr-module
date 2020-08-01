using System.Threading;

namespace AltV.Net.Async
{
    public class ActionTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new ActionTickScheduler();
        }
    }
}