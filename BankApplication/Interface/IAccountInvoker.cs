using BankApplication.AccountCommands.Helper;

namespace BankApplication.Interface
{
    public interface IAccountInvoker
    {
        void ExecuteCommand();
        void SetCommand(AccountEvent accountEvent);
        (int StatusCodes, object Content) GetResult();
    }
}