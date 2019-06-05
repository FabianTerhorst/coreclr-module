using AltV.Net.NetworkingEntity.Elements.Providers;

namespace AltV.Net.NetworkingEntity
{
    public class ClientEntityStreamingHandlerFactory : IStreamingHandlerFactory
    {
        public IStreamingHandler Create(IAuthenticationProvider authenticationProvider)
        {
            return new ClientEntityStreamingHandler(authenticationProvider);
        }
    }
}