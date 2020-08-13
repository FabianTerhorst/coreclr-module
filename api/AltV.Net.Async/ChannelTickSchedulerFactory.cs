using System.Threading;

namespace AltV.Net.Async
{
    public class ChannelTickSchedulerFactory : ITickSchedulerFactory
    {
        public ITickScheduler Create(Thread mainThread)
        {
            return new ChannelTickScheduler(mainThread);
        }
    }
}