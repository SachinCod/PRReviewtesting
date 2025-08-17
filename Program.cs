using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MqttPublisherApp.Services;

Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<DatabaseService>();
        services.AddSingleton<MqttService>();
    })
    .Build()
    .Run();
