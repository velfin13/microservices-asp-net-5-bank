using Banking.Cqrs.Core.Event;

namespace Banking.Cqrs.Core.Producer
{
    public interface EventProducer
    {
        void Produce(string topic,BaseEvent @event);
    }
}
