# WeaponDamage 
This is called everytime a player deals damage to another entity with a weapon.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that got killed |
| target    | The target who got damaged by the player |
| weapon    | The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs |
| damage    | The damage that the target received. |
| offset    | The offset coordinates caused by the weapon damage the target received. |


## Normal event handler

```csharp
Alt.OnWeaponDamage += (player, target, weapon, damage, offset, bodypart) => {
    // ...
    return true; // return false will cancel the event and player won't receive damage.
}
```

## IScript event handler

This event will be called if a player deals any damage by a weapon to a other victim.
##### Note : ScriptEvents have to be created in a IScript Class! Otherwise it won´t work!

```csharp
// We create our IScript class
public class MyScriptClass : IScript
{
    // We declare and create our event handler
    [ScriptEvent(ScriptEventType.WeaponDamage)]
    public static bool WeaponDamage(IPlayer player, IEntity target, uint weapon, ushort damage, Position offset, BodyPart bodyPart)
    {
        switch (target)
        {
            case IPlayer victim:
                string aimLevel = bodyPart switch
                {
                    BodyPart.Head => "very solid & awesome!",
                    BodyPart.Chest => "mysterious like a chest...",
                    BodyPart.Pelvis => "evil!",
                    _ => "very bad..."
                };
                player?.SendChatMessage("You shot " + victim.Name + "! Your aim is " + aimLevel);
                return true;
            default:
                return false; // <= return false will cancel the event and player won't receive damage.
        }
    }
}
```
