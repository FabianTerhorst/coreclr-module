# Async

> [!TIP]
> This article only describes **server-side** version of the API.<br>
> Client-side article is WIP yet

While writing a C# resource for your server it's quite useful to execute some asynchronous things (async/await).
For that reasons there's a separated module, that's intended to allow you to work safely in async conditions.

> [!WARNING]
> Everything described in this article should be only used after you set up an AsyncResource properly.<br>
> In order to do that make sure to follow "Setup async module" instructions

## Setup async module

To be able to use alt:V async api you have to make several preparations.

1. Download the nuget package [AltV.Net.Async](https://www.nuget.org/packages/AltV.Net.Async/)
2. Make sure your resource inherits from `AsyncResource` instead of `Resource` (`public class MyResource : AsyncResource`)

## Async event handlers

You can register a async event handler when using AltAsync instead of Alt for registering event handlers like

```cs
AltAsync.OnPlayerConnect += async (player, reason) => {
    Console.WriteLine($"{player.Name} connected.");
    await DoAsyncStuff(player);
};

AltAsync.OnClient<IPlayer, string, Task>("ShowMessage", async (player, message) => {
    await VerifyPlayerLogin(player);
    Console.WriteLine("Message from player: " + message);
});
```

## API call thread safety

In C# using `await` commonly leads to a thread switch, but there are few APIs, that are only safe to call from the main thread.<br>
To use those APIs safely from any thread you can use the special safe API version from AltAsync class, or use a helper functions, that allow you to call some code on the main thread.

Here's the list of non thread-safe APIs, that should be used with one of the ways below:
* Alt.CreateVehicle
* Alt.CreateBlip
* Alt.CreateCheckpoint

### First way - AltAsync methods

In order to use methods like that, you just need to use methods with the same name from AltAsync class, adding an await to them.
Example:
```cs
var vehicle = await AltAsync.CreateVehicle(vehicleHash, player.Position, player.Rotation)
```

### Second way - AltAsync.Do or AltAsync.RunOnMainThread

Sometimes you want to call multiple non thread-safe APIs in a row.
Doing so using AltAsync versions of the APIs can be quite slow, as those just queue sync API execution to the main thread for next tick.
That's why you can manually execute one function on the main thread, that will do all the non thread-safe stuff that you need in one tcick execution.

Example:
```cs
await AltAsync.RunOnMainThread(() => {
    foreach (var vehicleHash in hashes) {
        Alt.CreateVehicle(vehicleHash, player.Position, player.Rotation);
    }
});
```

AltAsync.Do allows you to return some value, while AltAsync.RunOnMainThread doesn't.

# Async entities

Currently in C# module calling any API on a deleted entity (e.g. disconnected player) in async context can cause some issues.
Mostly, in that cases server can stop with 139 exit code, but that behaviour can be quite random.
In order to avoid those situations there are multiple ways to go.

## First way - locking an entity

In order to use APIs by locking the entity, you need to lock the entity and check if it does exist inside of the lock body.<br>
That way you will prevent the entity from deletion until you finish your tasks.

Here's an example:

```cs
lock (player) {
    if (player.Exists) {
        player.Position = new Vector3(0, 0, 70);
        Alt.Log(player.Rotation.ToString());
    }
}
```

Let's breakdown this example line-by-line:

```cs
lock (player) {
```
This line enters a block, that prevents the C# module to delete the player on disconnect.
Lock statement will unlock the entity after leaving the block, so make sure to not use any long-executing stuff like Thread.Sleep in there.


> [!WARNING]
> Note: locking the player when its already locked will end up in a deadlock. Never do this.<br>
> Example of bad code:
> ```cs
> lock (player) { lock (player) {  } }
> ```
> <br>
> Locks also work accross method calls so be careful.


```cs
if (player.Exists) {
```
This line checks if player does still exist, if it doesn't then we don't do anything.

```cs
player.Position = new Vector3(0, 0, 70);
```
With this line we set the player position to a (0, 0, 70).

```cs
Alt.Log(player.Rotation.ToString());
```
With this line we log player's rotation to a console.

## Second way - using async (safe) entities

> [!TIP]
> This way requires you to have Async module set up. See [Async](async.md) for more info.

In order to get your async (safe) version of an entity, you need to call a ToAsync() method on it.

Here's a small example:
```cs
var asyncPlayer = player.ToAsync();
asyncPlayer.Position = new Vector3(0, 0, 70);
Alt.Log(asyncPlayer.Rotation.ToString());
```

If the player does not exist, any call to any method will do nothing, and any getter will return default type value.<br>
For instance, the example above will set player's position to (0, 0, 70) and log out the player's rotation if the player is still connected.
But if the player did disconnect already, the Position setter won't do anything, and (0, 0, 0) vector will be logged to the console.

### Using safe entities with a custom entity class

This part is only required for those, who have their own entity factories. See [Entity Factories](entity-factories.md) for more info.

If you want to call your own methods, work with your own getters on an async entity, you need to set up an async class for the entity, and extend `IAsyncConvertible<IYourInterface>`.
If you want to make one manually, you can check out the [example](https://github.com/FabianTerhorst/coreclr-module/blob/e681349d3452765ae6b6cf053ff14c3b5e8dc019/api/AltV.Net.Example/MyPlayer.cs#L15), but we recommend you to make it automatically.<br><br>
In order to make async class automatically you need:

1. Download the nuget package [AltV.Net.Async.CodeGen](https://www.nuget.org/packages/AltV.Net.Async.CodeGen/)
2. Create an interface for your class
3. Make sure both class and interface have the `partial` modifier
4. Make sure the class has the attribute `[AsyncEntity(typeof(IYourInterface))]`


Let's have a look at an example:

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