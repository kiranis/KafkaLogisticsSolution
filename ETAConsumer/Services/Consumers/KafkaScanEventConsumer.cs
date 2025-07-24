using Confluent.Kafka;
using Newtonsoft.Json;
using ETAConsumer.Models;
using ETAConsumer.Domain.Entities;
using ETAConsumer.Application.Services;
using ETAConsumer.Events;
using System;
using ETAConsumer.Repositories;

namespace ETAConsumer.Services.Consumers
{
    public class KafkaScanEventConsumer : IScanEventConsumer
    {
        private readonly ConsumerConfig _config;
        private readonly IETAPredictionRepository _repository;
        private readonly ETAPredictionAppService _appService;
        private readonly IEventPublisher _eventPublisher;

        public KafkaScanEventConsumer(
            ConsumerConfig config,
            IETAPredictionRepository repository,
            ETAPredictionAppService appService,
            IEventPublisher eventPublisher)
        {
            _config = config;
            _repository = repository;
            _appService = appService;
            _eventPublisher = eventPublisher;
        }

        public void Start()
        {
            using var consumer = new ConsumerBuilder<string, string>(_config).Build();
            consumer.Subscribe("scan.events");

            while (true)
            {
                var consumeResult = consumer.Consume();
                var scan = JsonConvert.DeserializeObject<ScanEvent>(consumeResult.Message.Value);

                var package = new Package
                {
                    PackageId = scan.PackageId,
                    Location = scan.Location,
                    ScanTimestamp = scan.Timestamp,
                    ScanType = scan.ScanType
                };

                var prediction = _appService.Predict(package);

                Console.WriteLine($"ETA Prediction: Package {prediction.PackageId} from {prediction.Location} will arrive around {prediction.ETA:u}");
                _repository.Add(prediction);

                // Publish the ETAPredictedEvent
                var etaEvent = new ETAPredictedEvent
                {
                    PackageId = prediction.PackageId,
                    Location = prediction.Location,
                    ETA = prediction.ETA
                };
                _eventPublisher.Publish(etaEvent);
            }
        }
    }
}