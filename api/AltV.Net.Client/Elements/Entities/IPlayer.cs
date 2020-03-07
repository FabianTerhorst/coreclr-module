namespace AltV.Net.Client.Elements.Entities
{
    public interface IPlayer : IEntity
    {
        bool IsTalking { get; }
        
        int MicLevel { get; }
        
        string Name { get; }
        
        IVehicle Vehicle { get; }
    }
}