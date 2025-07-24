namespace ETAConsumer.Events
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent @event);
    }
}