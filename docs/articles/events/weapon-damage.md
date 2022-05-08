# WeaponDamage

> [!TIP]
> This event is available on **server-side** only<br>

This event is called when weapon damage occurs

| Parameter | Description                                                                                                                         |
| --------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| player    | Player who caused the damage.                                                                                                       |
| target    | Entity who received the damage.                                                                                                     |
| weapon    | The weapon that was used. See: [Weapons](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs) |
| damage    | The amount of damage that the target received.                                                                                      |
| offset    | The offset coordinates caused by the weapon damage the target received.                                                             |
| bodyPart  | Hit body part.                                                                                                                      |

## Normal event handler

```csharp
Alt.OnWeaponDamage += (player, target, weapon, damage, offset, bodyPart) => {
    // ...
    return true; // false will cancel the damage sync
}
```

## Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.WeaponDamage)]
    public void OnWeaponDamage(IPlayer player, IEntity target, uint weapon, ushort damage, Position offset, BodyPart bodyPart)
    {
        // ...
    }
}
```
