using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.AccountCommands.Helper
{
    public static class CommandFactory
    {
        public static (AccountEvent accountEvent, Command command) Build(AccountEvent accountEvent)
        {
            var command = (Command)new DepositCommand();

            return (accountEvent, command);
        }
    }
}
