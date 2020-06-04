using System;
using AltV.Net.Elements.Args;

namespace AltV.Net
{
    public interface INativeResource
    {
        IntPtr ResourceImplPtr { get; }

        CSharpResourceImpl CSharpResourceImpl { get; }

        string Path { get; }

        string Name { get; }

        string Main { get; }

        string Type { get; }

        bool IsStarted { get; }
        
        string[] Dependencies { get; }
        
        string[] Dependants { get; }

        void SetExport(string key, object value);
        
        void SetExport(string key, in MValueConst value);

        object GetExport(string key);

        bool GetExport(string key, out MValueConst mValue);

        void Start();

        void Stop();
    }
}