using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.AccountCommands
{
    public class AccountInvoker
    {
        private readonly IAccountReceiver _accountReceiver;
        private (AccountEvent accountEvent, Command command) _action;

        public AccountInvoker(IAccountReceiver accountReceiver)
        {
            this._accountReceiver = accountReceiver;
        }

        public void SetCommand(AccountEvent accountEvent)
        {
            _action = CommandFactory.Build(accountEvent);
        }


        public void ExecuteCommand()
        {
            _accountReceiver.ExecuteCommand(_action.accountEvent, _action.command);
        }
    }
}
