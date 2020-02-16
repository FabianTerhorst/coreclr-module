# ColShape Example
This is a Example how to create a Collision sphere & Call it. This is a shape that has a position and a radius.
ColShapes have to be Created in a IScript Class! Otherwise it won´t work.

```csharp
    
    IColShape col = Alt.CreateColShapeSphere(new Position(0, 0, 0), 3.0f); // We Declare & Create our ColSphere

  
    [ScriptEvent(ScriptEventType.ColShape)] // We Create the Event Handler.
    public static void OnEntityColshapeHit(IColShape shape, IEntity entity, bool state)
    {
        IPlayer player = entity as IPlayer;         //We declare the player.
        if(shape == col) // If the ColSphere is the ColSphere we declared then it should do this :
        {
            if(state) // If player Entered the ColShape then 
            {
                  player.SendChatMessage("Hello " + player.Name + "! Welcome to your ColShape :)");
            }
            else{
                  player.SendChatMessage("Bye " + player.Name + "! :(");
            }
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
