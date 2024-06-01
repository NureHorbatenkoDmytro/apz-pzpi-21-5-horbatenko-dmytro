namespace FloraSense.Entities.Plants
{
    public class UpdatePlantModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid PlantTypeId { get; set; }
        public string PlantingDate { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public string SoilType { get; set; } = string.Empty;
    }

}
