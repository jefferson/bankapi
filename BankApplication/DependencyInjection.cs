using BankApplication.AccountCommands;
using BankApplication.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {          
            services.AddSingleton<IBalanceRepository, BalanceRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();

            services.AddSingleton<IAccountReceiver, AccountReceiver>();
            services.AddSingleton<IAccountInvoker, AccountInvoker>();

            return services;
        }
    }
}
