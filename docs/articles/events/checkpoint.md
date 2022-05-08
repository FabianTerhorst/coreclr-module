# Checkpoint

> [!TIP]
> This event is available on **server-side** only<br>

This event is called each time entity enters or leaves a checkpoint.

| Parameter     | Description                                         |
| ------------- | --------------------------------------------------- |
| checkpoint    | Checkpoint which was entered/leaved.                |
| entity        | Entity which entered/leaved the checkpoint.         |
| state         | True if entity entered colshape, false if left.     |

## Normal event handler

```csharp
Alt.OnCheckpoint += (checkpoint, entity, state) => {
    // ...
}
```

## Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.Checkpoint)]
    public void OnCheckpoint(ICheckpoint checkpoint, IEntity entity, bool state)
    {
        // ...
    }
}
```
