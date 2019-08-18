namespace AltV.Net.Chat
{
    public static class ChatUtils
    {
        public static void SendBroadcastChatMessage(string message)
        {
            Alt.EmitAllClients("chatmessage", null, message);
        }
    }
}