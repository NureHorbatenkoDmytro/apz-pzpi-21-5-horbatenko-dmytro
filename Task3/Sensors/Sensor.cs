namespace FloraSenseIoT.Sensors
{
    public class Sensor
    {
        private readonly string _sensorType;

        public Sensor(string sensorType)
        {
            _sensorType = sensorType;
        }

        public async Task<float> GetDataAsync()
        {
            await Task.Delay(500);
            return new Random().Next(0, 100);
        }
    }
}
