using AltV.Net.Data;

namespace AltV.Net.Elements.Entities
{
    public interface IPlayer : IEntity
    {
        void Call(string eventName, params object[] args);

        ReadOnlyPlayer Copy();
    }
}