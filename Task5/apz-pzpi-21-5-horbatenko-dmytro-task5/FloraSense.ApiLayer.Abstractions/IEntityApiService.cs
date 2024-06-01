namespace FloraService.ApiLayer.Abstractions
{
    public interface IEntityApiService<T, TId, TCreation, TUpdate>
    {
        Task CreateAsync(TCreation newEntity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TUpdate updateEntity, TId idEntity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TId deleteEntity, CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(TId entityId, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
