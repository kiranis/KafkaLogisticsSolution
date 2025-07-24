using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScanIngestor.Application.Services;
using ScanIngestor.Domain.Services;
using ScanIngestor.Infrastructure.EventPublishers;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        services.AddSingleton(producerConfig);
        services.AddSingleton<IScanEventPublisher, KafkaScanEventPublisher>();
        services.AddSingleton<ScanIngestionService>();
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}