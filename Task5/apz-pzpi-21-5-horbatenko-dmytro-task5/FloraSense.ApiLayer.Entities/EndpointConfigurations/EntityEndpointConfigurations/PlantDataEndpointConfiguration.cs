using FloraSense.Entities.PlantDataItems;
using FloraService.ApiLayer.Entities.EndpointConfigurations;

namespace FloraSense.ApiLayer.Entities.EndpointConfigurations.EntityEndpointConfigurations
{
    public class PlantDataEndpointConfiguration : BaseEntityEndpointConfiguration<PlantDataModel>
    {
        public override string GetAllEndpoint => base.GetAllEndpoint + "/{0}";
    }
}
