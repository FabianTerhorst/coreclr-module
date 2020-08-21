# PlayerConnect event

This event will be called on a player connect.

player: the player that connected
reason: null for now, might contain favorites, masterlist, directconnect in the future

## Normal event handler

```csharp
Alt.OnPlayerConnect += (player, reason) => {
    // ...
}
```

## IScript event handler

##### Note : ScriptEvents have to be created in a IScript Class! Otherwise it won´t work!


```csharp
    // We create our IScript class
    public class MyIScriptClass : IScript
    {
        // We declare and create our event handler
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(IPlayer player, string reason)
        {
            // We loop through every player on our server and notify them
            foreach(IPlayer players in Alt.GetAllPlayers())
            {
                // We notify everyone that our Client has joined the Server
                players.SendChatMessage(player.Name + " has joined the Server.");
            }
            // We spawn the newly connected player
            player.Spawn(new Position(0, 0, 72));
            // We set his skin to the standard gta online freemode skin
            player.Model = Alt.Hash("FreemodeMale01");
        }
    }
```
