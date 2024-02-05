using Banking.Cqrs.Core.Event;

namespace Banking.Cqrs.Core.Infraestructure
{
    public interface EventStore
    {
        public Task SaveEvents(string aggregateId, IEnumerable<BaseEvent> events,int expectedVersion);
        public Task<List<BaseEvent>> GetEvents(string aggregateId);

    }
}
