using FloraSenseIoT.Models;
using FloraSenseIoT.Sensors;


namespace FloraSenseIoT.Controllers
{
    public class Controller
    {
        private readonly Sensor _humiditySensor;
        private readonly Sensor _temperatureSensor;
        private readonly Sensor _lightSensor;
        private readonly EncryptionService _encryptionService;

        public Controller()
        {
            string encryptionKey = "zP1h9w0zNc2Dg0lK7g2j3d4f5b6n7u8v"; // 32-byte encryption key
            string encryptionIv = "1y2w3z4x5a6b7c8d"; // 16-byte IV

            _encryptionService = new EncryptionService(encryptionKey, encryptionIv);

            _humiditySensor = new Sensor("Humidity");
            _temperatureSensor = new Sensor("Temperature");
            _lightSensor = new Sensor("Light");
        }

        public async Task<string> CollectDataAsync()
        {
            var humidity = await _humiditySensor.GetDataAsync();
            var temperature = await _temperatureSensor.GetDataAsync();
            var light = await _lightSensor.GetDataAsync();

            var data =  new SensorData
            {
                Humidity = humidity,
                Temperature = temperature,
                Light = light,
                Timestamp = DateTime.Now
            };
            Console.WriteLine($"Raw Data: {data}");

            return _encryptionService.Encrypt(data.ToString());
        }
    }
}
