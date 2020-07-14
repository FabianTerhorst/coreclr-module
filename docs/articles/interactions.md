# Interactions

This article will describe how to add fast serverside player interactions. 
You can also use the interactions for something else then player interactions, but player interactions are the common usecase for them.

## Setup Interactions

First download the nuget package to access the interaction api's:
https://www.nuget.org/packages/AltV.Net.interactions

Next you need to init the interactions package. The best place to do this is when your resource is starting.

Note: It doesn't matter if your resource is a async resource. The code below is just for illustrating how to do it in general.
```csharp
public class MyResource: Resource
{
    public override void OnStart()
    {
      // (some code from you)
      AltInteractions.Init();
      // (some code from you)
    }
    
    public override void OnStop()
    {
      // (some code from you)
      AltInteractions.Dispose();
      // (some code from you)
    }
}

Now the interaction package setup is done and ready to be used.

## Create interactions

To create a interaction you need to create a instance of it first.

This is how the default constructor looks like.
```csharp
var interaction = new Interaction(ulong type, ulong id, Vector3 position, int dimension, uint range);
```

The first parameter is the type. This defines the interaction type. A type can be anything you want to use it for. A example might be:
type 1 = house, type 2 = car shop, ect.

The second parameter is the id. This defines the interaction id for the given type. Only the id + type in combination needs to be unique.
You can have the same id used in different types. This is useful when you already have ids for houses and car shops and both have own auto incrementing counters starting at 1.

The third parameter is the position. This defines the position this interaction is present.

The fourth parameter is the dimension. This defines the dimension this interaction is visible inside. The dimension logic is the same as for players, vehicle ect.
```
X can see only X
-X can see 0 and -X
0 can't see -X and X
```

And the fifth and last parameter is the range. This defines the range this interaction is usable in.

## Add Interactions

To add a interaction to the system you can just call:
```csharp
AltInteractions.AddInteraction(interaction);
```

## Remove Interactions

To remove a interaction from the system you can just call:
```csharp
AltInteractions.RemoveInteraction(interaction);
```

## Find Interactions

To find all interactions that are on a specific position and visible for a specific dimensions you can call:
```csharp
var interactions = await AltInteractions.FindInteractions(position, dimension);
```
As you can see on the code this method returns a task that needs to be awaited.

Now we have a list of all interactions that are visible at this specific dimension and are in range of the positions.
The returned object is null when no interactions are found.
```csharp
 foreach (var interaction in interactions)
 {
   // do stuff with interaction.Id and interaction.Type
 }
```

## Create custom interactions

You might want to add custom interactions to add custom data to them. 

One example would be to add your house object to the interaction.

You have to add the default constructor when inherit from ```Interaction```

```csharp
public class HouseInteraction: Interaction 
{
    public HouseEntity House { get; }

    public HouseInteraction( HouseEntity house, ulong type, ulong id, Vector3 position, int dimension, uint range) : base(type, id,
            position, dimension, range)
    {
         House = house;
    }
}
```

Lets see how our interactions loop from above now looks like:
```csharp
 foreach (var interaction in interactions)
 {
   if (interaction is HouseInteraction houseInteraction) {
       // do something with houseInteraction.House
   }
 }
```
We can now get the house object from the interaction instead of using the interaction id and type to fetch it.
Note: You still should use the correct id and type to add and remove the interactions correctly.

## Trigger interactions

With custom classes you can make use of another feature that is available.

The Interaction class has a abstract method you can override.

```csharp
public class HouseInteraction: Interaction 
{
    public HouseEntity House { get; }

    public HouseInteraction( HouseEntity house, ulong type, ulong id, Vector3 position, int dimension, uint range) : base(type, id,
            position, dimension, range)
    {
        House = house;
    }
    
    public override bool OnInteraction(IPlayer player, Vector3 interactionPosition, int interactionDimension)
    {
        // do something with the House obj
        return false;
    }
}
```

This method is getting triggered each time you call:

```csharp
AltInteractions.TriggerInteractions(player);
```

When you returns false from a interaction you allow other interactions that might be in range as well to also call OnInteraction.
When you return true, no other interaction will trigger.
