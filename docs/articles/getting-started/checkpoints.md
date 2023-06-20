# Introduction
Checkpoints are very similiar to Colshapes. The main difference is that Checkpoints are displayed on clients (e.g. as arrow), while colshapes are invisible and designed for detecting collisions. Important to know is that the internal streaming of checkpoints is not optimized and you should use them as less as possible.

With checkpoints you are able to detect appearing or disappearing entities of an area, specified by position, radius and height.
The specified checkpoint type defines the shape of the checkpoint (there are 3 shapes available: Cylinder, Rings, Arrows). Typical usages of checkpoints are parkour racings or driving/flying tutorials.

alt:V offers full API support for creating Checkpoints on serverside.

# API
## Methods

Method | Description
-------|------------
Alt.CreateCheckpoint | Creates a new checkpoint
Alt.ForEachCheckpoint | Iterates through all created checkpoints
Alt.GetAllCheckpoints | Returns all created checkpoints as `ICollection<ICheckpoint>`
Alt.GetCheckpointsArray | Returns all created checkpoints as `KeyValuePair<IntPtr,ICheckpoint>[]`
Alt.RemoveCheckpoint | Destroys the specified checkpoint

## Events
`Alt.OnCheckpoint` is raised whenever any checkpoint is entered by any player.
Inside of the event handler you need to check which one of your checkpoints got triggered by comparing the object instances with the first parameter.
The entity which raised the event is specified by the second parameter.
At last `state` defines if the entity entered (`true`) or left (`false`) the checkpoint area.

## Full example
```cs
using AltV.Net;
using AltV.Net.Elements.Entities;
using System.Drawing;

public class CheckpointTest
    : IScript
{
    private ICheckpoint _demoCheckpoint;

    public CheckpointTest()
    {
        // register event handler
        Alt.OnCheckpoint += Alt_OnCheckpoint;
        
        // create a new checkpoint
        _demoCheckpoint = Alt.CreateCheckpoint(CheckpointType.Cylinder, new Position(), 1.5f, 2f, Color.Yellow);
    }

    private void Alt_OnCheckpoint(ICheckpoint checkpoint, IEntity entity, bool state)
    {
        if (checkpoint != _demoCheckpoint)
        {
            return;
        }

        if (state)
        {
            // entity entered the checkpoint
        }
        else
        {
            // entity left the checkpoint
        }
    }
}
```
