# WeaponDamage 
This is called everytime a player deals damage to another entity with a weapon.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that got killed |
| entity    | The entity who gave damage to the Player |
| weapon    | The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs |

## Normal event handler

```csharp
    Alt.OnPlayerDamage += (player, entity, weapon, damage) =>
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
    public static void PlayerDamage(IPlayer receiver, IEntity entity, uint weapon, ushort damage)
    {
        // We create a switch-statement where we check the type of our IEntity.
        switch (entity)
        {
            case IPlayer sender:
                receiver.SendChatMessage("You received damage by " + sender.Name + ".");
                receiver.SendChatMessage("His weapon was a " + (WeaponModel)weapon + ".");
                return;
            case IVehicle sender:
                receiver.SendChatMessage("You received damage by a " + (VehicleModel)sender.Model);
                return;
            default:
                receiver.SendChatMessage("You received damage.");
                return;
        }
    }
}
```
