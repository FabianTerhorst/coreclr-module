# Player dead event

This is called when a player dies.

| Parameter | Description  |
|-----------|--------------|
| vehicle   | The vehicle that the player entered |
| player    | The player who is entering a vehicle |
| seat      | The seat where the player entered |

## Normal event handler

```csharp
Alt.OnPlayerEnterVehicle += (vehicle, player, seat) => {
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
        [ScriptEvent(ScriptEventType.PlayerEnterVehicle)]
        public static void OnPlayerEnterVehicle(IVehicle vehicle, IPlayer player, byte seat)
        {
            // Simple output.
            player?.SendChatMessage("Damn " + player.Name + "... you've entered a " + (VehicleModel)vehicle?.Model);
        }
    }
```
