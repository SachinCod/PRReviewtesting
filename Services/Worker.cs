using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace MqttPublisherApp.Services
{
    public class Worker : BackgroundService
    {
        private readonly DatabaseService _dbService;
        private readonly MqttService _mqttService;

        public Worker(DatabaseService dbService, MqttService mqttService)
        {
            _dbService = dbService;
            _mqttService = mqttService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var data = _dbService.GetData();
            foreach (var item in data)
            {
                _mqttService.Publish(item);
            }
            await Task.CompletedTask;
        }
    }
}
