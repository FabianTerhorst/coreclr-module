# Explosion

This is called every time something explodes.

| Parameter     | Description                                                                                                                                   |
| ------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| player        | The player that triggered/made the explosion.                                                                                                 |
| explosionType | The type of the explosion, for more information: https://github.com/FabianTerhorst/coreclr-module/blob/dev/api/AltV.Net.Shared/Enums/ExplosionType.cs |
| position      | The position the explosion is located at.                                                                                                     |
| explosionFx   | The fx effect of the explosion.                                                                                                               |
| targetEntity  | The entity which was destroyed/hit (e.g. Vehicle).                                                                                            |

## Normal event handler

```csharp
Alt.Explosion += (player, explosionType, position, explosionFx, targetEntity) => {
    // ...
    return true; // return false will cancel the event.
}
```

## IScript event handler

This is called every time something explodes.

##### Note : ScriptEvents have to be created in a IScript Class! Otherwise it won´t work!

```csharp
// We create our IScript class
public class MyScriptClass : IScript
{
    // We declare and create our event handler
    [ScriptEvent(ScriptEventType.Explosion)]
        public bool Explosion(IPlayer player, ExplosionType explosionType, Position position, uint explosionFx, IEntity targetEntity)
        {
            switch (targetEntity)
            {
                case IPlayer target:
                    Alt.Log(player.Name + " brutally blew up {target.Name}.");
                    return false; // <= return false will cancel the event.
                case IVehicle veh:
                    Alt.Log(player.Name + " brutally blew up a " + (VehicleModel)veh.Model + ". The explosion type was " + explosionType + ".");
                    return true;
            }

            Alt.Log("Something blew up.");
        }
}
```
