using AltV.Net.Elements.Entities;

namespace AltV.Net.EntitySync.ServerEvent
{
    public static class PlayerClientExtensions
    {
        private const string PlayerSyncClientKey = "entitySync:client";

        public static bool TryGetEntitySyncClient(this IPlayer player, out IClient client)
        {
            return player.GetData(PlayerSyncClientKey, out client);
        }

        internal static void SetEntitySyncClient(this IPlayer player, IClient client)
        {
            player.SetData(PlayerSyncClientKey, client);
        }
    }
}