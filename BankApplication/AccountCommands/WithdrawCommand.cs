using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Response;
using System.Collections.Generic;

namespace BankApplication.AccountCommands
{
    public class WithdrawCommand : Command
    {
        public override void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            if (accountRepository.Exist(accountEvent.Origin))
            {
                WithdrawtValue(accountRepository, accountEvent);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        private void WithdrawtValue(IAccountRepository accountRepository, AccountEvent accountEvent)
        {

        }

    }
}
