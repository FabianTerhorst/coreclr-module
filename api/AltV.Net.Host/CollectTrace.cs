using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AltV.Net.Host.Diagnostics.Eventing;
using AltV.Net.Host.Diagnostics.Tools;

namespace AltV.Net.Host
{
    public class CollectTrace
    {
        public static List<Provider> ToProviders(string providers)
        {
            if (providers == null)
                throw new ArgumentNullException(nameof(providers));
            return string.IsNullOrWhiteSpace(providers)
                ? new List<Provider>()
                : providers.Split(',').Select(ToProvider).ToList();
        }

        private static Provider ToProvider(string provider)
        {
            if (string.IsNullOrWhiteSpace(provider))
                throw new ArgumentNullException(nameof(provider));

            var tokens = provider.Split(new[] {':'}, 4, StringSplitOptions.None); // Keep empty tokens;

            // Provider name
            string providerName = tokens.Length > 0 ? tokens[0] : null;
            if (string.IsNullOrWhiteSpace(providerName))
                throw new ArgumentException("Provider name was not specified.");

            // Keywords
            ulong keywords = tokens.Length > 1 && !string.IsNullOrWhiteSpace(tokens[1])
                ? Convert.ToUInt64(tokens[1], 16)
                : ulong.MaxValue;

            // Level
            uint level = tokens.Length > 2 && !string.IsNullOrWhiteSpace(tokens[2])
                ? Convert.ToUInt32(tokens[2])
                : (uint) EventLevel.Verbose;
            EventLevel eventLevel =
                level > (uint) EventLevel.Verbose
                    ? EventLevel.Verbose
                    : (EventLevel) level; // TODO: Should we throw here?

            // Event counters
            string filterData = tokens.Length > 3 ? tokens[3] : null;
            filterData = string.IsNullOrWhiteSpace(filterData) ? null : filterData;

            return new Provider(providerName, keywords, eventLevel, filterData);
        }

        public class Tracing
        {
            private readonly Semaphore semaphore;

            //private readonly Semaphore semaphoreResult;

            //public bool Result { get; private set; }

            public Tracing()
            {
                this.semaphore = new Semaphore(0, 1);
                //this.semaphoreResult = new Semaphore(0, 1);
            }

            public void Stop()
            {
                semaphore.Release();
                //semaphoreResult.WaitOne();
            }

            internal void Wait()
            {
                semaphore.WaitOne();
            }

            /*internal void SignalFinish(bool result)
            {
                Result = result;
                semaphoreResult.Release();
            }*/
        }

        public sealed class Profile
        {
            public Profile(string name, IEnumerable<Provider> providers, string description)
            {
                Name = name;
                Providers = providers == null
                    ? Enumerable.Empty<Provider>()
                    : new List<Provider>(providers).AsReadOnly();
                Description = description;
            }

            public string Name { get; }

            public IEnumerable<Provider> Providers { get; }

            public string Description { get; }
        }

        public static readonly Profile CpuSampling = new Profile(
            "cpu-sampling",
            new Provider[]
            {
                new Provider("Microsoft-DotNETCore-SampleProfiler"),
                new Provider("Microsoft-Windows-DotNETRuntime", (ulong) ClrTraceEventParser.Keywords.Default,
                    EventLevel.Informational),
            },
            "Useful for tracking CPU usage and general .NET runtime information. This is the default option if no profile or providers are specified.");

        public static readonly Profile GcVerbose = new Profile(
            "gc-verbose",
            new Provider[]
            {
                new Provider(
                    name: "Microsoft-Windows-DotNETRuntime",
                    keywords: (ulong) ClrTraceEventParser.Keywords.GC |
                              (ulong) ClrTraceEventParser.Keywords.GCHandle |
                              (ulong) ClrTraceEventParser.Keywords.Exception,
                    eventLevel: EventLevel.Verbose
                ),
            },
            "Tracks GC collections and samples object allocations.");

        public static readonly Profile GcCollect = new Profile(
            "gc-collect",
            new Provider[]
            {
                new Provider(
                    name: "Microsoft-Windows-DotNETRuntime",
                    keywords: (ulong) ClrTraceEventParser.Keywords.GC |
                              (ulong) ClrTraceEventParser.Keywords.Exception,
                    eventLevel: EventLevel.Informational),
            },
            "Tracks GC collections only at very low overhead.");

        class ErrorCodes
        {
            public static int ArgumentError = 1;
            public static int SessionCreationError = 2;
            public static int TracingError = 3;
            public static int UnknownError = 4;
        }

        /// <summary>
        /// Collects a diagnostic trace from a currently running process.
        /// </summary>
        /// <param name="sizeChangeCallbacks">size change callbacks</param>
        /// <param name="tracing">To start / stop the tracing</param>
        /// <param name="processId">The process to collect the trace from.</param>
        /// <param name="output">The output path for the collected trace data.</param>
        /// <param name="buffersize">Sets the size of the in-memory circular buffer in megabytes.</param>
        /// <param name="providers">A list of EventPipe providers to be enabled. This is in the form 'Provider[,Provider]', where Provider is in the form: 'KnownProviderName[:Flags[:Level][:KeyValueArgs]]', and KeyValueArgs is in the form: '[key1=value1][;key2=value2]'</param>
        /// <param name="profile">A named pre-defined set of provider configurations that allows common tracing scenarios to be specified succinctly.</param>
        /// <param name="format">The desired format of the created trace file.</param>
        /// <returns></returns>
        public static async Task<int> Collect(ICollection<Action<long>> sizeChangeCallbacks, Tracing tracing,
            FileInfo output, int processId = 0,
            uint buffersize = 256,
            string providers = "", Profile profile = null, TraceFileFormat format = TraceFileFormat.NetTrace)
        {
            if (processId <= 0)
            {
                processId = Process.GetCurrentProcess().Id;
            }

            if (profile == null)
            {
                profile = CpuSampling;
            }

            try
            {
                Debug.Assert(output != null);
                if (processId <= 0)
                {
                    throw new ArgumentException("Process ID should not be negative.");
                }

                IDictionary<string, string> enabledBy = new Dictionary<string, string>();

                var providerCollection = ToProviders(providers);
                foreach (var providerCollectionProvider in providerCollection)
                {
                    enabledBy[providerCollectionProvider.Name] = "--providers ";
                }

                var profileProviders = new List<Provider>();

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

                var process = Process.GetProcessById(processId);
                var configuration = new SessionConfiguration(
                    circularBufferSizeMB: buffersize,
                    format: EventPipeSerializationFormat.NetTrace,
                    providers: providerCollection);

                var failed = false;
                var terminated = false;

                using (var stream = EventPipeClient.CollectTracing(processId, configuration, out var sessionId))
                {
                    if (sessionId == 0)
                    {
                        Console.Error.WriteLine("Unable to create session.");
                        return ErrorCodes.SessionCreationError;
                    }

                    var collectingTask = new Task(() =>
                    {
                        try
                        {
                            using (var fs = new FileStream(output.FullName, FileMode.Create, FileAccess.Write))
                            {
                                Console.Out.WriteLine("\n\n");
                                var buffer = new byte[16 * 1024];

                                while (true)
                                {
                                    var nBytesRead = stream.Read(buffer, 0, buffer.Length);
                                    if (nBytesRead <= 0)
                                        break;
                                    fs.Write(buffer, 0, nBytesRead);
                                    foreach (var sizeChangeCallback in sizeChangeCallbacks)
                                    {
                                        sizeChangeCallback(fs.Length);
                                    }

                                    /*Console.Out.WriteLine(
                                        $"[{stopwatch.Elapsed.ToString(@"dd\:hh\:mm\:ss")}]\tRecording trace {GetSize(fs.Length)}");*/
                                    /*Debug.WriteLine(
                                        $"PACKET: {Convert.ToBase64String(buffer, 0, nBytesRead)} (bytes {nBytesRead})");*/
                                }
                            }

                            //if (format != TraceFileFormat.NetTrace)
                            //    TraceFileFormatConverter.ConvertToFormat(format, output.FullName);
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

                    EventPipeClient.StopTracing(processId, sessionId);

                    await collectingTask;
                }

                //tracing.SignalFinish(!failed);
                return failed ? ErrorCodes.TracingError : 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"[ERROR] {ex.ToString()}");
                //tracing.SignalFinish(false);
                return ErrorCodes.UnknownError;
            }
        }

        private static string GetSize(long length)
        {
            if (length > 1e9)
                return $"{$"{length / 1e9:0.00##}",-8} (GB)";
            if (length > 1e6)
                return $"{$"{length / 1e6:0.00##}",-8} (MB)";
            if (length > 1e3)
                return $"{$"{length / 1e3:0.00##}",-8} (KB)";
            return $"{$"{length / 1.0:0.00##}",-8} (B)";
        }
    }
}