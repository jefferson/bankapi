using BankApplication.AccountCommands.Helper;
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

        public void ExecuteCommand(AccountEvent accountEvent, Command command)
        {
            command.Execute(accountRepository, accountEvent);
        }
    }
}
