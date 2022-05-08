# Player disconnect event

This is called when a player disconnects.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that disconnected |
| reason    | The reason with that the player disconnected |

## Normal event handler

```csharp
Alt.OnPlayerDisconnect += (player, reason) => {
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
        [ScriptEvent(ScriptEventType.PlayerDisconnect)]
        public void OnPlayerDisconnect(IPlayer player, string reason)
        {
            // We loop through every player on our server and notify them
            foreach(IPlayer players in Alt.GetAllPlayers())
            {
                // We notify everyone that our Client has joined the Server
                players.SendChatMessage(player.Name + " has left the Server.");
            }
        }
    }
```
