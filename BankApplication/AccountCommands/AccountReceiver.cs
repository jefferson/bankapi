using BankApplication.Account.Helper;
using BankApplication.Interface;

namespace BankApplication.AccountCommands
{
    public class AccountReceiver : IAccountReceiver
    {
        private readonly IAccountRepository accountRepository;

        public AccountReceiver(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void ExecuteCommand(Command command, AccountEvent accountEvent)
        {
            command.Execute(accountRepository, accountEvent);
        }
    }
}
