using FloraSense.ApiLayer.Entities.EndpointConfigurations.EntityEndpointConfigurations;
using FloraSense.ApiLayer.EntityApiServices;
using FloraSense.Entities.PlantDataItems;
using FloraService.ApiLayer;
using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.Abstractions;
using FloraService.ApiLayer.Entities.EndpointConfigurations;
using FloraService.ApiLayer.Entities.HttpClientConfigurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FloraSense.ApiLayer
{
    public static class DependencyInjector
    {
        public static void Inject(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IEntityApiService<,,,>), typeof(BaseEntityApiService<,,,>));
            serviceCollection.AddScoped<PlantDataApiService>();
            serviceCollection.AddScoped<IAuthorizationApiService, AuthorizationApiService>();
            serviceCollection.AddScoped<IHttpClientFabric, HttpClientFabric>();

            serviceCollection.AddScoped(typeof(BaseEntityEndpointConfiguration<>));
            serviceCollection.AddScoped<BaseEntityEndpointConfiguration<PlantDataModel>, PlantDataEndpointConfiguration>();
            serviceCollection.AddScoped<IAuthorizationEndpointConfiguration, AuthorizationEndpointConfiguration>();
            serviceCollection.Configure<HttpClientConfiguration>(httpClientConfiguration =>
            {
                httpClientConfiguration.BaseUrl = configuration["ApiConfiguration:BaseUrl"] ?? throw new ArgumentException("Unable to get api base url.");
            });
        }
    }
}
