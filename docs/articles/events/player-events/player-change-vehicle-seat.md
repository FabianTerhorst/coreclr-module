# Player change vehicle seat

This is called when a player enters a vehicle.

| Parameter | Description  |
|-----------|--------------|
| vehicle   | The vehicle the seat change happend in |
| player    | The player who changed the seat |
| oldSeat   | The old seat where the player was on before changing |
| newSeat   | The new seat the player is sitting on |

## Normal event handler

```csharp
Alt.OnPlayerChangeVehicleSeat += (vehicle, player, oldSeat, newSeat) => {
    // ...
}
```

## IScript event handler

##### Note : ScriptEvents have to be created in a IScript Class! Otherwise it won´t work!

```csharp 
    // We create our IScript class
    public class MyScriptClass : IScript
    {
         // We declare and create our event handler
        [ScriptEvent(ScriptEventType.PlayerChangeVehicleSeat)]
        public static void OnPlayerChangeVehicleSeat(IVehicle vehicle, IPlayer player, byte oldSeat, byte newSeat)
        {
            // Simple output.
            player?.SendChatMessage(player.Name + "... you've changed your seat in a " + (VehicleModel)vehicle?.Model + " from " + oldSeat + " to " + newSeat);
        }
    }
```
