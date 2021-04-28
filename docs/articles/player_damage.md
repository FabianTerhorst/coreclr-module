# PlayerDamage 
This is called everytime a player receives damage.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that received damage. |
| entity    | The entity who gave damage to the player. |
| weapon    | The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs |
| damage    | The damage that the player received. |

## Normal event handler

```csharp
    Alt.OnPlayerDamage += (player, attacker, weapon, damage) =>
    {
        // ...
    };
```

## IScript event handler

This event will be called if a player receive any kind of damage.
##### Note : ScriptEvents have to be created in a IScript Class! Otherwise they won't get called.

```csharp
// We create our IScript class
public class MyScriptClass : IScript
{
    // We declare and create our event handler
    [ScriptEvent(ScriptEventType.PlayerDamage)]
    public static void PlayerDamage(IPlayer player, IEntity attacker, uint weapon, ushort damage)
    {
        // We create a switch-statement where we check the type of our IEntity.
        switch (attacker)
        {
            case IPlayer sender:
                player.SendChatMessage("You received damage by " + sender.Name + ".");
                player.SendChatMessage("His weapon was a " + (WeaponModel)weapon + ".");
                return;
            case IVehicle sender:
                player.SendChatMessage("You received damage by a " + (VehicleModel)sender.Model);
                return;
            default:
                player.SendChatMessage("You received damage.");
                return;
        }
    }
}
```
