# Resource initialization order

## Why you should know the initialization order

The `Resource` and `AsyncResource` classes provide overridable methods to modify the instantiation of players or vehicles and to modify the pools of those entities - just to name some.

Now, one could need custom parameters while instantiating, for example, a new class inheriting from `IPlayer`, assuming that there exists a player factory (`MyPlayerFactory`) using a custom argument (`myConstant`) in the constructor, which is later on passed to the player class.

```csharp
public override IEntityFactory<IPlayer> GetPlayerFactory()
{
    return new MyPlayerFactory(/* insert your value for myConstant */);
}
```

This could be an example, where a constructor argument is needed. Now, consider the case where your player - and thus your player factory - needs a constructor value which is also used by other components later on in the initialization process.

Then you probably would like to know which initialization order the alt:V follows, to provide the correct instances and values to all of your code.

## Initialization order

The initialization order is as follows:

### 1. Resource constructor

A resource in C# is created by either inheriting from `Resource` or `AsyncResource` on a class and provide overrides for `OnStart()` and `OnStop()`.

The constructor of the class inheriting from `Resource` or `AsyncResource` is called first, which makes sense because the class of the resource has to be instantiated.

### 2. Entity factories and entity pool methods

Second, the entity factory and entity pool methods are called, since before the resource starts, the internal module (of type `Module`) has to know about all factories and pools as they can not be changed later on.

### 3. `GetModule` override

After the creation of entity factories and entity pools, `GetModule` is called with all its arguments.

### 4. `OnStart` override

Nothing much to say about it. The literal start of the resource is about to be begin.

### 5. Intermediate overrides and events

All events known to the public API (`AltV.Net.Alt.On...`) and the method `OnTick(...)` are possible to be called multiple times between `OnStart()` and `OnStop()`, since events can occur multiple times and a tick occurs every few milliseconds.

### 6. `OnStop` override / resource stop OR graceful server shutdown

The last step is the stop of the alt:V server.

Keep in mind that `OnStop` is only called if the resource was stopped manually using the alt:V API or by gracefully stopping the alt:V server. Otherwise, this event **will not be executed**!
