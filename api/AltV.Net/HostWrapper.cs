using System;
using System.Collections.Generic;

namespace AltV.Net
{
    /// <summary>
    /// Receives host delegates from host when starting the resource to communicate with host
    /// </summary>
    internal static class HostWrapper
    {
        public delegate bool ImportDelegate(string resourceName, string key, out object value);

        private static Action<string> _startTracing;

        private static Action _stopTracing;

        private static ImportDelegate _import;

        private static Action<string, object> _export;

        private static readonly Action<long> OnTraceSizeChange = OnTraceSizeChangeDelegate;
        
        internal static readonly HashSet<Action<long>> OnTraceFileSizeChangeEventHandlers = new HashSet<Action<long>>();

        private static void OnTraceSizeChangeDelegate(long size)
        {
            lock (OnTraceFileSizeChangeEventHandlers)
            {
                foreach (var onTraceFileSizeChange in OnTraceFileSizeChangeEventHandlers)
                {
                    onTraceFileSizeChange(size);
                }
            }
        }

        public static Action<long> GetTraceSizeChangeDelegate()
        {
            return OnTraceSizeChange;
        }

        public static void SetStartTracingDelegate(Action<string> startTracing)
        {
            _startTracing = startTracing;
        }

        public static void SetStopTracingDelegate(Action stopTracing)
        {
            _stopTracing = stopTracing;
        }

        public static void SetImportDelegate(Delegate import)
        {
            _import = new ImportDelegate((string name, string key, out object value) =>
            {
                var parameters = new object[] {name, key, null};
                var result = (bool) import.DynamicInvoke(parameters);
                value = parameters[2];
                return result;
            });
        }

        public static void SetExportDelegate(Action<string, object> export)
        {
            _export = export;
        }

        public static void StartTracing(string traceFileName)
        {
            _startTracing?.Invoke(traceFileName);
        }

        public static void StopTracing()
        {
            _stopTracing?.Invoke();
        }

        public static bool Import(string resourceName, string key, out object value)
        {
            if (_import != null)
            {
                return _import.Invoke(resourceName, key, out value);
            }
            else
            {
                value = default;
                return false;
            }
        }

        public static void Export(string key, object value)
        {
            _export?.Invoke(key, value);
        }
    }
}