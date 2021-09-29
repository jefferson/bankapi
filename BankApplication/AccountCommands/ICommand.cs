using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;

namespace BankApplication.AccountCommands
{
    public interface ICommand
    {
        public object Result { get; }
        public abstract void Execute(IAccountRepository accountRepository, AccountEvent accountEvent);
    }
}
