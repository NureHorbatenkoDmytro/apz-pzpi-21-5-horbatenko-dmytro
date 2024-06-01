using FloraSense.Entities.PlantDataItems;
using FloraService.ApiLayer;
using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;
using FloraService.ApiLayer.Entities.EndpointConfigurations;

namespace FloraSense.ApiLayer.EntityApiServices
{
    public class PlantDataApiService : BaseEntityApiService<PlantDataModel, PlantDataModelId, CreatePlantDataModel, UpdatePlantDataModel>
    {
        private readonly BaseEntityEndpointConfiguration<PlantDataModel> _endpointConfiguration;

        public PlantDataApiService(AuthorizationConfiguration authorizationConfiguration, IHttpClientFabric httpClientFabric, BaseEntityEndpointConfiguration<PlantDataModel> endpointConfiguration) : base(authorizationConfiguration, httpClientFabric, endpointConfiguration)
        {
            _endpointConfiguration = endpointConfiguration;
        }

        public Task<IEnumerable<PlantDataModel>> GetAllPlantsAsync(Guid plantId, CancellationToken cancellationToken = default) =>
            SendRequest<IEnumerable<PlantDataModel>>(
                string.Format(_endpointConfiguration.GetAllEndpoint, plantId),
                [], 
                cancellationToken: cancellationToken);
    }
}
