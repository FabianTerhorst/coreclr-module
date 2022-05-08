# Player entering vehicle event

This is called when a player enters a vehicle.

| Parameter | Description  |
|-----------|--------------|
| vehicle   | The vehicle that the player will enter |
| player    | The player who is entering a vehicle |
| seat      | The seat where the player will enter |

## Normal event handler

```csharp
Alt.OnPlayerEnteringVehicle += (vehicle, player, seat) => {
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
        [ScriptEvent(ScriptEventType.PlayerEnteringVehicle)]
        public void OnPlayerEnteringVehicle(IVehicle vehicle, IPlayer player, byte seat)
        {
            player?.SendChatMessage("Damn " + player.Name + "... you've made it, you are about to enter this awesome " + (VehicleModel)vehicle?.Model);
        }
    }
```
