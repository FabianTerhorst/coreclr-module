using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using AltV.Net.Host.Diagnostics.Client.DiagnosticsClient;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using AltV.Net.Host.Diagnostics.Tools;

namespace AltV.Net.Host
{
    public class CollectTraceClient
    {
        public sealed class Profile
        {
            public Profile(string name, IEnumerable<EventPipeProvider> providers, string description)
            {
                Name = name;
                Providers = providers == null
                    ? Enumerable.Empty<EventPipeProvider>()
                    : new List<EventPipeProvider>(providers).AsReadOnly();
                Description = description;
            }

            public string Name { get; }

            public IEnumerable<EventPipeProvider> Providers { get; }

            public string Description { get; }

            public static void MergeProfileAndProviders(Profile selectedProfile,
                List<EventPipeProvider> providerCollection, Dictionary<string, string> enabledBy)
            {
                var profileProviders = new List<EventPipeProvider>();
                // If user defined a different key/level on the same provider via --providers option that was specified via --profile option,
                // --providers option takes precedence. Go through the list of providers specified and only add it if it wasn't specified
                // via --providers options.
                if (selectedProfile.Providers != null)
                {
                    foreach (EventPipeProvider selectedProfileProvider in selectedProfile.Providers)
                    {
                        bool shouldAdd = true;

                        foreach (EventPipeProvider providerCollectionProvider in providerCollection)
                        {
                            if (providerCollectionProvider.Name.Equals(selectedProfileProvider.Name))
                            {
                                shouldAdd = false;
                                break;
                            }
                        }

                        if (shouldAdd)
                        {
                            enabledBy[selectedProfileProvider.Name] = "--profile ";
                            profileProviders.Add(selectedProfileProvider);
                        }
                    }
                }

                providerCollection.AddRange(profileProviders);
            }
        }

        public static readonly Profile CpuSampling = new Profile(
            "cpu-sampling",
            new EventPipeProvider[]
            {
                new EventPipeProvider("Microsoft-DotNETCore-SampleProfiler", EventLevel.Informational),
                new EventPipeProvider("Microsoft-Windows-DotNETRuntime", EventLevel.Informational,
                    (long) ClrTraceEventParser.Keywords.Default)
            },
            "Useful for tracking CPU usage and general .NET runtime information. This is the default option if no profile or providers are specified.");

        public static readonly Profile GcVerbose = new Profile(
            "gc-verbose",
            new EventPipeProvider[]
            {
                new EventPipeProvider(
                    name: "Microsoft-Windows-DotNETRuntime",
                    eventLevel: EventLevel.Verbose,
                    keywords: (long) ClrTraceEventParser.Keywords.GC |
                              (long) ClrTraceEventParser.Keywords.GCHandle |
                              (long) ClrTraceEventParser.Keywords.Exception
                ),
            },
            "Tracks GC collections and samples object allocations.");

        public static readonly Profile GcCollect = new Profile(
            "gc-collect",
            new EventPipeProvider[]
            {
                new EventPipeProvider(
                    name: "Microsoft-Windows-DotNETRuntime",
                    eventLevel: EventLevel.Informational,
                    keywords: (long) ClrTraceEventParser.Keywords.GC |
                              (long) ClrTraceEventParser.Keywords.Exception
                )
            },
            "Tracks GC collections only at very low overhead.");

        class ErrorCodes
        {
            public static int ArgumentError = 1;
            public static int SessionCreationError = 2;
            public static int TracingError = 3;
            public static int UnknownError = 4;
        }

        private static EventLevel defaultEventLevel = EventLevel.Verbose;

        public static List<EventPipeProvider> ToProviders(string providers)
        {
            if (providers == null)
                throw new ArgumentNullException(nameof(providers));
            return string.IsNullOrWhiteSpace(providers)
                ? new List<EventPipeProvider>()
                : providers.Split(',').Select(ToProvider).ToList();
        }

        private static EventLevel GetEventLevel(string token)
        {
            if (Int32.TryParse(token, out int level) && level >= 0)
            {
                return level > (int) EventLevel.Verbose ? EventLevel.Verbose : (EventLevel) level;
            }

            else
            {
                switch (token.ToLower())
                {
                    case "critical":
                        return EventLevel.Critical;
                    case "error":
                        return EventLevel.Error;
                    case "informational":
                        return EventLevel.Informational;
                    case "logalways":
                        return EventLevel.LogAlways;
                    case "verbose":
                        return EventLevel.Verbose;
                    case "warning":
                        return EventLevel.Warning;
                    default:
                        throw new ArgumentException($"Unknown EventLevel: {token}");
                }
            }
        }

        private static EventPipeProvider ToProvider(string provider)
        {
            if (string.IsNullOrWhiteSpace(provider))
                throw new ArgumentNullException(nameof(provider));

            var tokens = provider.Split(new[] {':'}, 4, StringSplitOptions.None); // Keep empty tokens;

            // Provider name
            string providerName = tokens.Length > 0 ? tokens[0] : null;

            // Check if the supplied provider is a GUID and not a name.
            if (Guid.TryParse(providerName, out _))
            {
                Console.WriteLine(
                    $"Warning: --provider argument {providerName} appears to be a GUID which is not supported by dotnet-trace. Providers need to be referenced by their textual name.");
            }

            if (string.IsNullOrWhiteSpace(providerName))
                throw new ArgumentException("Provider name was not specified.");

            // Keywords
            long keywords = tokens.Length > 1 && !string.IsNullOrWhiteSpace(tokens[1])
                ? Convert.ToInt64(tokens[1], 16)
                : -1;

            // Level
            EventLevel eventLevel = tokens.Length > 2 && !string.IsNullOrWhiteSpace(tokens[2])
                ? GetEventLevel(tokens[2])
                : defaultEventLevel;

            // Event counters
            string filterData = tokens.Length > 3 ? tokens[3] : null;
            var argument = string.IsNullOrWhiteSpace(filterData) ? null : ParseArgumentString(filterData);
            return new EventPipeProvider(providerName, eventLevel, keywords, argument);
        }

        private static Dictionary<string, string> ParseArgumentString(string argument)
        {
            if (argument == "")
            {
                return null;
            }

            var argumentDict = new Dictionary<string, string>();

            int keyStart = 0;
            int keyEnd = 0;
            int valStart = 0;
            int valEnd = 0;
            int curIdx = 0;
            bool inQuote = false;
            foreach (var c in argument)
            {
                if (inQuote)
                {
                    if (c == '\"')
                    {
                        inQuote = false;
                    }
                }
                else
                {
                    if (c == '=')
                    {
                        keyEnd = curIdx;
                        valStart = curIdx + 1;
                    }
                    else if (c == ';')
                    {
                        valEnd = curIdx;
                        argumentDict.Add(argument.Substring(keyStart, keyEnd - keyStart),
                            argument.Substring(valStart, valEnd - valStart));
                        keyStart = curIdx + 1; // new key starts
                    }
                    else if (c == '\"')
                    {
                        inQuote = true;
                    }
                }

                curIdx += 1;
            }

            string key = argument.Substring(keyStart, keyEnd - keyStart);
            string val = argument.Substring(valStart);
            argumentDict.Add(key, val);
            return argumentDict;
        }

        private static List<EventPipeProvider> CreateProviderCollection(string providers = "", Profile profile = null)
        {
            if (profile == null)
            {
                profile = CpuSampling;
            }

            IDictionary<string, string> enabledBy = new Dictionary<string, string>();

            var providerCollection = ToProviders(providers);
            foreach (var providerCollectionProvider in providerCollection)
            {
                enabledBy[providerCollectionProvider.Name] = "--providers ";
            }

            var profileProviders = new List<EventPipeProvider>();

            // If user defined a different key/level on the same provider via --providers option that was specified via --profile option,
            // --providers option takes precedence. Go through the list of providers specified and only add it if it wasn't specified
            // via --providers options.
            if (profile.Providers != null)
            {
                foreach (var selectedProfileProvider in profile.Providers)
                {
                    var shouldAdd = true;

                    foreach (var providerCollectionProvider in providerCollection)
                    {
                        if (!providerCollectionProvider.Name.Equals(selectedProfileProvider.Name)) continue;
                        shouldAdd = false;
                        break;
                    }

                    if (!shouldAdd) continue;
                    enabledBy[selectedProfileProvider.Name] = "--profile ";
                    profileProviders.Add(selectedProfileProvider);
                }
            }

            providerCollection.AddRange(profileProviders);


            if (providerCollection.Count <= 0)
            {
                throw new ArgumentException("No providers were specified to start a trace.");
            }

            return providerCollection;
        }

        public static async Task<int> Collect(ICollection<Action<long>> sizeChangeCallbacks, CollectTrace.Tracing tracing, FileInfo output, TraceFileFormat format = TraceFileFormat.NetTrace)
        {
            var processId = Process.GetCurrentProcess().Id;

            var providerCollection = CreateProviderCollection();

            var diagnosticsClient = new DiagnosticsClient(processId);
            EventPipeSession session = null;
            try
            {
                session = diagnosticsClient.StartEventPipeSession(providerCollection, true);
            }
            catch (DiagnosticsClientException e)
            {
                Console.Error.WriteLine($"Unable to start a tracing session: {e.ToString()}");
            }

            if (session == null)
            {
                Console.Error.WriteLine("Unable to create session.");
                return ErrorCodes.SessionCreationError;
            }

            var failed = false;
            var terminated = false;

            try
            {
                var collectingTask = new Task(() =>
                {
                    try
                    {
                        using (var fs = new FileStream(output.FullName, FileMode.Create, FileAccess.Write))
                        {
                            var buffer = new byte[16 * 1024];

                            while (true)
                            {
                                int nBytesRead = session.EventStream.Read(buffer, 0, buffer.Length);
                                if (nBytesRead <= 0)
                                    break;
                                fs.Write(buffer, 0, nBytesRead);
                                foreach (var sizeChangeCallback in sizeChangeCallbacks)
                                {
                                    sizeChangeCallback(fs.Length);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        failed = true;
                        Console.Error.WriteLine($"[ERROR] {ex.ToString()}");
                    }
                    finally
                    {
                        terminated = true;
                    }
                });
                collectingTask.Start();
                
                tracing.Wait();
                
                session.Stop();

                await collectingTask;

                if (format != TraceFileFormat.NetTrace)
                    TraceFileFormatConverter.ConvertToFormat(format, output.FullName);

                return failed ? ErrorCodes.TracingError : 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[ERROR] {ex.ToString()}");
                return ErrorCodes.UnknownError;
            }
        }
    }
}