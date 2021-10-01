using BankApplication;
using BankApplication.AccountCommands;
using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICommandFactory, CommandFactory>();

            services.AddSingleton<TransferCommand>()
              .AddSingleton<ICommand, TransferCommand>(s => s.GetService<TransferCommand>());

            services.AddSingleton<DepositCommand>()
                .AddSingleton<ICommand, DepositCommand>(s => s.GetService<DepositCommand>());

            services.AddSingleton<WithdrawCommand>()
                .AddSingleton<ICommand, WithdrawCommand>(s => s.GetService<WithdrawCommand>());
        
            services.AddSingleton<IBalanceRepository, BalanceRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAccountReceiver, AccountReceiver>();
            services.AddSingleton<IAccountInvoker, AccountInvoker>();
            services.AddSingleton<IResetService, ResetService>();

            return services;
        }
    }
}
