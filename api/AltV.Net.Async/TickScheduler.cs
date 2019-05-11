using System.Threading.Tasks;

namespace AltV.Net.Async
{
    public abstract class TickScheduler : TaskScheduler
    {
        public abstract void Tick();
    }
}