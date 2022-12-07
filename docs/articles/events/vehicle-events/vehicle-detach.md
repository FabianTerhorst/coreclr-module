# Vehicle detach event
The vehicle detach event gets called when a vehicle gets detached from a attach.

| Parameter | Description  |
|-----------|--------------|
| vehicle    | The vehicle that got detached |

# Normal event handler

```csharp
Alt.OnVehicleDetach += (vehicle) => {
  // ...
}
```

# IScript event handler
```csharp
    // We create our IScript class
    public class MyScriptClass : IScript
    {
        // We declare and create our event handler. 
        [ScriptEvent(ScriptEventType.VehicleDetach)]
        public void OnVehicleDetach(IVehicle vehicle)
        {
         //...
        }
    }
```
