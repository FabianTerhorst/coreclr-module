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