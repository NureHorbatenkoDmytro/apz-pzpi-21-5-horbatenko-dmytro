namespace FloraSense.Entities.PlantTypes
{
    public class CreatePlantTypeModel
    {
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double OptimalHumidity { get; set; }
        public double OptimalTemperature { get; set; }
        public double OptimalLight { get; set; }
    }

}
