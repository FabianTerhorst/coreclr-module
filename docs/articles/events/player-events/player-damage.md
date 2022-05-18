# PlayerDamage

> [!TIP]
> This event is available on **server-side** only<br>

This event is called when a player receives damage.


| Parameter       | Description                                                                                                                         |
| --------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| player          | The player that received damage.                                                                                                    |
| attacker        | The entity who gave damage to the player.                                                                                           |
| weapon          | The weapon that was used. See: [Weapons](https://github.com/FabianTerhorst/coreclr-module/blob/dev/api/AltV.Net.Shared/Enums/WeaponModel.cs) |
| healthDamage    | The health damage that the player received.                                                                                         |
| armourDamage    | The armour damage that the player received.                                                                                         |

## Normal event handler

```csharp
Alt.OnPlayerDamage += (player, attacker, weapon, healthDamage, armourDamage) => {
    // ...
}
```

## Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.PlayerDamage)]
    public void OnPlayerDamage(IPlayer player, IEntity attacker, uint weapon, ushort healthDamage, ushort armourDamage)
    {
        // ...
    }
}
```
