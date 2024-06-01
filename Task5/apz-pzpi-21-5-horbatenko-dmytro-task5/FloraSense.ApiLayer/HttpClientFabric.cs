using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.HttpClientConfigurations;
using Microsoft.Extensions.Options;

namespace FloraSense.ApiLayer
{
    public class HttpClientFabric : IHttpClientFabric
    {
        private readonly HttpClientConfiguration _httpClientConfiguration;

        public HttpClientFabric(IOptions<HttpClientConfiguration> options)
        {
            _httpClientConfiguration = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public HttpClient CreateHttpClient()
        {
            return new HttpClient
            {
                BaseAddress = new Uri(_httpClientConfiguration.BaseUrl)
            };
        }
    }
}
