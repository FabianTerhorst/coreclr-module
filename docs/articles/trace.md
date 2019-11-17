# Performance debugging

This article will describe how to debug performance issues in your gamemode.

## AltTrace

The AltV.Net nuget package provides a api to gamemodes for recording trace files. You can only write one trace file at the same time.

The following code is starting writing a trace file.

```csharp
AltTrace.Start("traceFileName");
```

This code stops writing a trace file.

```csharp
AltTrace.Stop();
```

You can also register a callback to know the size of the trace file while its written.

```csharp
AltTrace.OnTraceFileSizeChange += size =>
{
 Console.WriteLine("Trace file size:" + size + " bytes.");                
};
```

The trace file will be written to altv server directory. The trace file can be opened via visual studio 2019 or perfview on windows.

The easiest way to trigger starting and stopping a trace file recording is to register a server side command.

Some sample snippet

```csharp
long currentTraceSize = 0;
AltTrace.OnTraceFileSizeChange += size =>
  {
    currentTraceSize = size;
  };
            
  Alt.OnConsoleCommand += (name, args) =>
    {
      switch (name)
      {
        case "trace_start":
          if (args.Length != 1)
          {
            Console.WriteLine("trace_start {name}");
            return;
          }
          AltTrace.Start(args[0]);
          break;
        case "trace_stop":
          AltTrace.Stop();
          break;
        case "trace_size":
          Console.WriteLine("trace file size: " + currentTraceSize + " bytes");
          break;
      }
  };
```
