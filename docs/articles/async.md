# Async Module

This article will talk about how to use altv's thread safe. 
All techniques described in this article will only work when you extend AsyncResource.

## Setup async module

First download the nuget package to access the async api's. https://www.nuget.org/packages/AltV.Net.Async
Next you need to inherit from ```AsyncResource``` instead of ```Resource```. 
Now you can use the async module.

## Async event handlers

You can register a async event handler when using AltAsync instead of Alt for registering event handlers like

```csharp
AltAsync.OnPlayerConnect += async (player, reason) => {
  Console.WriteLine($"{player.Name} connected.");
  await DoAsyncStuff(player);
};
```

## Use apis thread safe

All api's related to entities like Player, Vehicle, Blip, ColShape, Checkpoint, VoiceChannel are not thread safe and will make your server crash when used wrong in async code.

### How to use most apis thread safe without performance loose?

You can get the position of a player in async code by preventing the player entity to get deleted while accessing the position.
This doesn't work with all apis

Small example:

```csharp
Position position;
lock (player) {
  if (player.Exists) {
    position = player.Position
  }
}
Console.WriteLine("X:" + position.X);
```

Lets breakdown the small code snippet.

```Position position;```
We create a value to save the position into;
```lock (player)```
We lock the player to prevent access to it from multiple c# threads at the same time. 
This also prevents the c# module to delete the player on disconnect. 
Otherwise the server would end up crashing by accessing the player position of a deleted entity.
Note: locking the player when its already locked will end up in a deadlock. Never do this E.g. ```lock (player) { lock (player) {  } }```
Locks also work accross method calls so be careful.
```if (player.Exists) {```
This if check is optional, because not checking it won't crash the server, but will throw a exception when the player doesn't esists anymore.
```position = player.Position```
Here we assign the position to the value we declared above. This is essential because no heavy calculations should happen inside a lock statement and the assign makes it possible to use the player position outside the lock statement for e.g. distance calculatione.

### How to use all apis thread safe

A few apis aren't possible to use thread safe from a different thread.
To use those apis we have to execute them on main thread. To make this easy for serverdev AltAsync has a method to do just this.

Here is a example.

```csharp
var vehicle = await AltAsync.Do(() => Alt.CreateVehicle(VehicleModel.T20, player.Position, player.Rotation));
```

This example only works when called inside a method that is declared async.
AltAsync.Do will execute any code inside of it on the main thread. And will return the result when its awaited. You can also use AltAsync.Do when you don't care about the result and about the execution order.

When you need to call multiple apis at once don't do multiple AltAsync.Do when possible. Otherwise it may create a overhead on the main thread.

```csharp
var vehicle = await AltAsync.Do(() => {
  var vehicle = Alt.CreateVehicle(VehicleModel.T20, player.Position, player.Rotation);
  var vehicle2 = Alt.CreateVehicle(VehicleModel.Chimera, player.Position, player.Rotation);
});
```
