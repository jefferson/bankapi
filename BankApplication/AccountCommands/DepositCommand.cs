using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApplication.AccountCommands
{
    public class DepositCommand : Command
    {
        //# Create account with initial balance
        //POST /event {"type":"deposit", "destination":"100", "amount":10}
        //201 {"destination": {"id":"100", "balance":10}}
        public override void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            throw new NotImplementedException();
        }
    }
}
