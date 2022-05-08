# AnyResourceStart

> [!TIP]
> This event is available on both **client-side** and **server-side**<br>

This event is called when any resource starts.

| Parameter      | Description                                         |
| -------------- | --------------------------------------------------- |
| resource       | The resource that started.                          |

## Normal event handler

```csharp
Alt.OnAnyResourceStart += (resource) => {
    // ...
}
```