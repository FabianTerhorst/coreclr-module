using System.Threading;

namespace AltV.Net.Async
{
    public interface ITickSchedulerFactory
    {
        TickScheduler Create(Thread mainThread);
    }
}