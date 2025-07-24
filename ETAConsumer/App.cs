using Confluent.Kafka;
using ETAConsumer.Services.Consumers;

public class App
{
    private readonly KafkaScanEventConsumer _consumer;

    public App(KafkaScanEventConsumer consumer)
    {
        _consumer = consumer;
    }

    public void Run()
    {
        _consumer.Start();
    }
}