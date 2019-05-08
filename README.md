# corecrl-module
CoreClr (.NET Core Common Language Runtime) module

## Download (windows / linux)
- [Releases](https://github.com/FabianTerhorst/coreclr-module/releases)

## Download Windows
- Download csharp-module.dll

## Download Linux
- Download libcsharp-module.so

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
]
```
wildcards are also supported
```
client-files: [ 
"client/*"
]
```
client file imports are based on ecmascript2015 imports https://developer.mozilla.org/de/docs/Web/JavaScript/Reference/Statements/import
but require full path import like ```import * as auth from 'client/auth.mjs';``` (relative from resource folder)

### Download altv server binary

https://altv.mp/#/downloads

### Installing .NET Core SDK >= 2.2

.NET Core SDK can be found [here](https://dotnet.microsoft.com/download). You have to install the sdk, the runtime isn't needed.

## Assembly setup (more control for server developers, probably better performance as well)

(TODO: more docs)
- Create console application
- (For now) create empty assembly.cfg in your resource.cfg
Boilerplate AltV.Net.Example.csproj:
```
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>netcoreapp2.2</TargetFramework>
        <OutputType>Exe</OutputType>
    </PropertyGroup>

    <ItemGroup>
      <PackageReference Include="AltV.Net" Version="1.4.0" />
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

## Class Library setup (less control for server developers (don't support mysql))

### Create a project with Visual Studio 17 (Windows)

* Go to "File -> New -> Project..." now the Project Wizard should appear.
* In the left Column select "Installed -> Visual C# -> .NET Core".
* Now select "Class Library (.NET Core)" and choose "Name", "Location" and the "Solution name".
* To setup the correct NuGet Packages open the Manager under "Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution..."
* Select Browse and search for AltV.Net and install the packages "AltV.Net", ("AltV.Net.Async" when you need async thread save api access)
* Now go to "Project -> {Your Project Name} Properties... -> Build", here you can select the Output path where the dll should be saved.

To get the Resource running on the server, you have to create a "resource.cfg" file. Copy the resource.cfg, AltV.Net.dll and all other dependencied with your resource dll file to altv-server/resources/{YourResourceName}/.

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
```
