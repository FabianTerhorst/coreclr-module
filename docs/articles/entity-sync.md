# Entity Sync

This article will describes how to use the entity sync package to sync custom entities from serverside to clients efficiently.

## Setup

Install the following nuget packages and make sure both packages are on the latest version:
https://www.nuget.org/packages/AltV.Net.EntitySync // The core package with the sync logic
https://www.nuget.org/packages/AltV.Net.EntitySync.ServerEvent // A optional package that will send the entity sync events to the client via server events

## Configure the Entity Sync

```csharp
AltEntitySync.Init(1, 100,
   (threadCount, repository) => new ServerEventNetworkLayer(threadCount, repository),
   (entity, threadCount) => (entity.Id % threadCount), 
   (entityId, entityType, threadCount) => (entityId % threadCount),
   (threadId) => new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 300),
   new IdProvider());
```

Now breakdown the parameters of the Init function:

The first parameter is the thread count, this describes the number of thats that will run in parallel to calculate the streamed entities.

The second parameter is the sync rate, it describes the interval in which each sync thread calculates the streamed entities.

The third parameter is the Action that returns a new NetworkLayer for a repository. The ServerEventNetworkLayer is part of the second nuget package.

The fourth parameter defines the thread the entity shoud use.

The fifth parameter defines the thread a entityId + entityType should use.

The sixth parameter is the Action that returns a new space partitioning algorithm for each specific sync thread id. The LimitedGrid3 is one of the algorithms that comes included in the core.
LimitedGrid3 has following parameters: (int maxX, int maxY, int areaSize, int xOffset, int yOffset, int limit).
The (int maxX, int maxY) parameters are defining the size of the map the grid is inserting, removing and finding entities in. The default values are defining the default gta 5 map.
The two offsets (int xOffset, int yOffset) preventing the corrdinates to become negative, because the gta maps goes from -10k to 50k.
The (int limit) makes sure a client can only have streamed in the amount of entities he can actually render. E.g. the gta 5 client in altv can only create around 300 Objects without stability issues.

The seventh and last parameter is the id provider that increments the entity ids incremental and free's unused ids. The IdProvider is included inside the core package as well.

## Add Entities

To add entities that can be streamed there are two ways.

The easiert way is to use the CreateEntity method from AltEntitySync.
```csharp
AltEntitySync.CreateEntity(ulong type, Vector3 position, int dimension, uint range,
            IDictionary<string, object> data);
```
The entity type are your own ids to differentiate between e.g. a object, a ped, a 3d Text, ect.
The position is the entity position.
The dimension is working same as the dimension of a player, vehicle ect.
The range defines the streaming range this entity is streamed in.
The data is the data the entity contains when its streamed in on clientside.

The second way is to use the entity constructor.
```csharp
var entity = new Entity(ulong type, Vector3 position, int dimension, uint range,
            IDictionary<string, object> data);
AltEntitySync.AddEntity(entity);
```

## Remove entities

To remove a entity you just need the entity or the entity id.

```csharp
AltEntitySync.RemoveEntity(IEntity entity);
// or
AltEntitySync.RemoveEntity(ulong id);
```

## Update entity position

The update the position of a entity just use the position setter.
The position is a Vector3.

```csharp
entity.Position = new Vector3(x, y, z);
```


## Update entity range

The update the range of a entity just use the range setter.
The range is a uint and should never be 0.

```csharp
entity.Range = range;
```

## Update entity dimension

The update the dimension of a entity just use the dimension setter.
The dimension is a int.

```csharp
entity.Dimension = dimension;
```

## Update entity data

The update the range of a entity just use the data methods. 
Each type that works with [Custom Events](custom-events.md) also works with ServerEventNetworkLayer.

```csharp
entity.SetData("my-data", 123);
```

You can reset the data with. Resetted data is received as null.
```csharp
entity.ResetData("my-data");
```

## Get entity data

```csharp
if (entity.TryGetData("my-data", out int data)) {

}
```

## ServerEventNetworkLayer

This describes the events the client receives from the ServerEventNetworkLayer that you need to implement in your client code.

### Entity create

This is called every time you come in the range of the entity. 

The server assumes you cache the entity depending on the entity.id so make sure to do it.

```js
alt.onServer("entitySync:create", (entityId, entityType, position, currEntityData) => {
    alt.log(entityId);
    alt.log(entityType);
    alt.log(position);
    alt.log(entityData);
    if (currEntityData) {
      if (!entityData[entityType]) {
         entityData[entityType] = {};
      }
      entityData[entityType][entityId] = currEntityData;
    }
})
```

### Entity remove

This is called every time you go out of the range of the entity.

```js
alt.onServer("entitySync:remove", (entityId, entityType) => {
    let entityData;
    if (entityData[entityType]) {
         entityData = entityData[entityType][entityId];
    } else {
         entityData = null;
    }
    alt.log(entityId);
    alt.log(entityType);
    alt.log(entityData);
})
```

### Entity position update

This is called very time you update the entity position while you are in the range of the entity.

```js
alt.onServer("entitySync:updatePosition", (entityId, entityType, position) => {
    let currEntityData;
    if (entityData[entityType]) {
         currEntityData = entityData[entityType][entityId];
    } else {
         currEntityData = null;
    }
    alt.log(entityId);
    alt.log(entityType);
    alt.log(currEntityData);
})
```


### Entity data update

This is called every time you update the entity data while you are in the range of the entity.

```js
alt.onServer("entitySync:updateData", (entityId, entityType, newEntityData) => {
    if (!entityData[entityType]) {
       entityData[entityType] = {};
    }
    let currEntityData = entityData[entityType][entityId];
    if (!currEntityData) {
         entityData[entityType][entityId] = {};
    }
    for (const key in newEntityData) {
        entityData[entityType][entityId][key] = newEntityData[key];
    }
})
```

### Entity clear cache

This is called every time you remove a entity on serverside completely and clients still have data in cache of this entity.

```js
alt.onServer("entitySync:clearCache", (entityId, entityType) => {
    if (!entityData[entityType]) {
      return;
    }
    delete entityData[entityType][entityId];
})
```

Now you can call your own logic inside the events to spawn objects, npcs, 3d text, markers, ... ect.
