using Confluent.Kafka;
using ETAConsumer.Events;
using Newtonsoft.Json;
using System;

namespace ETAConsumer.Infrastructure.EventPublishers
{
    public class KafkaEventPublisher : IEventPublisher
    {
        private readonly ProducerConfig _config;

        public KafkaEventPublisher(ProducerConfig config)
        {
            _config = config;
        }

        public void Publish<TEvent>(TEvent @event)
        {
            using var producer = new ProducerBuilder<string, string>(_config).Build();
            var message = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonConvert.SerializeObject(@event)
            };
            producer.Produce(typeof(TEvent).Name, message);
        }
    }
}