# PlayerChangeVehicleSeat

> [!TIP]
> This event is available on both **client-side** and **server-side** with **different signatures**.<br>

## Server

This event is called when a player changes vehicle seat.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| vehicle       | The vehicle the seat change happened in              |
| player        | The player who changed the seat                      |
| oldSeat       | The old seat where the player was on before changing |
| newSeat       | The new seat the player is sitting on                |

### Normal event handler

```csharp
Alt.OnPlayerChangeVehicleSeat += (vehicle, player, oldSeat, newSeat) => {
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
    [ScriptEvent(ScriptEventType.PlayerChangeVehicleSeat)]
    public void OnPlayerChangeVehicleSeat(IVehicle vehicle, IPlayer player, uint oldSeat, uint newSeat)
    {
        // ...
    }
}
```


## Client


This event is called when current player changes vehicle seat.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| vehicle       | The vehicle the seat change happened in              |
| oldSeat       | The old seat where the player was on before changing |
| newSeat       | The new seat the player is sitting on                |


### Normal event handler

```csharp
Alt.OnPlayerChangeVehicleSeat += (vehicle, oldSeat, newSeat) => {
    // ...
}
```