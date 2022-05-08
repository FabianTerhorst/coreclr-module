# PlayerEnterVehicle

> [!TIP]
> This event is available on both **client-side** and **server-side** with **different signatures**.<br>

## Server

This event is called when a player finishes entering vehicle.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| vehicle       | The vehicle player entered                           |
| player        | The player who entered the vehicle                   |
| seat          | The seat where the player entered                    |

### Normal event handler

```csharp
Alt.OnPlayerEnterVehicle += (vehicle, player, seat) => {
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
    [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
    public void OnPlayerEnterVehicle(IVehicle vehicle, IPlayer player, uint seat)
    {
        // ...
    }
}
```


## Client


This event is called when current player enters a vehicle.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| vehicle       | The vehicle player entered                           |
| seat          | The seat where the player entered                    |


### Normal event handler

```csharp
Alt.OnPlayerEnterVehicle += (vehicle, seat) => {
    // ...
}
```