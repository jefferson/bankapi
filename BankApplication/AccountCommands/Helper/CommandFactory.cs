namespace BankApplication.AccountCommands.Helper
{
    using BankApplication.Interface;
    using System;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public (AccountEvent accountEvent, ICommand command) ResolveCommand(AccountEvent accountEvent)
        {
            
            ICommand command = null;

            switch (accountEvent.Type)
            {
                case EventEnum.Transfer:
                    command =  resolveInstance<TransferCommand>();
                    break;
                case EventEnum.Withdraw:
                    command = resolveInstance<WithdrawCommand>();
                    break;
                case EventEnum.Deposit:
                    command = resolveInstance<DepositCommand>();
                    break;
                default:
                    break;
            }

            return (accountEvent, command);
        }


        private ICommand resolveInstance<T>()
        {
            return (ICommand)serviceProvider.GetService(typeof(T));
        }

    }
}
