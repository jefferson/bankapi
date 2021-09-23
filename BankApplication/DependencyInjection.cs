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
            services.AddSingleton<IBalanceRepository, BalanceRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();

            services.AddSingleton<IAccountReceiver, AccountReceiver>();
            services.AddSingleton<IAccountInvoker, AccountInvoker>();

            return services;
        }
    }
}
