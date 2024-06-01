using FloraService.ApiLayer.Entities.AuthorizationConfigurations;

namespace FloraService.ApiLayer.Abstractions
{
    public interface IAuthorizationApiService
    {
        Task AuthorizeAsync(LoginModel loginModel);
        Task RegisterAsync(RegisterModel registerModel);
    }
}
