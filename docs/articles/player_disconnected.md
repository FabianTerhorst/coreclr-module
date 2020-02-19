# OnPlayerDisconnected
This event will be called if a player disconnect.
Note : Events have to be created in a IScript Class! Otherwise it won´t work!

```csharp
    public class AltV_Wiki : IScript
    {
        /* We declare & Create our Event Handler. */
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnected(IPlayer client, string reason)
        {
            // We loop through every player on our Server & Notify them.
            foreach(IPlayer players in Alt.GetAllPlayers())
            {
                //We notify everyone that our Client has left the Server.
                players.SendChatMessage(client?.Name + " has left the Server! Reason " + reason);
            }
        }
    }
```
