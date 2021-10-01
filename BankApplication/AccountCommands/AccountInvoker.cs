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
        private readonly ICommandFactory _commandFactory;
        private (AccountEvent accountEvent, ICommand command) _action;

        public AccountInvoker(IAccountReceiver accountReceiver, ICommandFactory commandFactory)
        {
            this._accountReceiver = accountReceiver;
            this._commandFactory = commandFactory;
        }

        public void SetCommand(AccountEvent accountEvent)
        {
            _action = _commandFactory.ResolveCommand(accountEvent);
        }

        public void ExecuteCommand()
        {
            _accountReceiver.ExecuteCommand(_action.accountEvent, _action.command);
        }

        public (int StatusCodes, object Content) GetResult()
        {
            return _action.command.Result;
        }
    }
}
