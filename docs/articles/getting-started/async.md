# Async Module

This article will talk about how to use alt:Vs functions thread safe. 
All techniques described in this article will only work when you extend AsyncResource.

## Setup async module

To be able to use alt:V async api you have to make several preparations.

1. Download the nuget package [AltV.Net.Async](https://www.nuget.org/packages/AltV.Net.Async/)
2. Make sure your resource inherits from `AsyncResource` instead of `Resource`

## Async event handlers

You can register a async event handler when using AltAsync instead of Alt for registering event handlers like

```cs
AltAsync.OnPlayerConnect += async (player, reason) => {
    Console.WriteLine($"{player.Name} connected.");
    await DoAsyncStuff(player);
};

AltAsync.OnClient<IPlayer, string>("ShowMessage", async (player, message) => {
    await VerifyPlayerLogin(player);
    Console.WriteLine("Message from player: " + message);
});
```

## Use apis thread safe

All api's related to entities like Player, Vehicle, Blip, ColShape, Checkpoint, VoiceChannel are not thread safe and will make your server crash when used wrong in async code.

### How to use most apis thread safe without performance loose?

You can get the position of a player in async code by preventing the player entity to get deleted while accessing the position.
This doesn't work with all apis

Small example:

```cs
Position position;
lock (player) {
  if (player.Exists) {
    position = player.Position
  }
}
Console.WriteLine("X:" + position.X);
```

Lets breakdown the small code snippet.

```cs
Position position;
```
We create a value to save the position into;
```cs
lock (player)
```
We lock the player to prevent access to it from multiple c# threads at the same time. 
This also prevents the c# module to delete the player on disconnect. 
Otherwise the server would end up crashing by accessing the player position of a deleted entity.
Note: locking the player when its already locked will end up in a deadlock. Never do this E.g. ```lock (player) { lock (player) {  } }```
Locks also work accross method calls so be careful.
```cs
if (player.Exists) {
```
This if check is optional, because not checking it won't crash the server, but will throw a exception when the player doesn't exist anymore.
```cs
position = player.Position
```
Here we assign the position to the value we declared above. This is essential because no heavy calculations should happen inside a lock statement and the assign makes it possible to use the player position outside the lock statement for e.g. distance calculations.

### How to use all apis thread safe

A few apis aren't possible to use thread safe from a different thread.
To use those apis we have to execute them on main thread. To make this easy for developers AltAsync has a method to do just this.

Lets have a look at a example snippet:

```cs
private async void CreatePersonalVehicle(IPlayer player, uint vehicleHash) {
    var vehicle = await AltAsync.Do(() => Alt.CreateVehicle(vehicleHash, player.Position, player.Rotation));
    
    var asyncPlayer = player.ToAsync();
    var asyncVehicle = vehicle.ToAsync();
    asyncVehicle.NumberPlateText = asyncPlayer.Name[..8];
    asyncVehicle.SetMod((byte) VehicleModType.Turbo, 1);
    asyncPlayer.SetIntoVehicle(asyncVehicle, 1);
}
```

> [!WARNING]
> This example only works when called inside a method that is declared async.
> AltAsync.Do will execute any code inside of it on the main thread. And will return the result when its awaited. You can also use AltAsync.Do when you don't care about the result and about the execution order.
> When you need to call multiple apis at once don't do multiple AltAsync.Do when possible. Otherwise it may create a overhead on the main thread.

Lets have another breakdown of the example snippet:

```cs
var vehicle = await AltAsync.Do(() => Alt.CreateVehicle(vehicleHash, player.Position, player.Rotation));
```
As we need to create the vehicle on the main thread we use AltAsync.Do to execute the code on the main thread.

```cs
var asyncPlayer = player.ToAsync();
var asyncVehicle = vehicle.ToAsync();
```
We create two async objects from the player and vehicle to make it possible to use the apis on the main thread.

```cs
asyncVehicle.NumberPlateText = asyncPlayer.Name[..8];
asyncVehicle.SetMod((byte) VehicleModType.Turbo, 1);
asyncPlayer.SetIntoVehicle(asyncVehicle, 1)
```
As long as we're using the just created async objects we are able to use the normal alt:V api without having to worry about it executing on the right thread.

## Use custom properties and functions from the entity factory

To able to use our custom properties and functions from classes which have been converted by ToAsync() we have to take some preparations:

1. Download the nuget package [AltV.Net.Async.CodeGen](https://www.nuget.org/packages/AltV.Net.Async.CodeGen/)
2. Create an interface for your class
3. Make sure both class and interface have the `partial` modifier
4. Make sure the class has the attribute `[AsyncEntity(typeof(IYourInterface))]`

Lets have a look at an example:

```cs
public partial interface IMyPlayer : IPlayer
{
    public bool IsLoggedIn { get; set; }
}

[AsyncEntity(typeof(IMyPlayer))]
public partial class MyPlayer : Player, IMyPlayer
{
    public bool IsLoggedIn { get; set; }
    
    public MyPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
    {
    }
}
```

With having the partial class & interface combined with the AsyncEntity attribute the ToAsync() will return your interface, giving you the possibilites to use all your custom properties & functions.

## Threadsafe methods from `AltV.Net.Alt`

### Entity pools

The `AltV.Net.Async.AltAsync` class does not provide methods to interact with entity pools/lists. If you are using an `AsyncResource`, the methods for entity pooling on `AltV.Net.Alt` are overwritten and are threadsafe to use. This includes the following methods:

```cs
public override IBaseEntityPool GetBaseEntityPool(IEntityPool<IPlayer> playerPool, IEntityPool<IVehicle> vehiclePool);
public override IBaseObjectPool<IBlip> GetBlipPool(IBaseObjectFactory<IBlip> blipFactory);
public override IBaseObjectPool<ICheckpoint> GetCheckpointPool(IBaseObjectFactory<ICheckpoint> checkpointFactory);
public override IBaseObjectPool<IColShape> GetColShapePool(IBaseObjectFactory<IColShape> colShapeFactory);
public override IEntityPool<IPlayer> GetPlayerPool(IEntityFactory<IPlayer> playerFactory);
public override IEntityPool<IVehicle> GetVehiclePool(IEntityFactory<IVehicle> vehicleFactory);
public override IBaseObjectPool<IVoiceChannel> GetVoiceChannelPool(IBaseObjectFactory<IVoiceChannel> voiceChannelFactory);
```

as they are overwritten in the `AsyncResource` class.

