namespace FloraSenseIoT.Models
{
    public class SensorData
    {
        public float Humidity { get; set; }
        public float Temperature { get; set; }
        public float Light { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"Humidity: {Humidity}, Temperature: {Temperature}, Light: {Light}, Timestamp: {Timestamp}";
        }
    }

}
