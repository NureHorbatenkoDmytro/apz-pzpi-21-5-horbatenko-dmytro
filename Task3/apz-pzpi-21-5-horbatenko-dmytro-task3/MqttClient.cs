using FloraSenseIoT.Models;
using MQTTnet.Client;
using MQTTnet;
using System.Text.Json;

namespace FloraSenseIoT
{

    public class MqttClientService
    {
        private readonly IMqttClient _mqttClient;

        public MqttClientService()
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
        }

        public async Task ConnectAsync(string broker, int port)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(broker, port)
                .Build();

            _mqttClient.ConnectedAsync += async e =>
            {
                Console.WriteLine("Connected successfully with MQTT Brokers.");
                await Task.CompletedTask;
            };

            _mqttClient.DisconnectedAsync += async e =>
            {
                Console.WriteLine("Disconnected from MQTT Brokers.");
                await Task.CompletedTask;
            };

            await _mqttClient.ConnectAsync(options, CancellationToken.None);
        }

        public async Task PublishAsync(string topic, string data)
        {
            var payload = JsonSerializer.Serialize(data);
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
                .WithRetainFlag()
                .Build();

            await _mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}
