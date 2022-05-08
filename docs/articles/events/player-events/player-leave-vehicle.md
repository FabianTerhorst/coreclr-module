# PlayerLeaveVehicle

> [!TIP]
> This event is available on both **client-side** and **server-side** with **different signatures**.<br>

## Server

This event is called when a player finishes leaving vehicle.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| vehicle       | The vehicle player left                              |
| player        | The player who changed the seat                      |
| seat          | The seat the player left from                        |

### Normal event handler

```csharp
Alt.OnPlayerLeaveVehicle += (vehicle, player, seat) => {
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
    [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
    public void OnPlayerLeaveVehicle(IVehicle vehicle, IPlayer player, uint seat)
    {
        // ...
    }
}
```


## Client


This event is called when current player leaves a vehicle.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| vehicle       | The vehicle player left                              |
| seat          | The seat the player left from                        |


### Normal event handler

```csharp
Alt.OnPlayerLeaveVehicle += (vehicle, seat) => {
    // ...
}
```