# corecrl-module
CoreClr (.NET Core Common Language Runtime) module

## Beta
Only use the beta versions when you use the beta server from https://altv.mp/#/downloads

### Download

Download from https://altv.mp/#/downloads, you can select stable or beta and windows or linux.

### Server file structure

**Folder Structure**

```
modules/
└── csharp-module.dll
└── node-module.dll
resources/
└── my-example-csharp-resource/
    ├── Alt.Net.Example.dll
    ├── resource.cfg
    └── ... (any .dll dependency like "AltV.Net.dll" or "mysql.dll")
└── my-example-client-resource/
    ├── index.mjs
    ├── client.mjs
    └── resource.cfg
server.cfg
altv-server.exe
```

## Install
- Add csharp-module to server.cfg
```
...
modules: ["csharp-module"]
...
```
or with node-module
```
...
modules: [
"csharp-module"
"node-module"
]
...
```

### Create Resource

Only one server c# resource is supported at the same time.

resource.cfg:
```
type: "csharp",
main: "AltV.Net.Example.dll"
```

### Create Client Resource
Do not mix js and csharp resources. (empty index.mjs)

resource.cfg:
```
type: "js",
main: index.mjs
client-main: "client.mjs",
client-files: [ "client.mjs" ]
```
client-files specify files downloaded by the client
```
client-files: [ 
"file1.mjs"
"file2.mjs"
index.html
image.png
]
```
"" around files are optional

wildcards are also supported
```
client-files: [ 
"client/*"
]
```

### Add resources to server.cfg

server.cfg:
```
resources: [
"login-screen"
]
```

client file imports are based on ecmascript2015 imports https://developer.mozilla.org/de/docs/Web/JavaScript/Reference/Statements/import
but require full path import like ```import * as auth from 'client/auth.mjs';``` (relative from resource folder)

### Nuget

- https://www.nuget.org/packages/AltV.Net
- optional async module https://www.nuget.org/packages/AltV.Net.Async

### Installing .NET Core SDK >= 2.2

.NET Core SDK can be found [here](https://dotnet.microsoft.com/download). You have to install the sdk, the runtime isn't needed.

## Assembly setup (more control for server developers, probably better performance as well)

### Create a project with Visual Studio 17 (Windows)

* Go to "File -> New -> Project..." now the Project Wizard should appear.
* In the left Column select "Installed -> Visual C# -> .NET Core".
* Now select "Console Application (.NET Core)" and choose "Name", "Location" and the "Solution name".
* To setup the correct NuGet Packages open the Manager under "Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution..."
* Select Browse and search for AltV.Net and install the packages "AltV.Net", ("AltV.Net.Async" when you need async thread save api access)
* Now go to "Project -> {Your Project Name} Properties... -> Build", here you can select the Output path where the dll should be saved.

To get the Resource running on the server, you have to create a "resource.cfg" file. Copy the resource.cfg, AltV.Net.dll and all other dependencied with your resource dll file to altv-server/resources/{YourResourceName}/.

- (For now) create empty assembly.cfg in your resource.
Boilerplate AltV.Net.Example.csproj:
```
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>netcoreapp2.2</TargetFramework>
        <OutputType>Exe</OutputType>
    </PropertyGroup>

    <ItemGroup>
      <!--Use latest version from https://www.nuget.org/packages/AltV.Net-->
      <PackageReference Include="AltV.Net" Version="1.8.1" />
    </ItemGroup>
    
    <!--This copies the publish directory to the resource folder which is named "my-server"-->
    
    <ItemGroup>
        <AllOutputFiles Include="$(OutputPath)\publish\*.*" />
    </ItemGroup>

    <Target Name="CopyFiles" AfterTargets="publish">
        <PropertyGroup>
            <CopiedFiles>$(OutputPath)\publish\*.*</CopiedFiles>

            <TargetLocation Condition=" '$(Configuration)' == 'Release' ">../../my-server/</TargetLocation>
        </PropertyGroup>
        <Copy Condition=" '$(TargetLocation)' != '' " SourceFiles="@(AllOutputFiles)" DestinationFolder="$(TargetLocation)" SkipUnchangedFiles="false" />
    </Target>

</Project>
```
Program.cs
```csharp
namespace My.Package
{
    internal static class Program
    {
        private static void Main(string[] args) => new MyResource().Start(args);
    }
}
```
MyResource.cs
```csharp
using System;

namespace My.Package
{
    internal class MyResource : Resource
    {
        public override void OnStart()
        {
            Alt.OnServerEvent += (name, args) => { Alt.Log(name + " " + args.Length); };
            Alt.Emit("test");

            Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            Console.WriteLine("Stopped");
        }
    }
}
```

## Class Library setup (less control for server developers (don't support mysql))

### Create a project with Visual Studio 17 (Windows)

* Go to "File -> New -> Project..." now the Project Wizard should appear.
* In the left Column select "Installed -> Visual C# -> .NET Core".
* Now select "Class Library (.NET Core)" and choose "Name", "Location" and the "Solution name".
* To setup the correct NuGet Packages open the Manager under "Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution..."
* Select Browse and search for AltV.Net and install the packages "AltV.Net", ("AltV.Net.Async" when you need async thread save api access)
* Now go to "Project -> {Your Project Name} Properties... -> Build", here you can select the Output path where the dll should be saved.

To get the Resource running on the server, you have to create a "resource.cfg" file. Copy the resource.cfg, AltV.Net.dll and all other dependencied with your resource dll file to altv-server/resources/{YourResourceName}/.


### Events

There is currently a single limitation that dictionaries aren't working in windows but on linux.

### Defined events

```
Alt.OnPlayerConnect += OnPlayerConnect;
Alt.OnPlayerDisconnect += OnPlayerDisconnect; (play disconnected)
Alt.OnPlayerRemove += OnPlayerRemove; (player entity removed from memory)
Alt.OnVehicleRemove += OnVehicleRemove;
Alt.OnConsoleCommand += (name, args) => { };
Alt.OnPlayerEvent += (player, name, args) => { Alt.Log("event:" + name); }; (generic event handler for all event names)
...(and a lot more)
```

### On (Custom Events)

Alt.Emit is used to illustrate event triggering from server -> server, in most use cases the client would trigger the events.

#### Supported Argument Types

`null`, `bool`, `int`, `uint,` `long`, `ulong`, `double`, `string`, `object`, `float`

All types above as an array, eg. `int []`, `string[]`, ....

Furthermore Dictionaries with `string`-Type as Key, eg. `Dictionary<string, object>`

But also all interfaces of the AltV API or extend these, eg. `IEntity`, `IVehicle`, `IBlip`, `ICheckpoint`, `MyVehicle` ...

#### Examples

```csharp
Alt.On("test", args => { Alt.Log("args=" + args[0]); });

Alt.Emit("test", "bla");
```

```csharp
Alt.On<string>("test", str => { Alt.Log("str=" + str); });

Alt.Emit("test", "bla");
```

```csharp
Alt.On("test", delegate(string str){ Alt.Log("str=" + str); });

Alt.Emit("test", "bla");
```

```csharp
Alt.On<string>("test", bla);
void bla(string str) {
    Alt.Log("str=" + str);
}
Alt.Emit("test", "bla");
```

##### Advanced Example

The first Generics (in our example below `int` and `string`) are the Types for the parameters, the last generic (`bool`) is the return-type.

**Note**: Return types are optional at events

```csharp
Alt.On<int, string, bool>("test", (number, str) => {
    Alt.Log("str=" + str + " - " + number);
	return true;
});
```

## Custom serialization

You can send objects when the objects are implementing IWritable.

e.g.
```csharp
List<WritableObject> objects;
player.Emit("objects", objects);
```
`WritableObject.cs`:
```csharp
public class WritableObject : IWritable
{
    private readonly string test;

    public WritableObject()
    {
        test = "123";
    }

    public void OnWrite(IMValueWriter writer)
    {
        writer.BeginObject();
        writer.Name("test");
        writer.Value(test);
        writer.EndObject();
    }
}
```

## entity factories 

Needed when you want to improve performance by not using entity.GetData(..), entity.SetData(...) but entity.MyData... instead

SampleResource.cs:
```csharp
public class SampleResource : Resource
...
public override IEntityFactory<IVehicle> GetVehicleFactory()
{
    return new MyVehicleFactory();
}
...(also supports player, blip, checkpoint, ....)
```
MyVehicleFactory.cs:
```csharp
namespace My.Package
{
    public class MyVehicleFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IntPtr vehiclePointer, ushort id)
        {
            return new MyVehicle(vehiclePointer, id);
        }
    }
}
```
MyVehicle.cs
```csharp
namespace AltV.Net.Example
{
    public class MyVehicle : Vehicle, IMyVehicle
    {
        public int MyData { get; set; }

        public MyVehicle(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            MyData = 6;
        }
    }
}
```
 All entity apis can be found in the interfaces of the entities
 [IPlayer](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Elements/Entities/IPlayer.cs)
 [IVehicle](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Elements/Entities/IVehicle.cs)
 [IBlip](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Elements/Entities/IBlip.cs)
 [ICheckpoint](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Elements/Entities/ICheckpoint.cs)
 
 ### Experimental collision shapes
 
Add the https://www.nuget.org/packages/AltV.Net.ColShape/ dependency to your gameserver resource. Your resource needs to use https://www.nuget.org/packages/AltV.Net.Async/ as well and needs to extend AsyncResource.
 
Configure AltColShape
```csharp
AltColShape.Configure(options =>
{
    // AreaSize defines the internal size of the colshape areas that are used for fast colshape algorithm
    // This doesn't influence colshape radius
    // smaller size => less cpu usage, more ram
    options.AreaSize = 100;
});
```
Configure event handlers
```csharp
AltColShape.OnEntityEnterColShape = (entity, shape) => {  };
AltColShape.OnEntityExitColShape = (entity, shape) => {  };
```

Add collision shapes
```csharp
AltColShape.Add(new ColShape(id, dimension, new Position(x, y, z), radius));
```

Extend ColShapes
```csharp
public class CustomColShape : ColShape
{
    public int MyData;
    
    public CustomColShape(ulong id, int dimension, Position position, uint radius) : base(id, dimension, position,
            radius)
    {
    }
}
AltColShape.Add(new CustomColShape(id, dimension, new Position(x, y, z), radius));
AltColShape.OnEntityEnterColShape = (entity, shape) => {
    if(shape is CustomColShape customColShape) {
        Console.WriteLine(customColShape.MyData.ToString());
    }
};
```
 
 ### Experimental entity streaming
 
 https://github.com/FabianTerhorst/coreclr-module/releases/download/1.7.6-beta6/networking-entity.zip
 
 Include the js file in your index.html 
```html
<script type="module" src="networking-entity.js"></script>
```
Add the networking-entity.js and entity.proto file to your client config and save the entity.proto in top level of client files
Add the https://www.nuget.org/packages/AltV.Net.NetworkingEntity/ to your project where you want to run the server
```csharp
AltNetworking.Init();
AltNetworking.CreateEntity(new Position {X = 0, Y = 0, Z = 73}, 1, 50,  new Dictionary<string, object>());
```
Add the client.js to your client and maybe rename the file
Use it like this
```js
import { create, onStreamIn, onStreamOut, onDataChange } from "client/streaming/client.js";
import game from "natives";
import hudWebView from "client/hud-webview.js";

class EntityStreamer {
    constructor() {
        create(hudWebView);
        this.peds = new Map();
        this.onStreamIn = this.onStreamIn.bind(this);
        this.onStreamOut = this.onStreamOut.bind(this);
        this.onDataChange = this.onDataChange.bind(this);
        onStreamIn(this.onStreamIn);
        onStreamOut(this.onStreamOut);
        onDataChange(this.onDataChange);
    }

    onStreamIn(entity) {
        const ped = game.createPed(2, 1885233650, entity.position.x, entity.position.y, entity.position.z, 61, false, true);
        this.peds.set(entity.id, ped);

    }

    onStreamOut(entity) {
        if (this.peds.has(entity.id)) {
            game.deleteEntity(this.peds.get(entity.id));
        }
    }

    onDataChange(entity, data) {
        //TODO: when model changes ect.
    }

}

export default new EntityStreamer();
```
Import the streamer in your main client file
```js
import "client/entity-streamer.js";
```
When running on server don't forget to open the websocket port 46429 or change it to a own port with
```csharp
AltNetworking.Init(new NetworkingModule(myPort))
```

