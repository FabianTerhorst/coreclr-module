# AnyResourceError

> [!TIP]
> This event is available on both **client-side** and **server-side**<br>

This event is called when an error happens in any resource.

| Parameter      | Description                                         |
| -------------- | --------------------------------------------------- |
| resource       | The resource that errored.                          |

## Normal event handler

```csharp
Alt.OnAnyResourceError += (resource) => {
    // ...
}
```