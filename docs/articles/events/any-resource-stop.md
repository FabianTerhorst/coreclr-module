# AnyResourceStop

> [!TIP]
> This event is available on both **client-side** and **server-side**<br>

This event is called when any resource stops.

| Parameter      | Description                                         |
| -------------- | --------------------------------------------------- |
| resource       | The resource that stopped.                          |

## Normal event handler

```csharp
Alt.OnAnyResourceStop += (resource) => {
    // ...
}
```