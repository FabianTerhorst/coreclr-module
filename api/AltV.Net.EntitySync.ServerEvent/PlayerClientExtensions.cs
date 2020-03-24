using AltV.Net.Elements.Entities;

namespace AltV.Net.EntitySync.ServerEvent
{
    public static class PlayerClientExtensions
    {
        private const string PlayerSyncClientKey = "entitySync:client";

        public static bool TryGetEntitySyncClient(this IPlayer player, out PlayerClient client)
        {
            return player.GetData(PlayerSyncClientKey, out client);
        }

        internal static void SetEntitySyncClient(this IPlayer player, PlayerClient client)
        {
            player.SetData(PlayerSyncClientKey, client);
        }
    }
}