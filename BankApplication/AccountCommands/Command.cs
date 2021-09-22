using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;

namespace BankApplication.AccountCommands
{
    public abstract class Command
    {
        public object Result { get; set; }
        public abstract void Execute(IAccountRepository accountRepository, AccountEvent accountEvent);
    }
}
