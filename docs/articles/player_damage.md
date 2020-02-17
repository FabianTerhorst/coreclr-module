# WeaponDamage 
This event will be called if a player do any damage by a Weapon to a other player.
Note : Events have to be created in a IScript Class! Otherwise it won´t work!

```csharp
    //We create our IScript class
    public class AltV_Wiki : IScript
    {
        /* We declare & Create our Event Handler. */
        [ScriptEvent(ScriptEventType.WeaponDamage)]
        public static void WeaponDamage(IPlayer player, IPlayer target, uint weapon, ushort dmg, Position offset, BodyPart bodypart)
        {

            /* If the Target or the Source is Null then */
            if (target != null || player != null)
            {
                return;
            }
            /* We Convert the Weapon uint to a regular WeaponModel Enum. */
            AltV.Net.Enums.WeaponModel weaponModel = (AltV.Net.Enums.WeaponModel)weapon;
            /* We notify the player. */
            player.SendChatMessage("You hitted " + target.Name + " and gave him " + dmg + " damage! Weapon: " + weaponModel);
            target.SendChatMessage(player.Name + " hitted you and gave you " + dmg + " damage! Weapon: " + weaponModel);

            /* We check if the BodyPart is his ***** ... */
            if(bodypart == BodyPart.Pelvis)
            {
                player.SendChatMessage("You hitted a Player in his Balls! Why you did that ?!");
                target.SendChatMessage("You got hitted by a " + weaponModel + " in your Balls :(");
            }
        }
    }
```
