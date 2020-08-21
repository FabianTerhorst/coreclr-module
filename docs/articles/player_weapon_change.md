# PlayerWeaponChange
The player weapon change event gets called when the player weapon changed.

| Parameter | Description  |
|-----------|--------------|
| player    | The player that got his weapons changed |
| oldweapon | The weapon that was used https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Enums/WeaponModel.cs |
| newWeapon | The weapon that was used https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Enums/WeaponModel.cs |

# Normal event handler

```csharp
Alt.OnPlayerWeaponChange += (player, oldWeapon, newWeapon) => {
   return true; // return false if you wanna cancel it.
}
```

# IScript event handler
```csharp
    // We create our IScript class
    public class MyScriptClass : IScript
    {
        // We declare and create our event handler. 
        [ScriptEvent(ScriptEventType.PlayerWeaponChange)]
        public bool OnPlayerWeaponChange(IPlayer player, uint oldWeapon, uint newWeapon)
        {
            // We notify the player that he changed his weapon.
            player.SendChatMessage("You changed your Weapon from " + (AltV.Net.Enums.WeaponModel)oldWeapon + " to " + (AltV.Net.Enums.WeaponModel)newWeapon);
            return true; // return false if you wanna cancel it.
        }
    }
```
