# PlayerConnect

> [!TIP]
> This event is available on **server-side** only<br>

This event is called when a player connects.

| Parameter     | Description                                         |
| ------------- | --------------------------------------------------- |
| player        | The player that connected.                          |
| reason        | The reason the player connected with.               |

## Normal event handler

```csharp
Alt.OnPlayerConnect += (player, reason) => {
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
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public void OnPlayerConnect(IPlayer player, string reason)
    {
        // ...
    }
}
```
