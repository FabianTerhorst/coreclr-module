using System.Collections.Generic;
using System.Linq;
using AltV.Net.Elements.Entities;

namespace AltV.Net.NetworkingEntity
{
    public class AuthProvider
    {
        private readonly Dictionary<string, IPlayer> playerTokens = new Dictionary<string, IPlayer>();

        public void SendAuthentication(IPlayer player)
        {
            var token = SecretToken.GenerateToken(128);
            lock (player)
            {
                if (player.Exists)
                {
                    lock (playerTokens)
                    {
                        playerTokens[token] = player;

                        player.Emit("streamingToken", token);
                    }
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
                //TODO: create another dictionary to improve performance of remove lookup
                var item = playerTokens.First(kvp => kvp.Value == player);
                playerTokens.Remove(item.Key);
            }
        }
    }
}