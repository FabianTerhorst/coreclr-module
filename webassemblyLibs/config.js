export default {
    resources: {
        example: {
            assembly: "AltV.Net.WebAssembly.Example",
            class: "AltV.Net.WebAssembly.Example.Program",
            method: "Main"
        } 
    },
    dependencies: [
        "AltV.Net.WebAssembly.Example.dll",
        "AltV.Net.Client.dll", 
        "mscorlib.dll",
        "WebAssembly.Bindings.dll",
        "netstandard.dll","System.dll",
        "Mono.Security.dll",
        "System.Xml.dll",
        "System.Numerics.dll",
        "System.Core.dll",
        "WebAssembly.Net.WebSockets.dll",
        "System.Memory.dll",
        "System.Data.dll",
        "System.Transactions.dll",
        "System.Data.DataSetExtensions.dll",
        "System.Drawing.Common.dll",
        "System.IO.Compression.dll",
        "System.IO.Compression.FileSystem.dll",
        "System.ComponentModel.Composition.dll",
        "System.Net.Http.dll",
        "WebAssembly.Net.Http.dll",
        "System.Runtime.Serialization.dll",
        "System.ServiceModel.Internals.dll",
        "System.Xml.Linq.dll"
    ]
}