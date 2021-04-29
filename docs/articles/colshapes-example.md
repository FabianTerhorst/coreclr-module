# ColShape Example

This is a Example how to create a Collision sphere & Call it. This is a shape that has a position and a radius.
ColShape Event handler have to be Created in a IScript Class! Otherwise it won´t work.

# ColShape Example
This is a example how to create a collision sphere & call it.

| Parameter | Description  |
|-----------|--------------|
| shape     | The colshape which got triggered. |
| entity    | The entity who triggered the colshape |
| state     | The entering status ( true = entered, false = left ) |

## Normal event handler

```csharp
Alt.OnColShape += (shape, entity, state) => {
    // ...
}
```


## IScript event handler

##### Note : ScriptEvents have to be created in a IScript Class! Otherwise it won´t work!

```csharp
// We declare & create our colSphere.
IColShape col = Alt.CreateColShapeSphere(new Position(0, 0, 0), 3.0f); 
col.SetData("IS_FREEROAM_COLSHAPE", true); // We setting Data to our ColSphere.

// We create our IScript class
public class MyScriptClass : IScript
{
    // We declare and create our event handler
    [ScriptEvent(ScriptEventType.ColShape)] 
    public static void OnEntityColshapeHit(IColShape shape, IEntity entity, bool state)
    {
        // If the ColSphere is the ColSphere we declared then it should do this :
        if (!shape.GetData("IS_FREEROAM_COLSHAPE", out bool result)) return;
        
        // We create our switch statement.
        string stateMsg = state switch
        {
            true => "entered",
            _ => "left"
        };
        
        switch (entity)
        {
            case IPlayer player:
                player?.SendChatMessage("You " + stateMsg + " a colshape!");
                break;
            case IVehicle vehicle:
                vehicle?.Driver?.SendChatMessage("You " + stateMsg + " a colshape with your "+ (VehicleModel)vehicle.Model +"!");
                break;
        }
}
```

# ColShape Type´s
Here are some ColShape Types you could need in future.


ColShape in a Circle form.
```csharp
//Parameter : (Position pos, float Radius)
Alt.CreateColShapeCircle(new Position(0, 0, 0), 1.0f); //Creates a ColShape in a form of a Circle.
```

ColShape in a Cube form.
```csharp
//Parameter : (Position pos1, Position pos2)
Alt.CreateColShapeCube(new Position(0, 0, 0), new Position(0, 0, 0)); // Creates a ColShape in a form of a Cube.
```

ColShape in a Cylinder form.
```csharp
//Parameter : (Position pos, float radius, float height)
Alt.CreateColShapeCylinder(new Position(0, 0, 0), 1.0f, 100f); //Creates a ColShape in a form of a Cylinder.
```

ColShape in a Rectangle form.
```csharp
//Parameter : (float x1, float y1, float x2, float y2, float height)
Alt.CreateColShapeRectangle(0.0f, 0.0f, 0.0f, 0.0f, 10f); // Creates a ColShape in a form of a Rectangle.
```
