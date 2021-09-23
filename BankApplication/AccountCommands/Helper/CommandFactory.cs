using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.AccountCommands.Helper
{
    public static class CommandFactory
    {
        public static (AccountEvent accountEvent, Command command) Build(AccountEvent accountEvent)
        {
            Command command = null;

            switch (accountEvent.Type)
            {
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
