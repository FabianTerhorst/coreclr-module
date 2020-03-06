export default {
    resources: {
        example: {
            assembly: "AltV.Net.WebAssembly.Example",
            pdb: "AltV.Net.WebAssembly.Example",
            class: "AltV.Net.WebAssembly.Example.Program",
            method: "Main"
        }
    },
    dependencies: [
        "@dotnet/AltV.Net.Client.dll", 
        "@dotnet/AltV.Net.Client.pdb", 
        "@dotnet/mscorlib.dll",
        "@dotnet/WebAssembly.Bindings.dll",
        "@dotnet/netstandard.dll","System.dll",
        "@dotnet/Mono.Security.dll",
        "@dotnet/System.Xml.dll",
        "@dotnet/System.Numerics.dll",
        "@dotnet/System.Core.dll",
        "@dotnet/WebAssembly.Net.WebSockets.dll",
        "@dotnet/System.Memory.dll",
        "@dotnet/System.Data.dll",
        "@dotnet/System.Transactions.dll",
        "@dotnet/System.Data.DataSetExtensions.dll",
        "@dotnet/System.Drawing.Common.dll",
        "@dotnet/System.IO.Compression.dll",
        "@dotnet/System.IO.Compression.FileSystem.dll",
        "@dotnet/System.ComponentModel.Composition.dll",
        "@dotnet/System.Net.Http.dll",
        "@dotnet/WebAssembly.Net.Http.dll",
        "@dotnet/System.Runtime.Serialization.dll",
        "@dotnet/System.ServiceModel.Internals.dll",
        "@dotnet/System.Xml.Linq.dll"
    ]
}