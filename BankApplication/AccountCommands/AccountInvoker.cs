using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.AccountCommands
{
    public class AccountInvoker : IAccountInvoker
    {
        private readonly IAccountReceiver _accountReceiver;
        private readonly ICommandFactory commandFactory;
        private (AccountEvent accountEvent, Command command) _action;

        public AccountInvoker(IAccountReceiver accountReceiver, ICommandFactory commandFactory)
        {
            this._accountReceiver = accountReceiver;
            this.commandFactory = commandFactory;
        }

        public void SetCommand(AccountEvent accountEvent)
        {
            _action = commandFactory.Build(accountEvent);
        }

        public void ExecuteCommand()
        {
            _accountReceiver.ExecuteCommand(_action.accountEvent, _action.command);
        }

        public object GetResult()
        {
            return _action.command.Result;
        }
    }
}
