namespace Banking.Cqrs.Core.Event
{
    public class AccountClosedEvent : BaseEvent
    {
        public AccountClosedEvent(string id) : base(id)
        {
        }
    }
}
