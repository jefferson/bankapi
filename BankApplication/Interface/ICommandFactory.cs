using BankApplication.AccountCommands;
using BankApplication.AccountCommands.Helper;

namespace BankApplication.Interface
{
    public interface ICommandFactory
    {
        (AccountEvent accountEvent, ICommand command) ResolveCommand(AccountEvent accountEvent);
    }
}