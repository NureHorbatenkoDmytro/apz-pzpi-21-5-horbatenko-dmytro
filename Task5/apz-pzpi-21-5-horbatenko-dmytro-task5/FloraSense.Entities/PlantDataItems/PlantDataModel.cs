using FloraSense.Entities.Attributes;

namespace FloraSense.Entities.PlantDataItems
{
    [EndpointName("plant-data")]
    public class PlantDataModel
    {
        public Guid Id { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Light { get; set; }
        public double NutrientLevel { get; set; }
        public string PlantId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
