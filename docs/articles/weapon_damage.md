# WeaponDamage 
This is called everytime a player deals damage to another entity with a weapon.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that got killed |
| killer    | The killer who got hitted by a Player |
| weapon    | The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs |

## Normal event handler

```csharp
Alt.OnWeaponDamage += (player, killer, weapon, damage, offset, bodypart) => {
    // ...
    return true; // return false will cancel the event and player won't receive damage.
}
```

## IScript event handler

This event will be called if a player do any damage by a Weapon to a other player.
##### Note : ScriptEvents have to be created in a IScript Class! Otherwise it won´t work!

```csharp
// We create our IScript class
public class MyScriptClass : IScript
{
    // We declare and create our event handler
    [ScriptEvent(ScriptEventType.WeaponDamage)]
    public static bool WeaponDamage(IPlayer player, IEntity target, uint weapon, ushort damage, Position offset, BodyPart bodypart)
    {
        // We convert the weapon uint to a regular weaponmodel enum
        AltV.Net.Enums.WeaponModel weaponModel = (AltV.Net.Enums.WeaponModel) weapon;
        if (target is IPlayer targetPlayer) {
            player?.SendChatMessage("You hitted " + targetPlayer?.Name + " and gave him " + damage + " damage! Weapon: " + weaponModel);
            targetPlayer?.SendChatMessage(player?.Name + " hitted you and gave you " + damage + " damage! Weapon: " + weaponModel);

            // We check if the hitted body part was the head
            if (bodypart == BodyPart.Head)
            {
                player?.SendChatMessage("You hitted a Player in " + bodypart);
                targetPlayer?.SendChatMessage("You got hitted by a " + weaponModel + " in " + bodypart);
            }
        }
        
        return true; // return false will cancel the event and player won't receive damage.
    }
}
```
