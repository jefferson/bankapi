using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;

namespace BankApplication.AccountCommands
{
    public interface ICommand
    {
        public (int StatusCodes, object Content) Result { get; }
        public abstract void Execute(IAccountRepository accountRepository, AccountEvent accountEvent);
    }
}
