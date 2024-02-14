namespace Banking.Cqrs.Core.Event
{
    public class FundsDepositEvent : BaseEvent
    {
        public double Amount { get; set; }
        public FundsDepositEvent(string id) : base(id)
        {
        }
    }
}
