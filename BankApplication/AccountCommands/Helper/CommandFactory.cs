using BankApplication.Interface;

namespace BankApplication.AccountCommands.Helper
{
    public class CommandFactory : ICommandFactory
    {
        public (AccountEvent accountEvent, Command command) Build(AccountEvent accountEvent)
        {
            Command command = null;

            switch (accountEvent.Type)
            {
                case EventEnum.Transfer:
                    command = new TransferCommand();
                    break;
                case EventEnum.Withdraw:
                    command = new WithdrawCommand();
                    break;
                case EventEnum.Deposit:
                    command = new DepositCommand();
                    break;
                default:
                    break;
            }

            return (accountEvent, command);
        }
    }
}
