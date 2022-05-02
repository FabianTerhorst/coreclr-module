using System;
using AltV.Net.Elements.Args;
using AltV.Net.Shared;
using AltV.Net.Shared.Elements.Data;

namespace AltV.Net
{
    public interface INativeResource : ISharedNativeResource
    {
        CSharpResourceImpl CSharpResourceImpl { get; }

        string Path { get; }

        string Main { get; }

        void Start();

        void Stop();

        public IConfig GetConfig();
    }
}