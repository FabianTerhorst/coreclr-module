# Serialization

This article describes how to send custom objects via events.

## Writable objects

This is the easy way to send objects from server to client, because it only supports writing not reading.
This only works when you can edit the class you want to send, because you need to add a interface to it.

### Step 1

Add the ```IWritable``` interface to your class.

```csharp
public class MyClass : IWritable {

}
```

### Step 2

This interface will require you to implement the ```public void OnWrite(IMValueWriter writer)``` method.

```csharp
public class MyClass : IWritable
{
    public void OnWrite(IMValueWriter writer)
    {
    }
}
```

### Step 3

Now you can use the writer to write data to it. ```OnWrite``` will call automatically when you put a object that is a instance of your class into ```Alt.Emit, player.Emit``` ect.  

 This is a simple example of a class only containing a single int.

```csharp
public class MyClass : IWritable
{
    private int myInt;
    
    public MyClass(int myInt) {
      this.myInt = myInt;
    }

    public void OnWrite(IMValueWriter writer)
    {
        writer.BeginObject(); // We tell the writer to create a object.
        writer.Name("myInt"); // We tell the writer the next attribute of the object has the name 'myInt'.
        writer.Value(myInt); // We tell the writer the value for the attribute 'myInt'.
        writer.EndObject(); // We tell the writer that we are done creating the object.
    }
}
```
Now you can just send a instance of the class.

```csharp
player.Emit("myEventName", new MyClass(42));
```

This will result in the following js output
```js
alt.onServer("myEventName", (myClass) => {
    alt.log(JSON.stringify(myClass));
    alt.log(myClass.myInt); // 42
})
// Console:
{
   "myInt": 42
}
```

### Step 4 

To send arrays its the same logic.

```csharp
public class MyClass2 : IWritable
{
    public void OnWrite(IMValueWriter writer)
    {
        writer.BeginObject(); // We tell the writer to create a object.
          writer.Name("myInts"); // We tell the writer the next attribute of the object has the name 'myInts'.
          writer.BeginArray(); // We tell the writer the value for the attribute 'myInts' is a array.
            for (int i = 0;i < 3;i++ {
              writer.BeginObject();
                writer.Name("myInt");
                writer.Value(i);
              writer.EndObject();
            }
          writer.EndArray(); // We tell the writer we are done creating the array
        writer.EndObject(); // We tell the writer that we are done creating the object.
    }
}
```

Now you can just send a instance of the class.

```csharp
player.Emit("myEventName", new MyClass2());
```

This will result in the following js output
```js
alt.onServer("myEventName", (myClass) => {
    alt.log(JSON.stringify(myClass));
    alt.log(myClass.myInts.length); // 3
    alt.log(myClass.myInts[0].myInt); // 0
    alt.log(myClass.myInts[1].myInt); // 1
    alt.log(myClass.myInts[2].myInt); // 2
    for (const obj of myClass.myInts) {
      alt.log(obj.myInt);
    }
})
// Console:
{
   "myInts": [
    {
      "myInt": 0
    },
    {
      "myInt": 1
    },
    {
      "myInt": 2
    },
   ]
}
```

### Step 5 

To send arrays without keys its the same logic.

```csharp
public class MyClass3 : IWritable
{
    public void OnWrite(IMValueWriter writer)
    {
        writer.BeginObject(); // We tell the writer to create a object.
          writer.Name("myInts"); // We tell the writer the next attribute of the object has the name 'myInts'.
          writer.BeginArray(); // We tell the writer the value for the attribute 'myInts' is a array.
            for (int i = 0;i < 3;i++ {
                writer.Value(i); // We add the value to the array 'myInts'
            }
          writer.EndArray(); // We tell the writer we are done creating the array
        writer.EndObject(); // We tell the writer that we are done creating the object.
    }
}
```

Now you can just send a instance of the class.

```csharp
player.Emit("myEventName", new MyClass3());
```

This will result in the following js output
```js
alt.onServer("myEventName", (myClass) => {
    alt.log(JSON.stringify(myClass));
    alt.log(myClass.myInts.length); // 3
})
// Console:
{
   "myInts":[0,1,2]
}
```
