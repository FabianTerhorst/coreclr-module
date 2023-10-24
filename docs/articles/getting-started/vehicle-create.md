# CreateVehicle
This is a little example how to create Vehicles Serverside in C#.
**You need to add the reference to the NuGet Package __AltV.Net.Resources.Chat.Api__**

# First Example
This example will spawn a Adder near you after you died!
```csharp
/* We create our IScript class */
public class AltV_Wiki : IScript
{
    /* We declare & Create our Event Handler. */
    [ScriptEvent(ScriptEventType.PlayerDead)]
    public static void OnPlayerDeath(IPlayer player, IPlayer killer, uint reason)
    {
        //We spawn the dead Player
        player.Spawn(new Position(0, 0, 72));
        //We Create a Adder near the local player.
        IVehicle veh = Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Adder, new Position(player.Position.X, player.Position.Y + 1.5f, player.Position.Z), player.Rotation);
        //We notify the Client.
        player.SendChatMessage("You just respawned! Enjoy your Adder.");
    }
}
```
# Second Example
This example shows you how to Create a Command, that spawns a Vehicle.

```csharp
/* We create our IScript class */
public class AltV_Wiki : IScript
{
    [Command("createvehicle")]
    public static void CreateVehicle(IPlayer player, string VehicleName, int R = 0, int G = 0, int B = 0){
        IVehicle veh = Alt.CreateVehicle(Alt.Hash(VehicleName), new Position(player.Position.X, player.Position.Y + 1.5f, player.Position.Z), player.Rotation);
        //If the Vehicle Creation was successfull, then it should notify you.
        if (veh != null) { player.SendChatMessage("You just Created a " + VehicleName); }
    }
}
```

# Usage

```csharp
  //Parameter : (uint model, Position pos, Rotation rotation)
  Alt.CreateVehicle(AltV.Net.Enums.VehicleModel.Adder, new Position(0, 0, 0), new Rotation(0,0,0));
```
