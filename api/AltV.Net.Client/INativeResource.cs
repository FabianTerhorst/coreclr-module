using AltV.Net.Client.Runtime;

namespace AltV.Net.Client
{
    public interface INativeResource
    {
        CSharpResourceImpl CSharpResourceImpl { get; }
    }
}