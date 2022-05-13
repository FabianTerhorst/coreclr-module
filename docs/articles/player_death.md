# Player dead event

This is called when a player dies.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that got killed |
| killer    | The killer who killed the player |
| weapon    | The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/release/api/AltV.Net/Data/Weapons.cs |

## Normal event handler

```csharp
Alt.OnPlayerDead += (player, killer, weapon) => {
    // ...
}
```

## IScript event handler

##### Note : ScriptEvents have to be created in a IScript class! Otherwise it won't work!

```csharp 
    // We create our IScript class
    public class MyScriptClass : IScript
    {
        // We declare and create our event handler
        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDead(IPlayer player, IEntity attacker, uint weapon)
        {
            
            string deathReason = attacker switch
            {
                IPlayer attackerPlayer when attackerPlayer == player => "yourself!",
                IPlayer killerPlayer => killerPlayer?.Name,
                IVehicle vehicle => "a " + ((VehicleModel)vehicle?.Model),
                _ => "world caused damage."
            };
            
            player?.SendChatMessage("You got killed by " + deathReason);
            
            player?.Spawn(new Vector3(0, 0, 72), 1000); // <= We spawn the dead player after 1000ms.
        }
    }
```
