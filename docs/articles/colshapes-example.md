# ColShape Example
This is a Example how to create a Collision sphere & Call it. This is a shape that has a position and a radius.
ColShape Event handler have to be Created in a IScript Class! Otherwise it won´t work.

```csharp
IColShape col = Alt.CreateColShapeSphere(new Position(0, 0, 0), 3.0f); // We Declare & Create our ColSphere.
col.SetData("IS_FREEROAM_COLSHAPE", true); // We setting Data to our ColSphere.

public class ColShapes : IScript
{
    [ScriptEvent(ScriptEventType.ColShape)] // We Create the Event Handler.
    public static void OnEntityColshapeHit(IColShape shape, IEntity entity, bool state)
    {
        // If the ColSphere is the ColSphere we declared then it should do this :
        if (shape.GetData("IS_FREEROAM_COLSHAPE", out bool result)) 
        {
            if (entity is IPlayer player)   //We Check if the Entity is the player.
            {
                if (state) // If player Entered the ColShape then 
                {
                    player.SendChatMessage("Hello " + player.Name + "! Welcome to your ColShape :)");
                }
                else
                {
                    player.SendChatMessage("Bye " + player.Name + "! :(");
                }
            }
            else if (entity is IVehicle vehicle)
            {
                if (state) // If a Vehicle Entered the ColShape
                {
                    // We set the Primary Color of this Vehicle to Red.
                    vehicle.PrimaryColorRgb = new Rgba(255, 0, 0, 255);
                    // We Notify the Driver that his Vehicle Color is now Red.
                    vehicle.Driver.SendChatMessage("You hitted your Created ColShape! Now your Car is Red hehe :>"); 
                }
                else
                {
                    // We set the Primary Color of this Vehicle to Blue.
                    vehicle.PrimaryColorRgb = new Rgba(0, 0, 255, 255);
                    // We Notify the Driver that his Vehicle Color is now Blue.
                    vehicle.Driver.SendChatMessage("You hitted your Created ColShape! Now your Car is Red hehe :>");
                }
            }
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
