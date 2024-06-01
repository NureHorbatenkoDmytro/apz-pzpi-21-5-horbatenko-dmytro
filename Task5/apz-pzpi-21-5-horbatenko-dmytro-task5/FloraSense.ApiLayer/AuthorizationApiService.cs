using FloraSense.Entities.Users;
using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.Abstractions;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;

namespace FloraService.ApiLayer
{
    public class AuthorizationApiService : BaseApiService, IAuthorizationApiService
    {
        private readonly AuthorizationConfiguration _authorizationConfiguration;
        private readonly IAuthorizationEndpointConfiguration _authorizationEndpointConfiguration;

        public AuthorizationApiService(
            AuthorizationConfiguration authorizationConfiguration,
            IAuthorizationEndpointConfiguration authorizationEndpointConfiguration,
            IHttpClientFabric httpClientFabric
            ) : base(httpClientFabric, authorizationConfiguration)
        {
            _authorizationConfiguration = authorizationConfiguration;
            _authorizationEndpointConfiguration = authorizationEndpointConfiguration;
        }

        public async Task AuthorizeAsync(LoginModel loginModel)
        {
            var token = await SendRequest(loginModel, new Token(), _authorizationEndpointConfiguration.LoginEndpoint, HttpMethod.Post);

            if (token.AccessToken is not null)
            {
                _authorizationConfiguration.AccessToken = string.IsNullOrEmpty(token.AccessToken) ? null : token.AccessToken;
            }
        }

        public async Task RegisterAsync(RegisterModel registerModel)
        {
            var user = await SendRequest(registerModel, new UserModel(), _authorizationEndpointConfiguration.RegistrationEndpoint, HttpMethod.Post);

            if (!user.IsEmpty)
            {
                await AuthorizeAsync(new LoginModel
                {
                    Email = registerModel.Email,
                    Password = registerModel.Password,
                });
            }
        }
    }
}
