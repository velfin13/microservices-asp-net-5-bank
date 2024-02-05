
namespace Banking.Account.Command.Application.Features.BankAccount.Command.WithdrawnFund
{
    public class WithdrawnFundCommand
    {
        public string AccountId { get; set; } = string.Empty;
        public double Ammount { get; set; }
    }
}
