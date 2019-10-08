namespace AltV.Net.Elements.Entities
{
    public interface IVoiceChannel : IBaseObject
    {        
        /// <summary>
        /// Adds the player to the voice channel
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void AddPlayer(IPlayer player);
        
        /// <summary>
        /// Removes the player from the voice channel
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void RemovePlayer(IPlayer player);
        
        /// <summary>
        /// Mutes the player in the voice channel
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void MutePlayer(IPlayer player);
        
        /// <summary>
        /// Unmutes the player in the voice channel
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        void UnmutePlayer(IPlayer player);
        
        /// <summary>
        /// Returns if the player is connected to the voice channel
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsPlayerConnected(IPlayer player);
        
        /// <summary>
        /// Returns if the player is muted in the voice channel
        /// </summary>
        /// <param name="player">The player</param>
        /// <exception cref="EntityRemovedException">This entity was removed</exception>
        bool IsPlayerMuted(IPlayer player);
        
        /// <summary>
        /// Returns if the voice channel is spatial
        /// </summary>
        bool IsSpatial { get; }
        
        /// <summary>
        /// Returns the maximum distance
        /// </summary>
        float MaxDistance { get; }
        
        /// <summary>
        /// Removes the voice channel
        /// </summary>
        void Remove();
    }
}