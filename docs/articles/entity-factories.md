# Entity factories

Entity factories allows you to optimize your server performance by defining the data you need to store in a player or vehicle on compile time. This allows much faster data access than via .SetData, ```.GetData```.

## Step 1, Create the class

Defining your custom player or vehicle class by extending ```Player``` or ```Vehicle```.
You need to implement the default constructor of ```Player``` or ```Vehicle``` as well. 

```csharp
public class MyPlayer : Player
{
  public bool LoggedIn { get; set; }
  
  public MyPlayer(IntPtr nativePointer, ushort id) : base(nativePointer, id)
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
public class MyPlayerFactory : IEntityFactory<IPlayer>
{
  public IPlayer Create(IntPtr playerPointer, ushort id)
  {
    return new MyPlayer(playerPointer, id);
  }
}
```

## Step 3, Apply the factory

Now you need to tell the module that it should use your own entity factory for the player.
You simply do this by overriding ```IEntityFactory<IPlayer> GetPlayerFactory()``` method in your Resource class.
This will look like the code below.

```csharp
public class SampleResource : Resource {
  public override IEntityFactory<IPlayer> GetPlayerFactory()
  {
      return new MyPlayerFactory();
  }
}
```

This also works when you extend ```AsyncResource``` ect.

## Vehicle class

It works the same for vehicles, but with a small difference, because you can create vehicles via the constructor by defining the vehicle model, position and rotation.

Thats why you most likely will add a second constructor to the vehicle that looks like this.

```csharp
public class MyVehicle : Vehicle
    {
        public int MyData { get; set; }

        // This constructor is used for creation via constructor
        public MyVehicle(uint model, Position position, Rotation rotation) : base(model, position, rotation)
        {
            MyData = 7;
        }

        // This constructor is used for creation via entity factory
        public MyVehicle(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            MyData = 6;
        }
}
```
