# Vehicle destroy event
The vehicle destroy event gets called when a vehicle gets undrivable by e.g. damage or driving into water.

| Parameter | Description  |
|-----------|--------------|
| vehicle    | The vehicle that got undrivable |

# Normal event handler

```csharp
Alt.OnVehicleDestroy += (vehicle) => {
}
```

# IScript event handler
```csharp
    // We create our IScript class
    public class MyScriptClass : IScript
    {
        // We declare and create our event handler. 
        [ScriptEvent(ScriptEventType.VehicleDestroy)]
        public void OnVehicleDestroy(IVehicle vehicle)
        {
            // We loop through every player on our server and notify them
            foreach(IPlayer player in Alt.GetAllPlayers())
            {
                // We notify everyone that our Client has joined the Server
                player.SendChatMessage("Vehicle " + vehicle.Id + " got destroyed.");
            }
        }
        }
    }
```
