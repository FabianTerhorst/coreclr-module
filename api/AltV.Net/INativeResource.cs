using AltV.Net.Shared;

namespace AltV.Net
{
    public interface INativeResource : ISharedNativeResource
    {
        CSharpResourceImpl CSharpResourceImpl { get; }

        string Path { get; }

        string Main { get; }

        void Start();

        void Stop();
    }
}