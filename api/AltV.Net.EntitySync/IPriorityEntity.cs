namespace AltV.Net.EntitySync
{
    public interface IPriorityEntity : IEntity
    {
        bool IsHighPriority { get; }
    }
}