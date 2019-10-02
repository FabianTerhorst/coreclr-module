using AltV.Net.Elements.Entities;

namespace AltV.Net.Resources.Chat.Api
{
    public static class PlayerChatExtensions
    {
        public static void SendChatMessage(this IPlayer player, string message)
        {
            AltChat.Chat.Send(player, message);
        }
    }
}