using MediatR;

namespace Banking.Account.Command.Application.Features.BankAccount.Command.CloseAccount
{
    public class CloseAccountCommand : IRequest<bool>
    {
        public string AccountId { get; set; } = string.Empty;
    }
}
