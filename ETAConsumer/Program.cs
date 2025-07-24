using Confluent.Kafka;
using ETAConsumer.Application.Services;
using ETAConsumer.Domain.Services;
using ETAConsumer.Events;
using ETAConsumer.Infrastructure.EventPublishers;
using ETAConsumer.Infrastructure.Repositories;
using ETAConsumer.Repositories;
using ETAConsumer.Services.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var consumerConfig = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "eta-predictor",
    AutoOffsetReset = AutoOffsetReset.Earliest
};
var producerConfig = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};
var connectionString = "Host=localhost;Username=postgres;Password=yourpassword;Database=etas";

builder.Services.AddSingleton(consumerConfig);
builder.Services.AddSingleton(producerConfig);
builder.Services.AddSingleton<IETAPredictionRepository>(new PostgresETAPredictionRepository(connectionString));
builder.Services.AddSingleton<ETAService>();
builder.Services.AddSingleton<ETAPredictionAppService>();
builder.Services.AddSingleton<IEventPublisher, KafkaEventPublisher>();
builder.Services.AddSingleton<KafkaScanEventConsumer>();
builder.Services.AddControllers(); // Add Web API controllers

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseRouting();

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETAConsumer API v1");
    c.RoutePrefix = string.Empty; // Swagger UI at the root
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map API controllers
});

app.Run();