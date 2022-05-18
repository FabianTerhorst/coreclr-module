namespace AltV.Net.Client.Async
{
    public interface ITickSchedulerFactory
    {
        ITickScheduler Create(Thread mainThread);
    }
}