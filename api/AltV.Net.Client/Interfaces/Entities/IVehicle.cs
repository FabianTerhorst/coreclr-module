namespace AltV.Net.Client.Interfaces.Entities
{
    public interface IVehicle : IEntity
    {
        // TODO: virtual Ref<IPlayer> GetDriver() const = 0;
        bool IsDestroyed { get; }
        uint GetMod(uint category);
        uint GetModsCount(uint category);
        uint GetModKitCount { get; }
        uint GetModKit { get; }
        bool IsPrimaryColorRGB { get; }
        uint GetPrimaryColor { get; }
        bool IsSecondaryColorRGB { get; }
        uint GetSecondaryColor { get; }
    }
}