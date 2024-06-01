namespace FloraSense.Entities.PlantDataItems
{
    public class CreatePlantDataModel
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Light { get; set; }
        public double NutrientLevel { get; set; }
        public string PlantId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}
