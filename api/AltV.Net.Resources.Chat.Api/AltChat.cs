namespace AltV.Net.Resources.Chat.Api
{
    public static class AltChat
    {
        internal static Chat Chat;

        public static void SendBroadcast(string message)
        {
            Chat.Broadcast(message);
        }

        internal static void Init(Chat chat)
        {
            Chat = chat;
        }
    }
}