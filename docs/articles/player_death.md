# OnPlayerDeath
Note : Death reason could be a WeaponHash too.

```csharp 
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        /* We Declare & Create our Event handler. */
        [ScriptEvent(ScriptEventType.PlayerDead)]
        public static void OnPlayerDeath(IPlayer player, IPlayer killer, uint reason)
        {
        
            /* If you killed yourself then it should notify you. */
            if (killer.Name.Equals(player.Name))
            {
                player.SendChatMessage("You killed yourself... :(");
                return;
            }
            
            /* We Notify the Killer & the Player. */
            killer.SendChatMessage("You killed " + player.Name);
            player.SendChatMessage(killer.Name + " killed you!");

            /* We Spawn the dead player after 1000 MS */
            /* ( 1 Second = 1000 MS ). */
            player.Spawn(new Position(0, 0, 0), 1000);
        }
    }
```
