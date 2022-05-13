# Vehicle damage event

This is called everytime a vehicle receives damage.

| Parameter | Description  |
|-----------|--------------|
| target    | The vehicle that recieved the damage |
| attacker  | The entity who gave the damage to the vehicle |
| bodyHealthDamage   | The damage dealt to the body of the vehicle |
| additionalBodyHealthDamage   | Additional damage dealt to the body of the vehicle |
| engineHealthDamage   | Damage dealt to the health of the engine |
| petrolTankDamage   | Damage dealt to the health of the petrol tank |
| weapon    | The weapon that was used or a other reason https://github.com/FabianTerhorst/coreclr-module/blob/release/api/AltV.Net/Data/Weapons.cs |

## Normal event handler

```csharp
Alt.OnVehicleDamage += (target, attacker, bodyHealthDamage, additionalBodyHealthDamage, engineHealthDamage, petrolTankDamage, weapon) => {
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
        [ScriptEvent(ScriptEventType.VehicleDamage)]
        public void OnVehicleDamage(IVehicle target, IEntity attacker, uint bodyHealthDamage, uint additionalBodyHealthDamage, uint engineHealthDamage, uint petrolTankDamage,  uint weapon)
        {
            // Simple output.
            target.Driver?.SendChatMessage("Your vehicle recieved damage.");
        }
    }
```
