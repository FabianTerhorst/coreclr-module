# NetOwnerChange

## Server

This event is called when a player becomes net owner of a entity. The entity can be a player or vehicle. But normally its a vehicle.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| entity        | The entity that has a changed net owner              |
| oldNetOwner   | The player that was the net owner of the entity      |
| newNetOwner   | The player that is now the net owner of the entity   |

### Normal event handler

```csharp
Alt.OnNetOwnerChange += (entity, oldNetOwner, newNetOwner) => {
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
    [ScriptEvent(ScriptEventType.StartProjectile)]
    public void OnNetOwnerChange(IEntity entity, IPlayer oldNetOwner, IPlayer newNetOwner)
    {
        // ...
    }
}
```
