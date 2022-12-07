# Fire

This event is called when a player causes a fire. Return false to remove the fire before it is seen from other players.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| player        | The player syncing the fire                          |
| fireInfos     | The infos about the fire                             |

### Normal event handler

```csharp
Alt.OnFire += (player, fireInfos) => {
    // ...
    return true
}
```

### Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.Fire)]
    public bool OnFire(IPlayer player, FireInfo[] fireInfos)
    {
        // ...
        return true
    }
}
```
