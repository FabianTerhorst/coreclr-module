# OnPlayerConnect
This event will be called if a player connect.
Note : Events have to be created in a IScript Class! Otherwise it won´t work!


```csharp
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        /* We declare & Create our Event Handler. */
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(IPlayer client, string reason)
        {
            // We loop through every player on our Server & Notify them.
            foreach(IPlayer players in Alt.GetAllPlayers())
            {
                //We notify everyone that our Client has left the Server.
                players.SendChatMessage(client?.Name + " has joined the Server!");
            }
            //We spawn our Connected Client after 1 sec.
            client.Spawn(new Position(0, 0, 0), 1000);
            // We set his Skin to the standard GTA Online Skin.
            client.Model = Alt.Hash("FreemodeMale01");
        }
    }
```
