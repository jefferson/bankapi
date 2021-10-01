using BankApplication.AccountCommands.Helper;
using BankApplication.Interface;
using BankApplication.Resource;
using BankApplication.Response;
using Microsoft.AspNetCore.Http;

namespace BankApplication.AccountCommands
{
    public class WithdrawCommand : ICommand
    {
        private (int StatusCodes, object Content) _Result;

        (int StatusCodes, object Content) ICommand.Result => _Result;

        public void Execute(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            if (accountRepository.Exist(accountEvent.Origin))
            {
                WithdrawValue(accountRepository, accountEvent);
            }
            else
            {
                this._Result = (StatusCodes.Status404NotFound, 0);
            }
        }

        private void WithdrawValue(IAccountRepository accountRepository, AccountEvent accountEvent)
        {
            var currentBalance = accountRepository.Get(accountEvent.Origin);

            var newBalance = currentBalance.balance_value - accountEvent.Amount;

            if(accountEvent.Amount > currentBalance.balance_value )
            {
                this._Result = (StatusCodes.Status201Created, SharedResource.NoBalance);
                return;
            }

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

            this._Result = (StatusCodes.Status201Created, result.Withdraw);
        }

    }
}
