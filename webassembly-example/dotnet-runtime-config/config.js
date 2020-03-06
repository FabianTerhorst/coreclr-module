export default {
    resources: {
        example: {
            assembly: "AltV.Net.WebAssembly.Example",
            pdb: "AltV.Net.WebAssembly.Example",
            class: "AltV.Net.WebAssembly.Example.Program",
            method: "Main"
        }
    },
    runtime: "@dotnet-runtime-dependencies/dotnet.wasm",
    dependencies: [
        "@dotnet-runtime-dependencies/AltV.Net.Client.dll", 
        "@dotnet-runtime-dependencies/AltV.Net.Client.pdb", 
        "@dotnet-runtime-dependencies/mscorlib.dll",
        "@dotnet-runtime-dependencies/WebAssembly.Bindings.dll",
        "@dotnet-runtime-dependencies/netstandard.dll","System.dll",
        "@dotnet-runtime-dependencies/Mono.Security.dll",
        "@dotnet-runtime-dependencies/System.Xml.dll",
        "@dotnet-runtime-dependencies/System.Numerics.dll",
        "@dotnet-runtime-dependencies/System.Core.dll",
        "@dotnet-runtime-dependencies/WebAssembly.Net.WebSockets.dll",
        "@dotnet-runtime-dependencies/System.Memory.dll",
        "@dotnet-runtime-dependencies/System.Data.dll",
        "@dotnet-runtime-dependencies/System.Transactions.dll",
        "@dotnet-runtime-dependencies/System.Data.DataSetExtensions.dll",
        "@dotnet-runtime-dependencies/System.Drawing.Common.dll",
        "@dotnet-runtime-dependencies/System.IO.Compression.dll",
        "@dotnet-runtime-dependencies/System.IO.Compression.FileSystem.dll",
        "@dotnet-runtime-dependencies/System.ComponentModel.Composition.dll",
        "@dotnet-runtime-dependencies/System.Net.Http.dll",
        "@dotnet-runtime-dependencies/WebAssembly.Net.Http.dll",
        "@dotnet-runtime-dependencies/System.Runtime.Serialization.dll",
        "@dotnet-runtime-dependencies/System.ServiceModel.Internals.dll",
        "@dotnet-runtime-dependencies/System.Xml.Linq.dll"
    ]
}