using Confluent.Kafka;
using Newtonsoft.Json;
using ScanIngestor.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using ScanIngestor.Domain.Entities;

namespace ScanIngestor.Infrastructure.EventPublishers
{
    public class KafkaScanEventPublisher : IScanEventPublisher
    {
        private readonly ProducerConfig _config;
        private readonly ILogger<KafkaScanEventPublisher> _logger;

        public KafkaScanEventPublisher(ProducerConfig config, ILogger<KafkaScanEventPublisher> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task PublishAsync(ScanEvent scanEvent)
        {
            using var producer = new ProducerBuilder<string, string>(_config).Build();
            var message = new Message<string, string>
            {
                Key = scanEvent.PackageId,
                Value = JsonConvert.SerializeObject(scanEvent)
            };

            try
            {
                await producer.ProduceAsync("scan.events", message);
                _logger.LogInformation($"Successfully published ScanEvent for PackageId: {scanEvent.PackageId}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to publish ScanEvent for PackageId: {scanEvent.PackageId}. Error: {ex.Message}");
                throw;
            }
        }
    }
}