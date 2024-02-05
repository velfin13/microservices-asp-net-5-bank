using Banking.Cqrs.Core.Domain;

namespace Banking.Cqrs.Core.Handler
{
    public interface EventSourcingHandler<T>
    {
        Task save(AggregateRoot aggregate);
        Task<T> getById(string id);
    }
}
