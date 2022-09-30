# Vehicle attach event
The vehicle attach event gets called when a vehicle gets attached to a other vehicle.

| Parameter | Description  |
|-----------|--------------|
| target    | The vehicle that the attachedVehicle got attached to  |
| attachedVehicle    | The vehicle that gets attached |

# Normal event handler

```csharp
Alt.OnVehicleAttach += (target, attachedVehicle) => {
  // ...
}
```

# IScript event handler
```csharp
    // We create our IScript class
    public class MyScriptClass : IScript
    {
        // We declare and create our event handler. 
        [ScriptEvent(ScriptEventType.VehicleAttach)]
        public void OnVehicleAttach(IVehicle target, IVehicle attachedVehicle)
        {
         //...
        }
    }
```
