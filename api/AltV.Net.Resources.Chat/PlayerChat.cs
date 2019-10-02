using AltV.Net.Elements.Entities;

namespace AltV.Net.Resources.Chat
{
    public static class PlayerChat
    {
        public static void SendChatMessage(this IPlayer player, string message)
        {
            player.Emit("chatmessage", null, message);
        }
    }
}