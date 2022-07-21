# Async

> [!WARNING]
> Everything described in this article should be only used after you set up an AsyncResource properly.
> In order to do that make sure to follow "Setup async module" instructions

While writing a C# resource for your server it's quite useful to execute some asynchronous operations (async/await).
For that reasons there's a separated package, that's intended to allow you to work safely in async conditions.

> [!TIP]
> This article only describes **server-side** version of the API.
> Client-side article is WIP yet.

## Setup async module

To be able to use the alt:V async API you have to make several preparations.

1. Add the nuget package [AltV.Net.Async](https://www.nuget.org/packages/AltV.Net.Async/) to your project
2. Your resource inherits from `AsyncResource` instead of `Resource` (`public class MyResource : AsyncResource`)
3. Set on base construct the parameter `forceAsyncBaseObjects` to `true` (`public MyResource(): base(true)`)

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

[AsyncScriptEvent(ScriptEventType.Connect)]
public async Task OnConnectAsync(IPlayer player, string reason) {
    await DoAsyncStuff(player);
}

[AsyncClientEvent("MyClientEventName")]
public async Task OnMyClientEventNameAsync(IPlayer player, string someArgs) {
    await DoAsyncStuff(player, someArgs);
}
```

> [!TIP]
> You can mix AltAsync events with Alt events.
> If you already know your function won't require async operations you can use an Alt event to avoid thread switching.

## API call thread safety

In C# using `await` commonly leads to a thread switch, but there are few APIs that are only safe to call from the main thread.\
To use those APIs safely from any thread you can use a helper function which allows you to call some code on the main thread.

Here's the list of non thread-safe APIs, that should be used with one of the ways below:
* Alt.CreateVehicle
* Alt.CreateBlip
* Alt.CreateCheckpoint

###  AltAsync.Do or AltAsync.RunOnMainThread

Sometimes you want to call multiple non thread-safe APIs in a row.
Doing so using AltAsync versions of the APIs can be quite slow, as those just queue sync API execution to the main thread for next tick.
That's why you can manually execute one function on the main thread, that will do all the non thread-safe stuff that you need in one tick execution.

> [!TIP]
> AltAsync.Do allows you to return some value, while AltAsync.RunOnMainThread doesn't.

Example:

`AltAsync.RunOnMainThread`
```cs
AltAsync.RunOnMainThread(() => {
    foreach (var vehicleHash in hashes) {
        Alt.CreateVehicle(vehicleHash, player.Position, player.Rotation);
    }
});
```

`AltAsync.Do`
```cs
var createdVehicles = await AltAsync.Do(() => {
    var vehicles = new List<IVehicle>();
    foreach (var vehicleHash in hashes) {
        vehicles.Add(Alt.CreateVehicle(vehicleHash, player.Position, player.Rotation));
    }

    return vehicles;
});

foreach(var createdVehicle in createdVehicles){
    Alt.Log($"ID of created vehicle = {createdVehicle.Id}");
}
```

`AltAsync.CreateVehicle`
```cs
var createdVehicle = await AltAsync.CreateVehicle(vehicleHash, player.Position, player.Rotation);
```

# Async entities

With using the base constructor 1st paramter `forceAsyncBaseObjects` all entites are thread safe.

> [!CAUTION]
> So it is important that you do not use `lock`.\
> Using `lock` could lead to a deadlock if the internal thread safe system is used.

Using `.ToAsync` should work, since the correct object is returned internally, but is not required.

### Using safe entities with a custom entity class

This part is only required for those, who have their own entity factories.\
See [Entity Factories](entity-factories.md) for more info.

If you want to create your own async entity class, make sure it extends the class `Async[Blip/Checkpoint/ColShape/Player/Vehicle/VoiceChannel]` and the interface inherits IAsyncConvertible<IMyInterfaceName>. You can check out the [example](https://github.com/FabianTerhorst/coreclr-module/blob/a9e2765fc49fc774ffcdbea67a1baafc489a8009/api/AltV.Net.Example/MyPlayer.cs#L15) how to create a async entity class.

Let's have a look at an example:

```cs
public partial interface IMyPlayer : IPlayer, IAsyncConvertible<IMyPlayer>
{
    public bool IsLoggedIn { get; set; }
}

public partial class MyPlayer : AsyncPlayer, IMyPlayer
{
    public bool IsLoggedIn { get; set; }
    
    public MyPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
    {
    }
    
    public new IMyPlayer ToAsync(IAsyncContext _) => this;
}
```
