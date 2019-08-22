using System.Threading;

namespace AltV.Net.Async
{
    public class ChannelTickSchedulerFactory : ITickSchedulerFactory
    {
        public TickScheduler Create(Thread mainThread)
        {
            return new ChannelTickScheduler(mainThread);
        }
    }
}