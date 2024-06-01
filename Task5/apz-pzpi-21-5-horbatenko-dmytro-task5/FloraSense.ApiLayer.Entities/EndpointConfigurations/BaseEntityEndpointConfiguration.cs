using FloraSense.Entities.Attributes;
using FloraService.ApiLayer.Entities.Abstractions;
using System.Reflection;

namespace FloraService.ApiLayer.Entities.EndpointConfigurations
{
    public class BaseEntityEndpointConfiguration<T> : IEntityEndpointConfiguration
    {
        private readonly string _endpointName;

        public BaseEntityEndpointConfiguration()
        {
            _endpointName = typeof(T).GetCustomAttribute<EndpointNameAttribute>()?.EndpointName ?? typeof(T).Name;
        }

        public virtual string GetByIdEndpoint => $"{_endpointName}/{{0}}";

        public virtual string GetAllEndpoint => _endpointName;

        public virtual string CreateEndpoint => _endpointName;

        public virtual string DeleteEndpoint => $"{_endpointName}/{{0}}";

        public virtual string UpdateEndpoint => $"{_endpointName}/{{0}}";
    }
}
