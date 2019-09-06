using AltV.Net.Elements.Entities;
using AltV.Net.NetworkingEntity.Elements.Entities;

namespace AltV.Net.NetworkingEntity
{
    public static class PlayerClientExtension
    {
        private const string ClientKey = "nw::client";

        public static bool TryGetNetworkingClient(this IPlayer player, out INetworkingClient client)
        {
            return player.GetData(ClientKey, out client);
        }

        internal static void SetNetworkingClient(this IPlayer player, INetworkingClient client)
        {
            player.SetData(ClientKey, client);
        }

        internal static void RemoveNetworkingClient(this IPlayer player)
        {
            player.SetData(ClientKey, null);
        }
    }
}