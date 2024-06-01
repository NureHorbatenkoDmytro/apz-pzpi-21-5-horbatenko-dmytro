using FloraSense.Entities.Guards;

namespace FloraService.Abstractions.Pages
{
    public interface IEntityWithGuards
    {
        public IEnumerable<Guard> Guards { get; }
    }
}
