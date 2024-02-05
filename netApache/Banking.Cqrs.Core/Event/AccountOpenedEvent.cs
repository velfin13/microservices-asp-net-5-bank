

namespace Banking.Cqrs.Core.Event
{
    public class AccountOpenedEvent : BaseEvent
    {
        public string AccountHolder { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public double OpeningBalance { get; set; }

        public AccountOpenedEvent(string id, string accountHolder, string accountType, DateTime createdAt, double openingBalance) : base(id)
        {
            AccountType = accountType;
            CreatedAt = createdAt;
            OpeningBalance = openingBalance;
            AccountHolder = accountHolder;
        }

       
    }
}
