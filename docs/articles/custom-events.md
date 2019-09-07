# Custom events

Custom events are automatically validating the arguments the client send via a client event. Everything that is possible with custom events can also be created via ```Alt.OnPlayerEvent```.

Custom events are registered via ```Alt.On(eventName, delegate)```. The delegate can have any signature and the module checks when a event occurs if the signature of the delegate fits the event arguments the client sends.

For custom events you can't use the lambda operator because it needs to know the parameter types.

Here is a very basic sample that expects just a single ```string``` from a client event named ```myMessage```.

We register it via ```Alt.On```. We need to help the compiler a bit by defining the method parameter types for the generic method. The types are defined from left ro right same as in the method definition itself.

```csharp
Alt.On<IPlayer, string>("myMessage", MyMessageHandler);
```

And the method is defined as this.
```csharp
public void MyMessageHandler(IPlayer player, string message)
{            
}
```

The method will be called like this from client
```js
alt.emitServer("myMessage", "my test message").
```

The method name doesn't really matter in this case and i just named it similar to the event name.

Supported parameter types are ```object```, ```bool```, ```int```, ```long```, ```uint```, ```ulong```, ```float```, ```double```, ```string```, ```IPlayer``` (or any types extending IPlayer), ```IVehicle``` (or any types extending IVehicle), ```Dictionary<string, (any type listed here)```, ```Alt.Function```, any type listed here as array e.g. int[].
Also any dictionary in dictionary, array in array, ect. endless depth types are supported, because they are resolved recursively.

## Dictionaries

Any js object send via ```alt.emitServer``` will be a dictionary.

```csharp
Alt.On<IPlayer, string>("myBigObject", MyBigObjectHandler);
...
public void MyBigObjectHandler(IPlayer player, Dictionary<string, string> myBigObject)
{            
  if(!myBigObject.TryGetValue("eyeColor", out var eyeColor)) return;
  Console.WriteLine($"EyeColor: {eyeColor}");
}
```
And this is the client code.
```js
const myBigObject = {firstName:"John", lastName:"Doe", eyeColor:"blue"};
alt.emitServer("myBigObject", myBigObject);
```

When you use ```object``` as a parameter, or type in dictionary, it will accept any type and you can manually check which type it is.
