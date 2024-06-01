using FloraSense.Entities.Attributes;

namespace FloraSense.Entities.PlantTypes
{
    [EndpointName("plant-types")]
    public class PlantTypeModel
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double OptimalHumidity { get; set; }
        public double OptimalTemperature { get; set; }
        public double OptimalLight { get; set; }
    }
}
