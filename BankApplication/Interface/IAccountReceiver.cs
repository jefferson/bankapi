using BankApplication.AccountCommands;
using BankApplication.AccountCommands.Helper;

namespace BankApplication.Interface
{
    public interface IAccountReceiver
    {
        void ExecuteCommand(AccountEvent accountEvent, Command command);
    }
}