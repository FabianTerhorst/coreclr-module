
# Entity data

Within the C# API, one has different methods to modify data stored on an entity.

There are, however, four different data access level that can be used.

## `Data` access level

The data access level is only accessible within the resource that attached the data.

### Example

For example:

Given that the used variable `player` is the same across different serverside resources, one has this behaviour of the data:

```csharp
// Resource A
AltV.Net.Entities.IPlayer player;
player.SetData("test", 123);
if (player.GetData<int>("test", out var value)) {
 // value contains 123
}

// Resource B
AltV.Net.Entities.IPlayer player;
if (player.GetData<int>("test", out var value)) {
 // this scope will not be executed at all / value contains nothing/is the default datatype T (int here)
}
```

## `MetaData` access level

The meta data access level is accessible by all serverside resources.

### Example

Given are the same conditions as above.

```csharp
// Resource A
AltV.Net.Entities.IPlayer player;
player.SetMetaData("test", 123);
if (player.GetMetaData<int>("test", out var value)) {
    // value contains 123
}

// Resource B
AltV.Net.Entities.IPlayer player;
if (player.GetMetaData<int>("test", out var value)) {
    // value contains 123
}
```

## Server- and clientside data

### `StreamSyncedMetaData` access level

The stream synced meta data access level is accessible by all serverside resources and all clients within their streaming range.

### `SyncedMetaData` access level

Synced meta data can be accessed by the client and server everytime - meaning across all resources and clients without streaming range limitation.

## Remarks

Obviously, the given access levels above are used to reduce network traffic in the one way and to limit the access from other resources.

Before you use one of those 4 data access levels, think about what you will need as it might drastically improve your performance.

For example, data of a player that is unused by a client, because the target player is out of the streaming range, can be improved by using `StreamSyncedData` data.
