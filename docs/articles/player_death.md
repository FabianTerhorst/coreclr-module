# OnPlayerDeath

This is called when a player dies.

player: The player that got killed
killer: The player that killed the player (other player, hisself, null)
weapon: The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs

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
    public class AltV_Wiki : IScript
    {
        // We declare and create our event handler
        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(IPlayer player, IPlayer killer, uint weapon)
        {
            // If you killed yourself then it should notify you
            if (killer == player) {
                player.SendChatMessage("You killed yourself");
            }
            else
            {
                // We notify the killer and the player.
                killer.SendChatMessage("You killed " + player.Name);
                player.SendChatMessage(killer?.Name + " killed you!");
            }
            // We spawn the dead player after 1000ms at (0, 0, 72)
            player.Spawn(new Position(0, 0, 72), 1000);
        }
    }
```
