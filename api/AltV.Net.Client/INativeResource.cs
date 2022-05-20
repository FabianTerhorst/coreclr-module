using AltV.Net.Client.Runtime;
using AltV.Net.Shared;

namespace AltV.Net.Client
{
    public interface INativeResource : ISharedNativeResource
    {
        new CSharpResourceImpl CSharpResourceImpl { get; }
    }
}