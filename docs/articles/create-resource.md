# Create Resource

## Create a project with Visual Studio 19 (Windows)

* Go to "File -> New -> Project..." now the Project Wizard should appear.
* In the left Column select "Installed -> Visual C# -> .NET Core".
* Now select "Class Library (.NET Core)" and choose "Name", "Location" and the "Solution name".
* To setup the correct NuGet Packages open the Manager under "Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution..."
* Select Browse and search for AltV.Net and install the packages "AltV.Net", ("AltV.Net.Async" when you need async thread save api access)
* Now go to "Project -> {Your Project Name} Properties... -> Build", here you can select the Output path where the dll should be saved.

To get the Resource running on the server, you have to create a "resource.cfg" file. Copy the resource.cfg, AltV.Net.dll and all other dependencied with your resource dll file to altv-server/resources/{YourResourceName}/.

Boilerplate YourProject.csproj:
```
<Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <TargetFramework>netcoreapp3.0</TargetFramework>
    </PropertyGroup>

    <ItemGroup>
      <!--Use latest version from https://www.nuget.org/packages/AltV.Net-->
      <PackageReference Include="AltV.Net" Version="1.13.0" />
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

You now have to create a single resource file in your project that is auto initialized on server startup.

MyResource.cs
```csharp
using System;

namespace My.Package
{
    internal class MyResource : Resource
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

For creating scripts that can be created multiple times see: [Create script](https://fabianterhorst.github.io/coreclr-module/articles/create-script.html).
