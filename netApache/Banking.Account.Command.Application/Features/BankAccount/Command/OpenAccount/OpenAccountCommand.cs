

using MediatR;

namespace Banking.Account.Command.Application.Features.BankAccount.Command.OpenAccount
{
    public class OpenAccountCommand : IRequest<bool>
    {
        public string AccountId { get; set; } = string.Empty;
        public string AccountHolder { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public double OpenAccountBalance { get; set; } 
    }
}
