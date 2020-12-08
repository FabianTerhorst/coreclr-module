# Player dead event

This is called when a player dies.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that got killed |
| killer    | The killer who killed the player |
| weapon    | The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs |

## Normal event handler

```csharp
Alt.OnPlayerDead += (player, killer, weapon) => {
    // ...
}
```

## IScript event handler

##### Note : ScriptEvents have to be created in a IScript Class! Otherwise it won´t work!

```csharp 
    // We create our IScript class
    public class MyScriptClass : IScript
    {
        // We declare and create our event handler
        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDead(IPlayer player, IEntity killer, uint weapon)
        {
            if ((killer is IPlayer killerPlayer)){
                // If you killed yourself then it should notify you
                if (killerPlayer == player) {
                    player.SendChatMessage("You killed yourself");
                }
                else
                {
                    // We notify the killer and the player.
                    killerPlayer.SendChatMessage("You killed " + player.Name);
                    player.SendChatMessage(killerPlayer?.Name + " killed you!");
                }
            }
            else if((killer is IVehicle vehicle)){
                player.SendChatMessage("You got killed by a " + (VehicleModel)vehicle.model);
            }
            // We spawn the dead player after 1000ms at (0, 0, 72)
            player.Spawn(new Position(0, 0, 72), 1000);
        }
    }
```
