# PlayerEnteringVehicle

> [!TIP]
> This event is available on **server-side** onlyt.<br>

This event is called when a player starts entering vehicle.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| vehicle       | The vehicle player entering                          |
| player        | The player who changed the seat                      |
| seat          | The seat where the player entered                    |

## Normal event handler

```csharp
Alt.OnPlayerEnteringVehicle += (vehicle, player, seat) => {
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
    [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
    public void OnPlayerEnteringVehicle(IVehicle vehicle, IPlayer player, uint seat)
    {
        // ...
    }
}
```