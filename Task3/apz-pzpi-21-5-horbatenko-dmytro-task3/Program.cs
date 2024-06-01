using FloraSenseIoT;
using FloraSenseIoT.Controllers;
using Microsoft.Extensions.Configuration;

var authService = new AuthService();
var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json", false).Build();

string email = configuration["email"] ?? throw new Exception("No email provided!");
string password = configuration["password"] ?? throw new Exception("No password provided!");

string token = await authService.AuthenticateAsync(email, password);
Console.WriteLine($"Received Token: {token}");

var controller = new Controller();
var mqttClient = new MqttClientService();

await mqttClient.ConnectAsync("broker.hivemq.com", 1883);

while (true)
{
    var data = await controller.CollectDataAsync();
    await mqttClient.PublishAsync("plant-data/test", data);

    Console.WriteLine($"Data sent: {data}");
    await Task.Delay(5000);
}