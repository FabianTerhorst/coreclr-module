# Events

For custom events see [Custom Events](https://fabianterhorst.github.io/coreclr-module/articles/custom-events.html).

Events can be registered via [scripts](https://fabianterhorst.github.io/coreclr-module/articles/create-script.html) or dynamically via event delegates.
This documentation is registering events via delegates dynamically.

To add for example a player connect event handler dynamically you can just add the delegate that will be called when a player connects.

This is a example using the lambda operator to add a event handler.

```csharp
Alt.OnPlayerConnect += (player, reason) => {
  Console.WriteLine($"{player.Name} connected.");
};
```

Its also possible to add a method instead of using a lambda. The method can be private, public, static ect.

```csharp
Alt.OnPlayerConnect += OnPlayerConnect;
...
public void OnPlayerConnect(IPlayer player, string reason)
{
  Console.WriteLine($"{player.Name} connected.");
}
```

You should not register event handlers in async code.

Below is a list of all event handlers.

[!code-csharp[Events](../../api/AltV.Net/Alt.Events.cs)]

Below is a list of all event handler method signatures.

[!code-csharp[Events](../../api/AltV.Net/Events/Events.cs)]

The player event handler looks like this.

```csharp
Alt.OnPlayerEvent += (player, name, args) => { 
};
```

For automated arguments validating you can use [Custom Events](https://fabianterhorst.github.io/coreclr-module/articles/custom-events.html).
