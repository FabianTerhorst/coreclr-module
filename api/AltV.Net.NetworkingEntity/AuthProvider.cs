using System.Collections.Generic;
using AltV.Net.Elements.Entities;

namespace AltV.Net.NetworkingEntity
{
    public class AuthProvider
    {
        private readonly Dictionary<string, IPlayer> playerTokens = new Dictionary<string, IPlayer>();

        private readonly Dictionary<IPlayer, string> playerTokenAccess = new Dictionary<IPlayer, string>();

        public void SendAuthentication(IPlayer player)
        {
            var token = SecretToken.GenerateToken(128);
            lock (player)
            {
                if (!player.Exists) return;
                lock (playerTokens)
                {
                    playerTokens[token] = player;
                    playerTokenAccess[player] = token;

                    player.Emit("streamingToken", token);
                }
            }
        }

        public IPlayer VerifyAuthentication(string token)
        {
            lock (playerTokens)
            {
                if (playerTokens.TryGetValue(token, out var player)) return player;
            }

            return null;
        }

        public void RemoveAuthentication(IPlayer player)
        {
            lock (playerTokens)
            {
                if (!playerTokenAccess.TryGetValue(player, out var token)) return;
                playerTokens.Remove(token);
                playerTokenAccess.Remove(player);
            }
        }
    }
}