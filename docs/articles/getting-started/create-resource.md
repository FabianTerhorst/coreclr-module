# Create Resource

> [!TIP]
> This article covers both **client-side** and **server-side** resources.

## Create solution

In this example we will assume you call both your resource and your solution "ExampleProject".

> [!TIP]
> If you want to create a client-side resource, and have a server-side solution already, you can just add a new project to an existing solution.

### Create a project with Visual Studio 19

* Go to "File -> New -> Project...", now the Project Wizard should appear.
* In the left column select "Installed -> Visual C# -> .NET".
* Now select "Class Library (.NET)" and enter "Name", "Location" and the "Solution name".
* To setup the correct NuGet Packages open the Manager under "Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution..."
* Select Browse and search for AltV.Net and install the package "AltV.Net" (or "AltV.Net.Async" if you need async thread-safe api access)


### Create a project with Rider 2022.1.1

* Go to "New Solution", now the "New Solution" window should open.
* In the left column select ".NET / .NET Core -> Class Library"
* Now fill out "Solution name", "Project name", "Solution directory" and click "Create".
Filled out "New Solution" window should look like this:
![New_solution_window](~/altv-docs-assets/coreclr-module/images/create_solution_rider.png)
* To setup the correct NuGet Packages open the "NuGet" tab at the bottom row of IDE.
* In the search bar enter "AltV.Net" and install the package "AltV.Net" (or "AltV.Net.Async" if you need async thread-safe api access)
![Nuget_manager](~/altv-docs-assets/coreclr-module/images/nuget_rider.png)

## Dependency deploy

AltV server requires you to put all your NuGet dependencies near your built solution dll. This can be achieved in two ways:
* You can use CopyLocalLockFileAssemblies csproj setting
* You can use publish instead of build

### Modifying csproj
You can add `<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>` to a `PropertyGroup` in your `ExampleProject.csproj`.
With that you can build your project normally, each build will have all the dependencies near the built dll in every case.

To build your project, use `dotnet build` command or "Build" button in the IDE.
By default, built files will be located at `ExampleProject/ExampleProject/bin/Debug/net6.0/`

#### VS
If you want to customize build output, go to "Project -> {Your Project Name} Properties... -> Build", here you can select the Output path where the dll should be saved.

#### Rider
If you want to customize build output, right click your assembly (Second "ExampleProject" in your solution tree on the left), go to "Properties -> Debug (or Release, if you build Release)", here you can hange the "Output path" where the dlls will be placed after the build.

### Publishing project
Instead of build use command "dotnet publish" or IDE "Publish" button. In that way resulting dll will contain all the dependeny dlls near, alongside with some runtime stuff, that is not required.

To build your project, use `dotnet publish` command or "Publish" button in the IDE.
By default, built files will be located at `ExampleProject/ExampleProject/bin/Debug/net6.0/publish/`

#### Automatic deploy
See https://docs.microsoft.com/en-us/visualstudio/deployment/quickstart-deploy-to-local-folder?view=vs-2019 to automatically publish it in your resource folder or see the boilerplate project file.

Or, otherwise you can edit .csproj file adding a Target, that will copy files for you.
```xml
<ItemGroup>
    <AllOutputFiles Include="$(OutputPath)\publish\*.*" />
</ItemGroup>

<Target Name="CopyFiles" AfterTargets="publish">
    <PropertyGroup>
        <CopiedFiles>$(OutputPath)\publish\*.*</CopiedFiles>
        <TargetLocation Condition=" '$(Configuration)' == 'Release' ">../path/where/dlls/should/be/copied/</TargetLocation>
    </PropertyGroup>
    <Copy Condition=" '$(TargetLocation)' != '' " SourceFiles="@(AllOutputFiles)" DestinationFolder="$(TargetLocation)" SkipUnchangedFiles="false" />
</Target>
```

## Setup a resource class

Now you have to create a single class, that will be an entry point for your resource.
The class should extend `Resource` or `AsyncResource`, class name doesn't matter.
Also the class should override `void OnStart()` and `void OnStop()` methods.
The class will be automatically constructed by the module.

Example code for ExampleResource.cs:
```csharp
using System;
using AltV.Net;

namespace ExampleProject
{
    internal class ExampleResource : Resource
    {
        public override void OnStart()
        {
            Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            Console.WriteLine("Stopped");
        }
    }
}
```

> [!TIP]
> For client-side resource use `using AltV.Net.Client` instead of `using AltV.Net`

## Create resource

In the server's `resources` folder you need to create a folder, which will be a folder for your resource.

Make a `bin` folder inside of your resource folder, and copy your project dll's (with NuGet generated dlls e.g. AltV.Net.dll) to this folder

Finally, in the folder you should contain a config file with name `resource.toml`.

### Client-side

Example `resource.toml` for a C# client-side resource:
```toml
client-type = "csharp"
client-main = "bin/ExampleProject.dll"
client-files = [
    "bin/*"
]
```
For client in `client-files` you need to specify folder, where all the dll's are located.

> [!TIP]
> You can combine both client-side and server-side code in one resource.<br>
> In order to do that, just combine both config examples, and change dll names.

> [!WARNING]
> We recommend you to not put your server-side resource dlls in any folder, that is specified in `client-files`.<br>
> That will lead to the server-side dll being sent to client.

### Server-side

Example `resource.toml` for a C# server-side resource:
```toml
type = "csharp"
main = "bin/ExampleProject.dll"
```

At the end you should add the resource in your `server.toml` like this:
```toml
resources = [
    "my-example-csharp-resource"
]
```

Your server folder now look similar to this one:
```
modules/
└── csharp-module.dll
resources/
└── my-example-csharp-resource/
    ├── resource.toml
    ├── ExampleProject.dll
    ├── AltV.Net.dll
    └── ... (Dependencies like "AltV.Net.Async.dll", "mysql.dll", if you have any)
AltV.Net.Host.dll
AltV.Net.Host.runtimeconfig.json
server.toml
altv-server.exe
```

## Next steps

For creating scripts that can be created multiple times see: [Create script](create-script.md).
