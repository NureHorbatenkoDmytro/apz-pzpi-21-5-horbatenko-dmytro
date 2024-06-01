using FloraService.ApiLayer.Entities.Abstractions;

namespace FloraService.ApiLayer.Entities.EndpointConfigurations
{
    public class AuthorizationEndpointConfiguration : IAuthorizationEndpointConfiguration
    {
        public string LoginEndpoint => "auth/login";

        public string RegistrationEndpoint => "auth/register";

        public string RefreshEndpoint => "auth/refresh-tokens";
    }
}
