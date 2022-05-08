# PlayerDead

> [!TIP]
> This event is available on **server-side** only<br>

This event is called when a player receives damage.


| Parameter       | Description                                                                                                                         |
| --------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| player          | The player that received damage.                                                                                                    |
| killer          | The killer entity.                                                                                                                  |
| weapon          | The weapon that was used. See: [Weapons](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Data/Weapons.cs) |

## Normal event handler

```csharp
Alt.OnPlayerDead += (player, killer, weapon) => {
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
    [ScriptEvent(ScriptEventType.PlayerDead)]
    public void OnPlayerDead(IPlayer player, IEntity killer, uint weapon)
    {
        // ...
    }
}
```
