# Explosion

> [!TIP]
> This event is available on **server-side** only<br>

This event is called each time entity enters or leaves a checkpoint.

| Parameter     | Description                                                                                                                                      |
| ------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| player        | Player who caused the explosion.                                                                                                                 |
| explosionType | The type of explosion. See: [ExplosionType](https://github.com/FabianTerhorst/coreclr-module/blob/dev/api/AltV.Net.Shared/Data/ExplosionType.cs) |
| position      | Position of th explosion.                                                                                                                        |
| explosionFx   | Hash of the fx effect of the explosion.                                                                                                          |
| targetEntity  | The entity that was destroyed/hit. (e.g. Vehicle)                                                                                                |

## Normal event handler

```csharp
Alt.OnExplosion += (player, explosionType, position, explosionFx, targetEntity) => {
    // ...
    return true; // false will cancel the event sync
}
```

## Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.Explosion)]
    public void OnExplosion(IPlayer player, ExplosionType explosionType, Position position, uint explosionFx, IEntity targetEntity)
    {
        // ...
    }
}
```
