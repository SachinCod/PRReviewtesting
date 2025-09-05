using System.Text;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Microsoft.Extensions.Configuration;

namespace MqttPublisherApp.Services
{
    public class MqttService
    {
        private readonly string _broker;
        private readonly int _port;
        private readonly string _topic;
        private readonly IMqttClient _client;

        public MqttService(IConfiguration configuration)
        {
            _broker = configuration["MqttSettings:Broker"];
            _port = int.Parse(configuration["MqttSettings:Port"]);
            _topic = configuration["MqttSettings:Topic"];

            var factory = new MqttFactory();
            _client = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(_broker, _port)
                .Build();

            _client.ConnectAsync(options).Wait();
        }

        public void Publish(string message)
        {
            var mqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic(_topic)
                .WithPayload(message)
                .WithExactlyOnceQoS()
                .WithRetainFlag()
                .Build();

            _client.PublishAsync(mqttMessage).Wait();
        }
    }
}
