using System.Threading;

namespace AltV.Net.Async
{
    public interface ITickSchedulerFactory
    {
        ITickScheduler Create(Thread mainThread);
    }
}