# Create Script

Make sure you have [created a resource](https://fabianterhorst.github.io/coreclr-module/articles/create-resource.html) before.

Classes that extend IScript are getting auto initiaized.

MyScript.cs
```cs
using System;

namespace My.Package
{
    public class MyScript : IScript
    {
    }
}
```

Scripts can register event handlers via method attributes.

For adding a player connect handler. The method name doesn't matter for script events.

```cs
[ScriptEvent(ScriptEventType.PlayerConnect)]
public void PlayerConnect(IPlayer player, string reason)
{
  player.SetDateTime(DateTime.Now);
  player.Model = (uint) PedModel.FreemodeMale01;
}
```

For adding a custom event handler. The method name is used as a event name when its not defined in the attribute.

```cs
// Here the event name is 'MyEventName' and the event handler receives server events
[ServerEvent("MyEventName")]
public static void MyEventName2(string message)
{
  Console.WriteLine(message);
}

// Here the event name is 'MyCustomEvent' and the event handler receives server events
[ServerEvent]
public static void MyCustomEvent(string message)
{
  Console.WriteLine(message);
}

// Here the event name is 'MyClientEventName' and the event handler receives client events
[ClientEvent("MyClientEventName")]
public static void MyClientEventName2(string message)
{
  Console.WriteLine(message);
}

// Here the event name is 'MyClientCustomEvent' and the event handler receives client events
[ClientEvent]
public static void MyClientCustomEvent(string message)
{
  Console.WriteLine(message);
}
```

The ScriptEvent method signatures are the same as the signatures used when registering the events via Alt.OnPlayerConnect ect.

