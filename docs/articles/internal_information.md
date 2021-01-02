# Internal information

This section provides a high-level overview about the internal structure of the C# module and how it's playing together with the AltV server.

<div class="WARNING">
  <h6>Important</h6>
  <p>Resource developers don't need to know the internal structure, but it is helpful sometimes. This is mainly for developers who like to contribute to the C# module.</p>
</div>

## Initialization of csharp-module

When the `altv-server` is starting it checks `modules` part of the `server.cfg` configuration file. When there's the csharp-module specified, the server loads the `csharp-module.dll` from the `modules` folder.

In the csharp-module is a function [`altMain`](https://github.com/FabianTerhorst/coreclr-module/blob/master/runtime/src/altv.cpp) defined, which starts the .NET runtime and registers itself as script runtime for `csharp` resources. That's the reason you have to specify `type: csharp` in the `resource.cfg`, so the altv-server knows that it should load this resource with the csharp-module.

The [custom .NET host](https://github.com/FabianTerhorst/coreclr-module/blob/master/runtime/src/CoreClr.cpp) tries to find the latest .NET SDK `hostfxr.dll` (example path on Windows is `C:\Program Files (x86)\dotnet\host\fxr\5.0.1\hostfxr.dll`). When it's found, it starts `AltV.Net.Host.dll` which is located next to the `altv-server`.

Now in .NET world the [`AltV.Net.Host`](https://github.com/FabianTerhorst/coreclr-module/tree/master/api/AltV.Net.Host) first initialize some delegates which can be triggered from the `csharp-module`. For example the `csharp-module` can trigger a delegate to start a specific resource with a name, path and a main file.

The main initialization is now done and we are waiting until a resource of type `csharp` should be loaded.

Summary:

* `altv-server` calls `csharp-module.dll`
* `csharp-module` acts as custom .NET host, starts .NET runtime with `AltV.Net.Host.dll`
* `AltV.Net.Host` initializes delegates which can be executed from `csharp-module`

## Loading a resource

For every C# resource the `csharp-module` creates a [`CSharpResourceImpl`](https://github.com/FabianTerhorst/coreclr-module/blob/master/runtime/src/CSharpResourceImpl.cpp). When the resource is started by the server, the class triggers `AltV.Net.Host` with the previous initialized `ExecuteResource` delegate.

There a [custom](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net.Host/ResourceAssemblyLoadContext.cs) [`AssemblyLoadContext`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.loader.assemblyloadcontext) is created, which is responsible for loading and resolving assemblies like the resource and their dependencies. The load context loads the files just from the resource folder which it is created for.

In the end the resource assembly is loaded and the `AltV.Net.dll` assembly is initialized by calling the [`ModuleWrapper#MainWithAssembly`](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/ModuleWrapper.cs) among others. 

Here the main initialization happens: The entity factories are resolved which are needed for creating the entity pools. These entity pools are storing the active entities like for example currently connected players in the player pool.

In order to receive events later from the server, it's required to set delegates which are executed on the `csharp-module`. This is done in [`CSharpResourceImpl`](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/CSharpResourceImpl.cs) from `AltV.Net` assembly. The functions which are executed are in `ModuleWrapper` and there the module functions are triggered.

Depending if the resource derives from `Resource` or `AsyncResource` a different module is resolved. The `AsyncModule` is thereby derived from `Module`. The module is the main class which stores all entity pools, forwards events to `IScript` methods and the event handlers in resources, like `Alt.OnPlayerEnterVehicle` and so on.

Afterwards the load context will be searched for implementations of `IScript`. These classes can have methods with custom attributes like `ScriptEventAttribute`. When specified for example `ScriptEventType.PlayerConnect` this method will be called every time a player connects. In order to get that working every `IScript` is loaded and the events registered. There are simply the `Alt.On*` events used (for non-async attributes). For `PlayerConnect`, there is an event handler for `Alt.OnPlayerConnect` which triggers the `IScript` method.

Last but not least the `csharp-module` is now triggering the `MainDelegate` which is received in the `ModuleWrapper`. There it just execute the `OnStart` method of the resource. This `OnStart` has every resource implemented, as it is a abstract method on the [`Resource`](https://github.com/FabianTerhorst/coreclr-module/blob/master/api/AltV.Net/Resource.cs) class.

Summary:

* `altv-server` calls `csharp-module` to start resource
* `csharp-module` creates `CSharpResourceImpl` which triggers `AltV.Net.Host`
* `AltV.Net.Host` loads resource assembly and dependencies (with `AltV.Net`)
* `AltV.Net` initializes itself and resource
* `csharp-module` triggers `MainDelegate` which executes resource `OnStart`

## Executing commands

When executing a command like `Alt.CreateVehicle` the static `Alt` class is just a proxy for internal methods. In the end it will trigger most likely a method inside of [`AltNative`](https://github.com/FabianTerhorst/coreclr-module/tree/master/api/AltV.Net/Native). This is a partial class (multiple files which are combined to one class) and acts as thin wrapper for the `csharp-module`.

In the vehicle example `AltNative.Server_CreateVehicle` is executed, which is a exported function in the `csharp-module`. The `Alt.Net` assembly uses the [`DllImportAttribute`](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute) to call the method from the native library.

Inside of the `csharp-module` the data is copied to internal data structures and then send to the `altv-server`.

## Receiving events

The events are received in the `csharp-module`. Every resource receives most of the events in `CSharpResourceImpl::OnEvent`. This prepares the data and executes a method of the `ModuleWrapper` with a delegate previous set in the initialization.

For example for the `alt::CEvent::Type::PLAYER_ENTER_VEHICLE` the required data is retrieved from the event and `OnPlayerEnterVehicleDelegate` is executed. This delegate is part of `ModuleWrapper` and there directly the `OnPlayerEnterVehicle` method of the loaded module is executed.

From there the entites are checked if these are valid and exists on the server. In the end all registered event handler are executed, like `Alt.OnPlayerEnterVehicle` or `ScriptEventAttribute`.