namespace AltV.Net.Elements.Entities
{
    public interface IVoiceChannel : IBaseObject
    {
        void AddPlayer(IPlayer player);
        void RemovePlayer(IPlayer player);
        void MutePlayer(IPlayer player);
        void UnmutePlayer(IPlayer player);
        bool IsPlayerConnected(IPlayer player);
        bool IsPlayerMuted(IPlayer player);
        bool IsSpatial { get; }
        float MaxDistance { get; }
        void Remove();
    }
}