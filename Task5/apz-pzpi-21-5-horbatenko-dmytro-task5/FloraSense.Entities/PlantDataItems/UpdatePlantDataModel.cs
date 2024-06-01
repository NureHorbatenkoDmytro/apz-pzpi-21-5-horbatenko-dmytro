namespace FloraSense.Entities.PlantDataItems
{
    public class UpdatePlantDataModel
    {
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public double Light { get; set; }
        public double NutrientLevel { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
