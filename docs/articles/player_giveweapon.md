# GiveWeapon
##### Gives a player a Weapon.
##### Note : Event handler have to be Created in a IScript Class! Otherwise it won´t work.

```csharp
    /* We create our IScript class */
    public class AltV_Wiki : IScript
    {
        /* We declare & Create our Event Handler. */
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(IPlayer player, string reason)
        {
            //We spawn our Connected Client after 1 sec.
            client.Spawn(new Position(0, 0, 72));
            
            // We set his Skin to the standard GTA Online Skin.
            client.Model = Alt.Hash("FreemodeMale01");
            
            // We give our Connected Player a Advanced Rifle with 90 Bullets! He should select his new Weapon Instantly.
            player.GiveWeapon(AltV.Net.Enums.WeaponModel.AdvancedRifle, 90, true);
        }
    }
```
# Syntax
```csharp
  //Parameter : (WeaponModel weaponModel, int ammo, bool selectWeapon)
  player.GiveWeapon(AltV.Net.Enums.WeaponModel.AdvancedRifle, 90, true);
```
