# Player leave vehicle event

This is called when a player leaves a vehicle.

| Parameter | Description  |
|-----------|--------------|
| vehicle   | The vehicle that the player left |
| player    | The player who is leaving his current vehicle |
| seat      | The seat where the player left |

## Normal event handler

```csharp
Alt.OnPlayerLeaveVehicle += (vehicle, player, seat) => {
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
        [ScriptEvent(ScriptEventType.PlayerLeaveVehicle)]
        public static void OnPlayerLeaveVehicle(IVehicle vehicle, IPlayer player, byte seat)
        {
            // Simple output.
            player?.SendChatMessage("Damn " + player.Name + "... you've left your awesome " + (VehicleModel)vehicle?.Model);
        }
    }
```
