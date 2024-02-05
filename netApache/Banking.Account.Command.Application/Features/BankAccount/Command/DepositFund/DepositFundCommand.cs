using MediatR;

namespace Banking.Account.Command.Application.Features.BankAccount.Command.DepositFund
{
    internal class DepositFundCommand : IRequest<bool>
    {
        public string AccountId { get; set; } = string.Empty;
        public double Ammount { get; set; }
    }
}
