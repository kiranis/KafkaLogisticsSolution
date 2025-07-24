using System;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ScanIngestor.Infrastructure.EventPublishers;

public class Program
{
    public static async Task Main(string[] args) // Change Main to async Task
    {
        await CreateHostBuilder(args).Build().RunAsync(); // Use RunAsync for async Main

        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using var producer = new ProducerBuilder<string, string>(config).Build();

        var scanEvent = JsonConvert.SerializeObject(new
        {
            packageId = "PKG-" + Guid.NewGuid().ToString().Substring(0, 8),
            location = "Montreal-DC",
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
            scanType = "IN"
        });

        await producer.ProduceAsync("scan.events", new Message<string, string>
        {
            Key = "PKG001",
            Value = scanEvent
        });

        Console.WriteLine("Scan event produced.");
    }

    // CreateHostBuilder method to configure services and host
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Register your services here
                var producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
                services.AddSingleton(producerConfig);
                services.AddSingleton<KafkaScanEventPublisher>();
            });
}