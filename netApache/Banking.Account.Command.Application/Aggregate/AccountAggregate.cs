using Banking.Account.Command.Application.Features.BankAccount.Command.OpenAccount;
using Banking.Cqrs.Core.Domain;

namespace Banking.Account.Command.Application.Aggregate
{
    public class AccountAggregate : AggregateRoot
    {
        public bool IsActive { get; set; }
        public double balance { get; set; }

        public AccountAggregate() { }
        public AccountAggregate(OpenAccountCommand command)
        {

        }
        
    }
}
