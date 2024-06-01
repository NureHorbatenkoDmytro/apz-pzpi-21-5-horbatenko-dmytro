using FloraService.ApiLayer.Abstractions;
using FloraService.ApiLayer.Entities.Abstractions;
using FloraService.ApiLayer.Entities.AuthorizationConfigurations;
using FloraService.ApiLayer.Entities.EndpointConfigurations;
using System.Text;

namespace FloraService.ApiLayer
{
    public class BaseEntityApiService<T, TId, TCreation, TUpdate> : BaseApiService, IEntityApiService<T, TId, TCreation, TUpdate>
    {
        private readonly IEntityEndpointConfiguration _endpointConfiguration;

        public BaseEntityApiService(
            AuthorizationConfiguration authorizationConfiguration,
            IHttpClientFabric httpClientFabric,
            BaseEntityEndpointConfiguration<T> endpointConfiguration) : base(httpClientFabric, authorizationConfiguration)
        {
            _endpointConfiguration = endpointConfiguration;
        }

        public virtual Task CreateAsync(TCreation newEntity, CancellationToken cancellationToken = default)
            => SendRequest(newEntity, _endpointConfiguration.CreateEndpoint, HttpMethod.Post, cancellationToken);

        public virtual Task DeleteAsync(TId deleteEntity, CancellationToken cancellationToken = default) 
            => SendRequest(deleteEntity, _endpointConfiguration.DeleteEndpoint, HttpMethod.Delete, cancellationToken);

        public virtual Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => SendRequest<IEnumerable<T>>(_endpointConfiguration.GetAllEndpoint, new List<T>(), cancellationToken: cancellationToken);

        public virtual Task<T?> GetByIdAsync(TId entityId, CancellationToken cancellationToken = default)
            => SendRequest(
                string.Format(
                    _endpointConfiguration.GetByIdEndpoint,
                    typeof(TId).GetProperties().Aggregate(new StringBuilder(), (sb, property)=> sb.Append($"{property.GetValue(entityId)?.ToString() ?? ""}")).ToString()), 
                default(T), 
                cancellationToken: cancellationToken);

        public virtual Task UpdateAsync(TUpdate updateEntity, TId idEntity, CancellationToken cancellationToken = default)
            => SendRequest(
                updateEntity,
                string.Format(
                    _endpointConfiguration.UpdateEndpoint,
                    typeof(TId).GetProperties().Aggregate(new StringBuilder(), (sb, property) => sb.Append($"{property.GetValue(idEntity)?.ToString() ?? ""}")).ToString()),
                HttpMethod.Patch,
                cancellationToken);
    }
}
