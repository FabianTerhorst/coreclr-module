using System;
using AltV.Net.Elements.Args;

namespace AltV.Net
{
    public interface INativeResource
    {
        IntPtr ResourceImpl { get; }

        CSharpResourceImpl CSharpResourceImpl { get; }

        string Path { get; }

        string Name { get; }

        string Main { get; }

        string Type { get; }

        bool IsStarted { get; }

        void SetExport(string key, object value);

        bool GetExport(string key, ref MValue value);

        void Start();

        void Stop();
    }
}