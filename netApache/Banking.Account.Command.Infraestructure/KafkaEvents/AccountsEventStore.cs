using Banking.Account.Command.Application.Aggregate;
using Banking.Account.Command.Application.Contracts.Persistence;
using Banking.Account.Command.Domain;
using Banking.Cqrs.Core.Event;
using Banking.Cqrs.Core.Infraestructure;
using Banking.Cqrs.Core.Producer;

namespace Banking.Account.Command.Infraestructure.KafkaEvents
{
    public class AccountsEventStore : EventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly EventProducer _eventProducer;

        public AccountsEventStore(IEventStoreRepository eventStoreRepository, EventProducer eventProducer)
        {
            _eventStoreRepository = eventStoreRepository;
            _eventProducer = eventProducer;
        }

        public async Task<List<BaseEvent>> GetEvents(string aggregateId)
        {
            var eventStream = await _eventStoreRepository.FindByAggregateIdentifier(aggregateId);
            if (eventStream == null || !eventStream.Any())
            {
                throw new Exception("Cuenta bancaria no existe");
            }

            return eventStream.Select(x => x.EventData).ToList();
        }

        public async Task SaveEvents(string aggregateId, IEnumerable<BaseEvent> events, int expectedVersion)
        {
            var eventStream = await _eventStoreRepository.FindByAggregateIdentifier(aggregateId);

            if (expectedVersion != -1 &&
                 int.TryParse(eventStream.ElementAt(eventStream.Count() - 1).Version, out var lastEventVersion) &&
                lastEventVersion != expectedVersion)
            {
                throw new Exception("Error de concurrencia");
            }

            var version = expectedVersion;

            foreach (var ev in events)
            {
                version++;
                ev.version = version;

                var eventModel = new EventModel
                {
                    TimesTamp = DateTime.Now,
                    AggregateIdentifier = aggregateId,
                    Version = version.ToString(),
                    AggregateType = nameof(AccountAggregate),
                    EventType = ev.GetType().Name,
                    EventData = ev,
                };

               await _eventStoreRepository.InsertDocument(eventModel);
                _eventProducer.Produce(ev.GetType().Name, ev);
            }
        }
    }
}
