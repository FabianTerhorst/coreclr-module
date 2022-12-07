# MetaChange

This event is called when a meta data from a entity changes.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| entity        | The entity that contains the meta data               |
| key           | The key of the data                                  |
| value         | The value of the data                                |

### Normal event handler

```csharp
Alt.OnMetaDataChange += (entity, key, value) => {
    // ...
}
```

### Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.MetaDataChange)]
    public bool OnMetaDataChange(IEntity entity, string key, object value)
    {
        // ...
    }
}
```
