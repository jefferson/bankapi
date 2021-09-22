using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.AccountCommands
{
    public abstract class Command
    {
        public abstract void Execute(IAccountRepository accountRepository, AccountEvent accountEvent);
    }
}
