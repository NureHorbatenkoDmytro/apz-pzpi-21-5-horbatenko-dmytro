using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FloraSense.ViewModels.BaseViewModels;
using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FloraSense.ViewModels.PageViewModels
{
    public partial class RegistrationViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email = string.Empty;
        [ObservableProperty]
        private string _password = string.Empty;
        [ObservableProperty]
        private string _confirmPassword = string.Empty;
        [ObservableProperty]
        private ObservableCollection<string> _errors = [];
        private readonly IAuthorizationApiService _authorizationApiService;

        public ICommand Register { get; set; }

        public RegistrationViewModel(IAuthorizationApiService authorizationApiService)
        {
            Register = new AsyncRelayCommand(RegisterAsync);
            _authorizationApiService = authorizationApiService;
        }

        private async Task RegisterAsync()
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
            if (Password != ConfirmPassword)
            {
                Errors.Add("Confirm password is not same as password");
            }

            if (Errors.Count == 0)
            {
                await _authorizationApiService.RegisterAsync(new RegisterModel
                {
                    Email = Email,
                    Password = Password,
                    PasswordRepeat = ConfirmPassword,
                });
            }
        }
    }
}
