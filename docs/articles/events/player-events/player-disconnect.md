# PlayerDisconnect

> [!TIP]
> This event is available on both **client-side** and **server-side** with **different signatures**.<br>

## Server

This event is called when a player disconnects.

| Parameter     | Description                                         |
| ------------- | --------------------------------------------------- |
| player        | The player that disconnected.                       |
| reason        | The reason the player disconnected with.            |

### Normal event handler

```csharp
Alt.OnPlayerDisconnect += (player, reason) => {
    // ...
}
```

### Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.PlayerDisconnect)]
    public void OnPlayerDisconnect(IPlayer player, string reason)
    {
        // ...
    }
}
```


## Client


This event is called when current player disconnects.

> [!TIP]
> This event has no arguments.<br>

### Normal event handler

```csharp
Alt.OnPlayerDisconnect += () => {
    // ...
}
```
