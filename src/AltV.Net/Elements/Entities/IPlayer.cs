namespace AltV.Net.Elements.Entities
{
    public interface IPlayer : IEntity
    {
        void Call(string eventName, params object[] args);
    }
}