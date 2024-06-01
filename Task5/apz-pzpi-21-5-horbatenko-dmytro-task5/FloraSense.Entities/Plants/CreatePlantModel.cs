using System.Globalization;
using System.Text.Json.Serialization;

namespace FloraSense.Entities.Plants
{
    public class CreatePlantModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid PlantTypeId { get; set; }
        [JsonIgnore]
        public DateTime PlantingDateInDate { get; set; }
        public string PlantingDate
        {
            get => PlantingDateInDate.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            set
            {
                PlantingDateInDate = DateTime.Parse(value);
            }
        }
        public string CurrentStatus { get; set; } = string.Empty;
        public string SoilType { get; set; } = string.Empty;
    }
}
