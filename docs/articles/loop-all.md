## Loop all fast and secure

This article will describe how to loop players, vehicles, ect. fast and secure.

You first have to create a custom class that implements the callback interface.

There are two callback interfaces to implement.

```IAsyncBaseObjectCallback``` which is for calling async code in it and ```IBaseObjectCallback``` for none async code.

Both callbacks, no mather the interface can be called in async code. ```IAsyncBaseObjectCallback``` will just result in returning a Task.

This example is for IPlayer's but can be used for ```IVehicle```, ```IBlip```, ```ICheckpoint```, ```IColShape``` and ```IVoiceChannel``` as well.

```csharp
class MyPlayerCallback: IBaseObjectCallback<IPlayer>
{
    public void OnBaseObject(IPlayer player) {
        CheckPlayerPosition(player.Position);
    }
}

class MyPlayerSaveToDBCallback: IAsyncBaseObjectCallback<IPlayer>
{
    public async Task OnBaseObject(IPlayer player) {
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
