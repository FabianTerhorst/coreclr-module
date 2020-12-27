## Loop all fast and secure

This article will describe how to loop players, vehicles, ect. fast and secure.

You first have to create a custom class that implements the callback interface.

There are two callback interfaces to implement.

1. ```IAsyncBaseObjectCallback``` which is for calling async code in it.
The callback gets executed inside of an own task and therefore is awaitable.
Use this callback class either when you have to execute asynchronous code inside the loop or when the loop call itself gets executed asynchronously (not in main thread).
The entity object parameter by using this callback class is validated and it is safe to be used outside of the main thread without need of using lock statements.
Remember that you have to inherit your resource class from ```AsyncResource``` (AltAsync package) instead of ```Resource```, otherwise you don't have entity validation.

2. ```IBaseObjectCallback``` is used for none async code.
The loop execution also blocks the execution on the main thread.
You should also not use async code within the callback (or at least lock usage of entities). 

Technically both callbacks, no mather the interface can be called in async code. ```IAsyncBaseObjectCallback``` will result in returning a Task and uses async safe entity references (like ```AsyncPlayerRef``` instead of ```PlayerRef``` when iterating over players).

This example is for IPlayer's but can be used for ```IVehicle```, ```IBlip```, ```ICheckpoint```, ```IColShape``` and ```IVoiceChannel``` as well.

```csharp
class MyPlayerCallback
    : IBaseObjectCallback<IPlayer>
{
    public void OnBaseObject(IPlayer player)
    {
        CheckPlayerPosition(player.Position);
    }
}

class MyPlayerSaveToDBCallback
    : IAsyncBaseObjectCallback<IPlayer>
{
    public async Task OnBaseObject(IPlayer player)
    {
        var dbPlayer = await LoadPlayerFromDb(player.Id);
        await SavePlayer(dbPlayer);
    }
}
```

Now you can create some class instances.

```csharp
var myPlayerCallback = new MyPlayerCallback();

var myPlayerSaveToDBCallback = new MyPlayerSaveToDbCallback();
```

Now you can trigger the OnBaseObject calls inside them.

```csharp
await Alt.ForEachPlayers(myPlayerSaveToDBCallback);
Alt.ForEachPlayers(myPlayerCallback);
```

As you can see the ```ForEachPlayers``` method returns a Task that is done when all OnBaseObject calls that return a Task are done as well.
They are currently called sequently.

Its allowed to reuse the created class instances for as many calls as you want.

Exceptions inside a callback will result into the method to fail and forward the exception to the caller.

### Function / lambda callbacks

Since writing multiple classes for each iteration purpose can be exhausting, you can also use these two generic callback implementations.
With them you can use lambda expressions to define the loop code.
Just keep in mind that using classes is better in performance than using lambda functions (which is probably negligible).

```csharp
public class FunctionCallback<T>
    : IBaseObjectCallback<T>
    where T : IBaseObject
{
    private readonly Action<T> _callback;

    public FunctionCallback(Action<T> callback)
    {
        _callback = callback;
    }

    public void OnBaseObject(T baseObject)
    {
        _callback(baseObject);
    }
}

public class AsyncFunctionCallback<T>
    : IAsyncBaseObjectCallback<T>
    where T : IBaseObject
{
    private readonly Func<T, Task> _callback;

    public AsyncFunctionCallback(Func<T, Task> callback)
    {
        _callback = callback;
    }

    public Task OnBaseObject(T baseObject)
    {
        return _callback(baseObject);
    }
}
```

Usage:
```csharp
var callback = new FunctionCallback<IPlayer>(player => {
    // do something
    Alt.Log(player.Name);
});

Alt.ForEachPlayers(callback);
```

```csharp
var asyncCallback = new AsyncFunctionCallback<IPlayer>(async (player) => {
    // do something
    Alt.Log(player.Name);
    await Task.CompletedTask; // you need at least one await statement in async methods
});

Alt.ForEachPlayers(asyncCallback);
```
