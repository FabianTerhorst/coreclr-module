# CreateVehicle
This is a little example how to use a Weapon-Switch Event.


# First Example
```csharp
using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;

namespace VenoXV.Wiki
{
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        /* We declare & Create our Event Handler. */
        [ScriptEvent(ScriptEventType.PlayerWeaponChange)]
        public bool OnPlayerWeaponChange(IPlayer player, uint oldWeapon, uint newWeapon)
        {
            // We notify the player that he changed his weapon.
            player.SendChatMessage("You changed your Weapon from " + (AltV.Net.Enums.WeaponModel)oldWeapon + " to " + (AltV.Net.Enums.WeaponModel)newWeapon);
            return true; // return false if you wanna cancel it.
        }
    }
}

```


# Second Example
We fill his old Weapon with new Ammo
```csharp
namespace VenoXV.Wiki
{
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        /* We declare & Create our Event Handler. */
        [ScriptEvent(ScriptEventType.PlayerWeaponChange)]
        public bool OnPlayerWeaponChange(IPlayer player, uint oldWeapon, uint newWeapon)
        {
            // We notify the player that he changed his weapon.
            player.GiveWeapon((AltV.Net.Enums.WeaponModel)oldWeapon, 999, false);
            return true; // return false if you wanna cancel it.
        }
    }
}
```


# Third Example
We will cancel the Weapon-Switch. 
```csharp
namespace VenoXV.Wiki
{
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        /* We declare & Create our Event Handler. */
        [ScriptEvent(ScriptEventType.PlayerWeaponChange)]
        public bool OnPlayerWeaponChange(IPlayer player, uint oldWeapon, uint newWeapon)
        {
            player.SendChatMessage("You can't change your Weapon now bro...");
            return false;
        }
    }
}
```

# Usage

```csharp
  //Parameter : (IPlayer player, uint oldWeapon, uint newWeapon)
  public bool OnPlayerWeaponChange(IPlayer player, uint oldWeapon, uint newWeapon)
```
