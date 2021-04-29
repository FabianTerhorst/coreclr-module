# ColShape Example

This is a example how to create a collision sphere & call it.

| Parameter | Description  |
|-----------|--------------|
| shape     | The colshape which got triggered. |
| entity    | The entity who triggered the colshape. |
| state     | The entering status ( true = entered, false = left ). |

## Normal event handler

```csharp
Alt.OnColShape += (shape, entity, state) => {
    // ...
}
```


## IScript event handler

##### Note : ScriptEvents have to be created in a IScript class! Otherwise it won't work!

```csharp
// We declare & create our colsphere.
IColShape col = Alt.CreateColShapeSphere(new Vector3(0, 0, 0), 3.0f); 

// We create our IScript class
public class MyScriptClass : IScript
{
    // We declare and create our event handler
    [ScriptEvent(ScriptEventType.ColShape)] 
    public static void OnEntityColshapeHit(IColShape shape, IEntity entity, bool state)
    {
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
Here are all colshape types.


ColShape in a Circle form.
```csharp
//Parameter : (Vector3 pos, float Radius)
Alt.CreateColShapeCircle(new Vector3(0, 0, 0), 1.0f); // Creates a colshape in a form of a circle.
```

ColShape in a Cube form.
```csharp
//Parameter : (Vector3 pos1, Position pos2)
Alt.CreateColShapeCube(new Vector3(0, 0, 0), new Vector3(0, 0, 0)); // Creates a colshape in a form of a cube.
```

ColShape in a Cylinder form.
```csharp
//Parameter : (Vector3 pos, float radius, float height)
Alt.CreateColShapeCylinder(new Vector3(0, 0, 0), 1.0f, 100f); // Creates a colshape in a form of a cylinder.
```

ColShape in a Rectangle form.
```csharp
//Parameter : (float x1, float y1, float x2, float y2, float height)
Alt.CreateColShapeRectangle(0.0f, 0.0f, 0.0f, 0.0f, 10f); // Creates a colshape in a form of a rectangle.
```
