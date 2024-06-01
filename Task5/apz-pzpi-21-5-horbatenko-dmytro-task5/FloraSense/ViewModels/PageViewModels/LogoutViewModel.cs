using CommunityToolkit.Mvvm.Input;
using FloraSense.Constants;
using FloraSense.ViewModels.BaseViewModels;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;
using System.Windows.Input;

namespace FloraSense.ViewModels.PageViewModels
{
    public class LogoutViewModel : BaseViewModel
    {
        private readonly AuthorizationConfiguration _authorizationConfiguration;

        public ICommand Logout { get; set; }

        public LogoutViewModel(AuthorizationConfiguration authorizationConfiguration)
        {
            Logout = new AsyncRelayCommand(LogoutAsync);
            _authorizationConfiguration = authorizationConfiguration;
        }

        public Task LogoutAsync()
        {
            Preferences.Remove(PreferenceConstants.AccessToken);
            _authorizationConfiguration.AccessToken = null;
            return Task.CompletedTask;
        }
    }
}
