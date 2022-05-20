# PlayerWeaponChange

> [!TIP]
> This event is available on **server-side** only<br>

This event is called when a player changes weapon.


| Parameter       | Description                                                                                                                         |
| --------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| player          | The player who changed weapon.                                                                                                      |
| oldWeapon       | The old weapon. See: [Weapons](https://github.com/FabianTerhorst/coreclr-module/blob/dev/api/AltV.Net.Shared/Enums/WeaponModel.cs)           |
| newWeapon       | The new weapon. See: [Weapons](https://github.com/FabianTerhorst/coreclr-module/blob/dev/api/AltV.Net.Shared/Enums/WeaponModel.cs)           |

## Normal event handler

```csharp
Alt.OnPlayerWeaponChange += (player, oldWeapon, newWeapon) => {
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
    [ScriptEvent(ScriptEventType.PlayerWeaponChange)]
    public void OnPlayerWeaponChange(IPlayer player, uint oldWeapon, uint newWeapon)
    {
        // ...
    }
}
```
