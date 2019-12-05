namespace AltV.Net.Resources.Chat.Api
{
    public static class AltChat
    {
        //internal static Chat Chat;

        public static void SendBroadcast(string message)
        {
            //Chat.Broadcast(message);
            Alt.EmitAllClients("chat:message", null, message);
        }

        /*internal static void Init(Chat chat)
        {
            Chat = chat;
        }*/
    }
}