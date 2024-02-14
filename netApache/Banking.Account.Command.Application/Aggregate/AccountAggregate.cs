using Banking.Account.Command.Application.Features.BankAccount.Command.OpenAccount;
using Banking.Cqrs.Core.Domain;
using Banking.Cqrs.Core.Event;

namespace Banking.Account.Command.Application.Aggregate
{
    public class AccountAggregate : AggregateRoot
    {
        public bool IsActive { get; set; }
        public double Balance { get; set; }

        public AccountAggregate() 
        {
        }
        public AccountAggregate(OpenAccountCommand command)
        {
            var accountOpenedEvent =  new AccountOpenedEvent(command.AccountId,
                                                             command.AccountHolder,
                                                             command.AccountType,
                                                             DateTime.Now,
                                                             command.OpenAccountBalance);
            
            RaiseEvent(accountOpenedEvent);
        }

        public void Apply(AccountOpenedEvent @event)
        {
            Id = @event.Id;
            IsActive = true;
            Balance = @event.OpeningBalance;
        }

        public void DepositFunds(double amount)
        {
            if (!IsActive)
            {
                throw new Exception("Cuenta bancaria cerrada");
            }

            if (amount <= 0 )
            {
                throw new Exception("Deposito deve ser mayor a 0");
            }

            var foundDepositEvent = new FundsDepositEvent(Id)
            {
                Id = Id,
                Amount = amount
            };

            RaiseEvent(foundDepositEvent);

        }

        public void Apply(FundsDepositEvent @event)
        {
            Id = @event.Id;
            Balance += @event.Amount;
        }

        public void WithdrawFounds(double amount)
        {
            if (!IsActive)
            {
                throw new Exception("Cuenta bancaria cerrada");
            }
            var foundWithdrawnEvent = new FundsWithdrawnEvent(Id)
            {
                Id= Id,
                Amount = amount
            };

            RaiseEvent(foundWithdrawnEvent);
        }

        public void Apply(FundsWithdrawnEvent @event)
        {
            Id = @event.Id;
            Balance -= @event.Amount;
        }

        public void CloseAccount(FundsWithdrawnEvent @event)
        {
            if (!IsActive)
            {
                throw new Exception("Cuenta bancaria cerrada");
            }

            var accountClosedEvent = new AccountClosedEvent(Id);
            RaiseEvent(accountClosedEvent);
        }

        public void Apply(AccountClosedEvent @event)
        {
            Id = @event.Id;
            IsActive = false;
        }

    }
}
