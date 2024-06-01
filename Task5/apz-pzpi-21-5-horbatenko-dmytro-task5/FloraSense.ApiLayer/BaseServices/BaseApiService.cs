using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace FloraService.ApiLayer
{
    public class BaseApiService
    {
        private readonly IHttpClientFabric _httpClientFabric;
        private readonly AuthorizationConfiguration _authorizationConfiguration;

        public BaseApiService(IHttpClientFabric httpClientFabric, AuthorizationConfiguration authorizationConfiguration)
        {
            _httpClientFabric = httpClientFabric;
            _authorizationConfiguration = authorizationConfiguration;
        }

        protected async Task SendRequest<TBody>(TBody body, string endpoint, HttpMethod method, CancellationToken cancellationToken = default)
        {
            var client = _httpClientFabric.CreateHttpClient();

            var request = new HttpRequestMessage()
            {
                Content = JsonContent.Create(body),
                Method = method,
                RequestUri = new Uri(endpoint, UriKind.Relative),
            };

            if (_authorizationConfiguration.AccessToken is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationConfiguration.AccessToken);
            }

            var response = await client.SendAsync(request, cancellationToken);
            var test = await response.Content.ReadAsStringAsync();
        }

        protected async Task<TResult> SendRequest<TBody, TResult>(TBody body, TResult defaultValue, string endpoint, HttpMethod method, CancellationToken cancellationToken = default)
        {
            var client = _httpClientFabric.CreateHttpClient();

            var request = new HttpRequestMessage()
            {
                Content = JsonContent.Create(body),
                Method = method,
                RequestUri = new Uri(endpoint, UriKind.Relative),
            };

            if (_authorizationConfiguration.AccessToken is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationConfiguration.AccessToken);
            }

            var response = await client.SendAsync(request, cancellationToken);
            var test = await  response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return defaultValue;
            }

            return await response.Content.ReadFromJsonAsync<TResult>() ?? defaultValue;
        }

        protected async Task<TResult> SendRequest<TResult>(string endpoint, TResult defaultValue, IDictionary<string, string>? queryValues = null, CancellationToken cancellationToken = default)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var keyValue in queryValues ?? new Dictionary<string, string>())
            {
                query[keyValue.Key] = keyValue.Value;
            }

            var client = _httpClientFabric.CreateHttpClient();
            
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{endpoint}?{query}", UriKind.Relative),
            };

            if (_authorizationConfiguration.AccessToken is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationConfiguration.AccessToken);
            }

            var response = await client.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return defaultValue;
            }

            return await response.Content.ReadFromJsonAsync<TResult>(cancellationToken) ?? defaultValue;
        }
    }
}
