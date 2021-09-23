using BankApplication.AccountCommands;
using BankApplication.AccountCommands.Helper;

namespace BankApplication.Interface
{
    public interface ICommandFactory
    {
        (AccountEvent accountEvent, Command command) Build(AccountEvent accountEvent);
    }
}