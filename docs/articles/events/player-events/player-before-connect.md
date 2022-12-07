# PlayerBeforeConnect

> [!TIP]
> This event is available on **server-side** only<br>

This event is called before a player is connected.
You can cancel the connection by returning a string (cancel message), and allow by returning a null;

| Parameter      | Description                                         |
| -------------- | --------------------------------------------------- |
| connectionInfo | The player that connected.                          |
| reason         | The reason the player connected with.               |

## Normal event handler

```csharp
Alt.OnPlayerBeforeConnect += (player, reason) => {
    // ...
    // null to allow the connection
    return null;
}
```

## Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.PlayerBeforeConnect)]
    public string OnPlayerBeforeConnect(PlayerConnectionInfo connectionInfo, string reason)
    {
        // ...
        // null to allow the connection
        return null;
    }
}
```
