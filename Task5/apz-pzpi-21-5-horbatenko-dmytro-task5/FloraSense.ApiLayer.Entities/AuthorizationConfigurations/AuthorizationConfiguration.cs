using System.ComponentModel;

namespace FloraService.ApiLayer.Entities.AuthorizationConfigurations
{
    public class AuthorizationConfiguration : INotifyPropertyChanged
    {
        private string? _accessToken;
        public string? AccessToken 
        {
            get => _accessToken;
            set
            {
                _accessToken = value?.Replace("Bearer ", "");
                PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(AccessToken)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
