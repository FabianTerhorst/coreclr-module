using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity
{
    public interface IStreamingHandlerFactory
    {
        IStreamingHandler Create(IAuthenticationProvider authenticationProvider);
    }
}