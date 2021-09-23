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
                case "transfer":
                    command = new TransferCommand();
                    break;
                case "withdraw":
                    command = new WithdrawCommand();
                    break;
                case "deposit":
                    command = new DepositCommand();
                    break;
                default:
                    break;
            }

            return (accountEvent, command);
        }
    }
}
