# Entity factories

Entity factories allows you to optimize your server performance by defining the data you need to store in a player or vehicle on compile time. This allows much faster data access than via .SetData, ```.GetData```.

**NOTE: For gamemodes extending ``Resource``, please read [Entity Factories](entity-factories.md).**

## Step 1, Create the class

Defining your custom player or vehicle class by extending ```AsyncPlayer``` or ```AsyncVehicle```.
You need to implement the default constructor of ```AsyncPlayer``` or ```AsyncVehicle``` as well. 

```csharp
public class MyAsyncPlayer : AsyncPlayer
{
  public bool LoggedIn { get; set; }
  
  public MyAsyncPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
  {
    LoggedIn = false;
  }
}
```

You can't create a player via a constructor, because the player class will be created automatically when someone connects.
Thats why you need to create a factory that will create the player for you when its needed.

## Step 2, Create the factory

In the factory the defined default constructor of the player or vehicle class will be called.
You only need to override the ```IPlayer Create(IntPtr playerPointer, ushort id)``` method and initialize your own class instead of the default one.

```csharp
public class MyAsyncPlayerFactory : IEntityFactory<IPlayer>
{
  public IPlayer Create(ICore core, IntPtr playerPointer, ushort id)
  {
    return new MyAsyncPlayer(core, playerPointer, id);
  }
}
```

## Step 3, Apply the factory

Now you need to tell the module that it should use your own entity factory for the player.
You simply do this by overriding ```IEntityFactory<IPlayer> GetPlayerFactory()``` method in your Resource class.
This will look like the code below.

```csharp
public class SampleResource : AsyncResource {
  public override IEntityFactory<IPlayer> GetPlayerFactory()
  {
      return new MyAsyncPlayerFactory();
  }
}
```

## Vehicle class

It works the same for vehicles, eg:
```csharp
public class MyAsyncVehicle : AsyncVehicle
    {
        public int MyData { get; set; }

        // This constructor is used for creation via entity factory
        public MyAsyncVehicle(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
        {
            MyData = 6;
        }
}
```



## Use the custom Entity class

For events inside IScript class you can just use your own class instead of IPlayer/IVehicle ect.

```csharp
public class SampleScript: IScript {
  [ScriptEvent(ScriptEventType.PlayerConnect)]
  public void MyPlayerConnect(MyAsyncPlayer player, string reason)
  {
   //...
  }
}
```

For events registered via Alt you can just cast the entities to the custom classes.

```csharp
AltAsync.OnPlayerConnect += OnPlayerConnect;
//...
private async Task OnPlayerConnect(IPlayer player, string reason)
{
  var myPlayer = (MyAsyncPlayer)player;
  //...
}
```
