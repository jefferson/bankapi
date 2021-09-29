using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Response;
using System.Collections.Generic;

namespace BankApplication.AccountCommands
{
    public class WithdrawCommand : ICommand
    {
        private WithdrawResponse _Result;

        public object Result => _Result;

        public void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            if (accountRepository.Exist(accountEvent.Origin))
            {
                WithdrawValue(accountRepository, accountEvent);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        private void WithdrawValue(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            var currentBalance = accountRepository.Get(accountEvent.Origin);

            var newBalance = currentBalance.balance_value - accountEvent.Amount;

            accountRepository.UpdateBalance(accountEvent.Origin, new Domain.Entities.Balance()
            {
                balance_value = newBalance
            });

            var result = new CommandResponse()
            {
                Withdraw = new WithdrawResponse()
                {
                    origin = new Origin()
                    {
                        id = accountEvent.Origin,
                        balance = newBalance
                    }
                }
            };

            this._Result = result.Withdraw;
        }

    }
}
