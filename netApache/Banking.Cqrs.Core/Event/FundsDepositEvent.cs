namespace Banking.Cqrs.Core.Event
{
    internal class FundsDepositEvent : BaseEvent
    {
        public double amount { get; set; }
        public FundsDepositEvent(string id) : base(id)
        {
        }
    }
}
