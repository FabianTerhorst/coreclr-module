# Resource communication

This article will describe how to communicate between different server resources.

## Export data

Resources can define data that other resources can access while the resource is starting. This data is immutable after resource finished starting and can be accessed from any serverside resource.

```cs
public class SampleResource : AsyncResource
{
  public override void OnStart()
  {
    var value = "test";
    Alt.Export("myDataKey", value);
  }
}
```

You can export any data you can also send via events. Including: ```object```, ```bool```, ```int```, ```long```, ```uint```, ```ulong```, ```float```, ```double```, ```string```, ```IPlayer``` (or any types extending IPlayer), ```IVehicle``` (or any types extending IVehicle), ```Dictionary<string, (any type listed here)```, ```Alt.Function```, any type listed here as array e.g. int[].
Also any dictionary in dictionary, array in array, ect. endless depth types are supported, because they are resolved recursively.

### Export functions

Functions are also possible to export. Supported function parameters are same types supported by events and exports.

```cs
public class SampleResource : AsyncResource
{
  public override void OnStart()
  {
    Alt.Export("myFunction", new Action<int>(Myfunc));
    
    Alt.Export("myFunction2", new Func<int, bool>(Myfunc2));
  }
  
  public void Myfunc(int myInt)
  {
            
  }
  
  public bool Myfunc2(int myInt)
  {
            
  }
}
```

## Import data

Resources can import data that got exported from other resources. Most likely you will define the resource where you import from as ```deps: [ myResource, myResource2 ]``` in your ```resource.cfg``` to make sure the resource is already started when your resource starts.
You also have to define the resource name where you import data from.

```cs
public class SampleResource : AsyncResource
{
  public override void OnStart()
  {
    Alt.Import("myResourceToImportFrom", "myFunction", out Action<int> myFunction);
    
    myFunction(13);
  }
}
```

This works the same with functions that return data. The return type is always the last generic type in ```Func<...>```.

```cs
public class SampleResource : AsyncResource
{
  public override void OnStart()
  {
    Alt.Import("myResourceToImportFrom", "myFunction2", out Func<int, bool> myFunction);
    
    Console.WriteLine(myFunction(13));
  }
}
```

## Events

Another way to communicate with resources is by sending events to them. The ```Alt.Emit("eventName", values)``` works same as player events and supports all data types that are supported by exports.
Every resource will get notified about the event. You can listen explicit for server events via ```Alt.OnServer("eventName", OnServerEvent)```.
The server event delegate needs to have to following signature.

```cs
public void OnServerEvent(object[] args)
{
}
```


