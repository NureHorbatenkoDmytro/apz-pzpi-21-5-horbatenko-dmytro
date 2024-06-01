using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FloraSense.ViewModels.BaseViewModels;
using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;
using System.Windows.Input;

namespace FloraSense.ViewModels.PageViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthorizationApiService _authorizationApiService;

        [ObservableProperty]
        private string _email = "";
        [ObservableProperty]
        private string _password = "";
        [ObservableProperty]
        private ICollection<string> _errors = [];

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IAuthorizationApiService authorizationApiService)
        {
            _authorizationApiService = authorizationApiService;

            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }

        private async Task LoginAsync()
        {
            Errors = [];
            if (string.IsNullOrEmpty(Email))
            {
                Errors.Add("Email is empty");
            }
            if (string.IsNullOrEmpty(Password))
            {
                Errors.Add("Password is empty");
            }

            if (Errors.Count == 0)
            {
                await _authorizationApiService.AuthorizeAsync(new LoginModel
                {
                    Email = Email,
                    Password = Password,
                });
            }
        }
    }
}
